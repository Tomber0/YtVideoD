using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace YtDownloadTest
{
    class ClipBoard
    {
        public static string Paste() 
        {
            var text = Clipboard.GetText();
            return text;
        }
    }
}
