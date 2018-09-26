using System.Drawing;
using Accord.Video.FFMPEG;

namespace FirstLife.Lib
{
    public static class VideoMaker
    {
        private static VideoFileWriter _writer;
        
        public static void NewWriter(string filename, int w, int h)
        {
            _writer = new VideoFileWriter();
            // create new AVI file and open it
            _writer.Open(filename, w, h,30, VideoCodec.Default , 5500000);
            
        }

        public static void Close()
        {
            _writer.Close();
        }
        
        public static void AddFrame(Bitmap frame)
        {
            _writer.WriteVideoFrame(frame);
        }
    }
}