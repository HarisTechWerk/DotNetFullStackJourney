using NotificationSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Services
{
    public class UpperCaseTransformer : ITextTransformer
    {
        public string TransformText(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            return input.ToUpperInvariant();
        }

    }
}
