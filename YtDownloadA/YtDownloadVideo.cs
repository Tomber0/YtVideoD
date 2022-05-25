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

        public override void Download(string url, string fileDirUrl, string newFileName)
        {


            var youTube = YouTube.Default; // starting point for YouTube actions

            var video = youTube.GetVideo(url); // gets a Video object with info about the video
            var userN = Environment.UserName;
            var videoPath = $"{fileDirUrl}\\" + $"{newFileName}" + ".mp4";
            File.WriteAllBytes($"{videoPath}", video.GetBytes());
            //MessageBox.Show("Download done!");
            //ConvertVideoToAudio(videoPath);
            MessageBox.Show("Convertion done!");
            
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
