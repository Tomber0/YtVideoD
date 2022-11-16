using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using NReco.VideoConverter;

namespace YtDownloadTest
{
    class YtDownloadVideo : YtVideoDownloader
    {
        private ProgressBar _progressBarAudio;
        private ProgressBar _progressBarVideo;

        public YtDownloadVideo()
        {
        }
        private void SetProgressBarValue(int newValue, ProgressBar progressBar)
        {
            progressBar.Value = newValue;
        }
        public YtDownloadVideo(ProgressBar progressBarAudio, ProgressBar progressBarVideo)
        {
            _progressBarAudio = progressBarAudio;
            _progressBarVideo = progressBarAudio;
        }

        public async override void Download(string url, string fileDirUrl, string newFileName)
        {
            var youTube = YouTube.Default;
            var video = await youTube.GetVideoAsync(url);
            var videoPath = $"{fileDirUrl}\\" + $"{newFileName}" + ".mp4";
            using (FileStream fs = new FileStream(videoPath, FileMode.OpenOrCreate)) 
            {
                await fs.WriteAsync(video.GetBytes(), 0, video.GetBytes().Length);
            }

        }
        public override void Convert(string path) 
        {
            ConvertVideoToAudio(path);
        }
        private void ConvertVideoToAudio(string videoPath)
        {
            var ffMpeg = new FFMpegConverter();
            ffMpeg.ConvertMedia($"{videoPath}", $"{videoPath}_Audio.mp3", Format.mp4);
        }
    }
}
