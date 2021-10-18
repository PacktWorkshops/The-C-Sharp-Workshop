using System;
using System.Linq;
using Azure;
using Azure.AI.TextAnalytics;

namespace Tests.Chapter08.Exercises.Exercise01
{
    class DemoTests
    {
        private static string TextAnalysisApiKey { get; } = Environment.GetEnvironmentVariable("TextAnalysisApiKey", EnvironmentVariableTarget.User);
        private static string TextAnalysisEndpoint { get; } = Environment.GetEnvironmentVariable("TextAnalysisEndpoint", EnvironmentVariableTarget.User);

        public static void Run()
        {
            var client = BuildClient();
            string text = "Today is a great day. " +
                          "I had a wonderful dinner with my family!";
            SentimentAnalysisExample(client, text);
        }

        static TextAnalyticsClient BuildClient()
        {
            var credentials = new AzureKeyCredential(TextAnalysisApiKey);
            var endpoint = new Uri(TextAnalysisEndpoint);
            var client = new TextAnalyticsClient(endpoint, credentials);

            return client;
        }

        static void SentimentAnalysisExample(TextAnalyticsClient client, string text)
        {
            DocumentSentiment documentSentiment = PerformSentimentalAnalysis(client, text);
            Console.WriteLine($"Document sentiment: {documentSentiment.Sentiment}\n");

            foreach (var sentence in documentSentiment.Sentences)
            {
                DisplaySentenceSummary(sentence);
                DisplaySentenceOpinions(sentence);
            }
        }

        private static DocumentSentiment PerformSentimentalAnalysis(TextAnalyticsClient client, string text)
        {
            var options = new AnalyzeSentimentOptions() { IncludeOpinionMining = true };
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(text, options: options);

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
