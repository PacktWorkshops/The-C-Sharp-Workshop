using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;
using Chapter08.Common;

namespace Chapter08.Exercises.Exercise01
{
    public class Demo
    {
        private static string TextAnalysisApiKey { get; } = EnvironmentVariable.GetOrThrow("TextAnalysisApiKey");
        private static string TextAnalysisEndpoint { get; } = EnvironmentVariable.GetOrThrow("TextAnalysisEndpoint");

        public static async Task Run()
        {
            var client = BuildClient();
            string text = "Today is a great day. " +
                          "I had a wonderful dinner with my family!";
            await SentimentAnalysisExample(client, text);
        }

        static TextAnalyticsClient BuildClient()
        {
            var credentials = new AzureKeyCredential(TextAnalysisApiKey);
            var endpoint = new Uri(TextAnalysisEndpoint);
            var client = new TextAnalyticsClient(endpoint, credentials);

            return client;
        }

        static async Task SentimentAnalysisExample(TextAnalyticsClient client, string text)
        {
            DocumentSentiment documentSentiment = await PerformSentimentalAnalysis(client, text);
            Console.WriteLine($"Document sentiment: {documentSentiment.Sentiment}\n");

            foreach (var sentence in documentSentiment.Sentences)
            {
                DisplaySentenceSummary(sentence);
                DisplaySentenceOpinions(sentence);
            }
        }

        private static async Task<DocumentSentiment> PerformSentimentalAnalysis(TextAnalyticsClient client, string text)
        {
            var options = new AnalyzeSentimentOptions { IncludeOpinionMining = true };
            DocumentSentiment documentSentiment = await client.AnalyzeSentimentAsync(text, options: options);

            return documentSentiment;
        }

        private static void DisplaySentenceSummary(SentenceSentiment sentence)
        {
            Console.WriteLine($"Text: \"{sentence.Text}\"");
            Console.WriteLine($"Sentence sentiment: {sentence.Sentiment}");
            Console.WriteLine($"Positive score: {sentence.ConfidenceScores.Positive:0.00}");
            Console.WriteLine($"Negative score: {sentence.ConfidenceScores.Negative:0.00}");
            Console.WriteLine($"Neutral score: {sentence.ConfidenceScores.Neutral:0.00}{Environment.NewLine}");
        }

        private static void DisplaySentenceOpinions(SentenceSentiment sentence)
        {
            if (sentence.Opinions.Any())
            {
                Console.WriteLine("Opinions: ");
                foreach (var sentenceOpinion in sentence.Opinions)
                {
                    Console.Write($"{sentenceOpinion.Target.Text}");
                    var assessments = sentenceOpinion
                        .Assessments
                        .Select(a => a.Text);
                    Console.WriteLine($" is {string.Join(',', assessments)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
