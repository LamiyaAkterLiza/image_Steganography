using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSteganographySusmita
{
    public partial class ImageMidPointGeneration : Form
    {
        public ImageMidPointGeneration()
        {
            InitializeComponent();
        }

        public Bitmap Cover_Image;
        List<Tuple<int, int>> ImageBlockInfo;
        public int MidPointCircleIteration = 0;

        private void ImageMidPointGeneration_Load(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Browse PNG File";
            openFileDialog.Filter = "Image file (*.png)|*.png";
            openFileDialog.Multiselect = false;
            string fileWav = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileWav = openFileDialog.FileName;
            }
            if (String.IsNullOrEmpty(fileWav))
                throw new Exception("Please select a png file....");
            Cover_Image = new Bitmap(fileWav);
            pictureBox1.Image = Cover_Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageCut();
            //MidPointCircle.midPointCircleDraw();
        }

        private void ImageCut()
        {
            ImageBlockInfo = new List<Tuple<int, int>>();

            var imgarray = new Image[9];

            var img = Cover_Image;
            int imgHeight = Cover_Image.Height / 3;
            int imgWidth = Cover_Image.Width / 3;

            if (imgWidth >= imgHeight)
                MidPointCircleIteration = imgHeight / 4 - 1;
            else
                MidPointCircleIteration = imgWidth / 4 - 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var index = i * 3 + j;
                    imgarray[index] = new Bitmap(imgWidth, imgHeight);
                    var graphics = Graphics.FromImage(imgarray[index]);

                    var centerOfEachBlock = Center(new Rectangle(i * imgWidth, j * imgHeight, imgWidth, imgHeight));
                    ImageBlockInfo.Add(new Tuple<int, int>(centerOfEachBlock.X, centerOfEachBlock.Y));

                    graphics.DrawImage(img, new Rectangle(0, 0, imgWidth, imgHeight), new Rectangle(i * imgWidth, j * imgHeight, imgWidth, imgHeight), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }

            int i_count = 1;
            foreach (var image in imgarray)
            {
                image.Save(@"E:\Research\2023\Image Steganography\Afjal Sarower\Test Images\" + i_count + ".png");
                i_count++;
            }

            List<List<Tuple<int, int>>> AllBlocksSelectedPixels = new List<List<Tuple<int, int>>>();

            foreach (var block in ImageBlockInfo)
            {
                for (int i = MidPointCircleIteration; i >= 1; i--)
                {
                    MidPointCircle midPointCircle = new MidPointCircle();
                    midPointCircle.midPointCircleDraw(block.Item1, block.Item2, i * 2);

                    AllBlocksSelectedPixels.Add(midPointCircle.PixelLocations);
                }
            }

            //create image with circle of blocks
            Bitmap PixelSelectionsImage = new Bitmap(Cover_Image.Width, Cover_Image.Height);
            foreach (var block in AllBlocksSelectedPixels)
            {
                foreach (var pixels in block)
                {
                    PixelSelectionsImage.SetPixel(pixels.Item1, pixels.Item2, Cover_Image.GetPixel(pixels.Item1, pixels.Item2));
                }
            }
            PixelSelectionsImage.Save(@"E:\Research\2023\Image Steganography\Afjal Sarower\Test Images\SelectedPixels.png");

            pictureBox2.Image = PixelSelectionsImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public static Point Center(Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2,
                rect.Top + rect.Height / 2);
        }
    }
}
