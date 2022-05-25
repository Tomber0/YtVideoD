using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YtDownloadTest
{
    abstract class YtVideoDownloader
    {
        public abstract void Download(string url,string fileUrl,string fileNewName);
        public abstract void Convert(string filePath);
    }
}
