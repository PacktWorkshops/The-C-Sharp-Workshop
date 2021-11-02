namespace Tests.Common
{
    public static class TestInputSanitizer
    {
        public static string[] ToNewlineSentences(this string message) => message.Split(".");
    }
}