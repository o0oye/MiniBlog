using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace MiniBlog.Core.Plugin.IO
{
    public static class FormatImage
    {
        /// <summary>
        /// 限制宽按比例缩小
        /// </summary>
        /// <param name="inPath">输入路径</param>
        /// <param name="savePath">如果和原图地址相同则覆盖原图</param>
        /// <param name="toWidth">生成图片宽</param>
        /// <param name="quality">压缩质量(1~100)数字越小压缩比率越大(</param>
        public static void AutoToSmall(string inPath, string savePath, int toWidth, int quality=100)
        {
            //原始图片
            var initImage = Image.FromFile(inPath);            
            var rawFormat = initImage.RawFormat;
            var initWidth = initImage.Width;
            var initHeight = initImage.Height;

            //图片太小不用处理了,直接保存
            if (toWidth >= initWidth)
            {
                initImage.Save(savePath);
                initImage.Dispose();
                return;
            }
            var toHeight = toWidth * initHeight / initWidth;
            //缩略图对象
            Image pickedImage = new Bitmap(toWidth, toHeight);
            Graphics graphics = Graphics.FromImage(pickedImage);
            //用指定背景色清空画布
            graphics.Clear(Color.WhiteSmoke);
            //设置质量
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            //绘制缩略图
            graphics.DrawImage(initImage, new Rectangle(-1, -1, toWidth + 1, toHeight + 1), new Rectangle(0, 0, initWidth, initHeight), GraphicsUnit.Pixel);
            graphics.Dispose();
            initImage.Dispose();
            //压缩图片
            Compress(pickedImage, rawFormat, savePath, quality);
        }

        /// <summary>
        /// 限制宽按比例缩小
        /// </summary>
        /// <param name="inStream">输入图片流</param>
        /// <param name="savePath">如果和原图地址相同则覆盖原图</param>
        /// <param name="toWidth">生成图片宽</param>
        /// <param name="quality">压缩质量(1~100)数字越小压缩比率越大(</param>
        public static void AutoToSmall(Stream inStream, string savePath, int toWidth, int quality = 100)
        {
            //原始图片
            var initImage = Image.FromStream(inStream);
            //旋转图片
            byte orien = 0;
            var item = initImage.PropertyItems.Where(o => o.Id == 274).ToList();
            if (item != null && item.Count() > 0)
            {
                orien = item[0].Value[0];
            }
            if (orien == 8)
            {
                initImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (orien == 6)
            {
                initImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
           
            var rawFormat = initImage.RawFormat;
            var initWidth = initImage.Width;
            var initHeight = initImage.Height;

            //图片太小不用处理了,直接保存
            if (toWidth >= initWidth)
            {
                initImage.Save(savePath);
                initImage.Dispose();
                return;
            }
            var toHeight = toWidth * initHeight / initWidth;
            //缩略图对象
            Image pickedImage = new Bitmap(toWidth, toHeight);
            Graphics graphics = Graphics.FromImage(pickedImage);
            //用指定背景色清空画布
            graphics.Clear(Color.WhiteSmoke);
            //设置质量
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            //绘制缩略图
            graphics.DrawImage(initImage, new Rectangle(-1, -1, toWidth + 1, toHeight + 1), new Rectangle(0, 0, initWidth, initHeight), GraphicsUnit.Pixel);
            graphics.Dispose();
            initImage.Dispose();
            //压缩图片
            Compress(pickedImage, rawFormat, savePath, quality);
        }

        /// <summary>
        /// 图片压缩
        /// </summary>
        /// <param name="inImage">要压缩的图片</param>
        /// <param name="savePath">输入路径</param>
        /// <param name="quality">压缩质量(1~100)数字越小压缩比率越大(</param>
        /// <returns></returns>
        public static bool Compress(Image inImage, ImageFormat rawFormat, string savePath, int quality=100)
        {
            EncoderParameters ep = new EncoderParameters();
            long[] qualitys = new long[1];
            qualitys[0] = quality;//设置压缩的比例1-100    
            EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, qualitys);
            ep.Param[0] = encoderParameter;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    inImage.Save(savePath, jpegICIinfo, ep);
                }
                else
                {
                    inImage.Save(savePath, rawFormat);
                }
                return true;
            }
            catch {
                return false;
            }
            finally
            {
                inImage.Dispose();
            }
        }
    }
}