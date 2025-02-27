using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Core
{
    public interface ITextTransformer
    {
        string TransformText(string input);
    }
}
