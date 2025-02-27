using NotificationSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Services
{
    public class ReverseTextTransformer : ITextTransformer
    {
        public string TranformText(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty; 

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
