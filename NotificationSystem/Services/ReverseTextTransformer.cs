using NotificationSystem.Core;

namespace NotificationSystem.Services
{
    public class ReverseTextTransformer : ITextTransformer
    {
        public string TransformText(string input) 
        {
            if (string.IsNullOrEmpty(input)) 
                return string.Empty;

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}