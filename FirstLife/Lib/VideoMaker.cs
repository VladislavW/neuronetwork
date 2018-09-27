using System.Drawing;
using Accord.IO;
using Accord.Video.FFMPEG;

namespace FirstLife.Lib
{
    public class VideoMaker
    {
        private static VideoFileWriter _writer;
        
        public static void NewWriter(string filename, int w, int h)
        {
            _writer = new VideoFileWriter
            {
                VideoCodec = VideoCodec.Default,
                Width = w,
                Height = h,
                FrameRate = 30,
                BitRate = 5500000
            };
            
            //_writer.Save(filename);
            // create new AVI file and open it
            _writer.Open(filename, "avi");// Save(filename);
           // _writer.Flush();
            
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