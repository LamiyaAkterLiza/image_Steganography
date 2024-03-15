using ImageSteganographySusmita;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSteganographyProject
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public Bitmap SelectedCannyImage;
        public Bitmap SelectedCannyImageEx;
        public string selectCoverImagePathForEmbed { get; set; }
        public string selectStegoImagePathForEmbedModelP { get; set; }
        public string selectStegoImagePathForEmbedModel_8 { get; set; }
        public string selectStegoImagePathForEmbedModelXor { get; set; }
        public string selectStegoImagePathForExtract { get; set; }
        private void btnLoadCover_Click(object sender, EventArgs e)
        {
            try
            {
                int threshold_value = 0;
                if (String.IsNullOrEmpty(txtThresoldValueEmbedding.Text.Trim()))
                {
                    MessageBox.Show("You have to provide threshold value first!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                threshold_value = Convert.ToInt32(txtThresoldValueEmbedding.Text.Trim());

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

                Bitmap bitmap = null;
                if (File.Exists(fileWav))
                {
                    bitmap = new Bitmap(fileWav);
                    //Cover_Image = bitmap;
                    pictureBoxCover.Image = bitmap;
                    pictureBoxCover.SizeMode = PictureBoxSizeMode.StretchImage;
                    selectCoverImagePathForEmbed = fileWav;
                }

                /*SobelEdgeDetectorHelper sobelEdgeDetectorHelper = new SobelEdgeDetectorHelper(SobelEdgeDetectorHelper.FilterType.NoEdgeDetection, new Bitmap(selectCoverImagePathForEmbed));
                sobelEdgeDetectorHelper.ConvertToGrayScale();
                Bitmap gray_image = sobelEdgeDetectorHelper.Bmp;
                sobelEdgeDetectorHelper = new SobelEdgeDetectorHelper(SobelEdgeDetectorHelper.FilterType.SobelFilter, sobelEdgeDetectorHelper.Bmp);
                sobelEdgeDetectorHelper.Threshold = threshold_value;
                sobelEdgeDetectorHelper.ApplyFilter();

                pictureBoxSetgo.Image = sobelEdgeDetectorHelper.Bmp;
                pictureBoxSetgo.SizeMode = PictureBoxSizeMode.StretchImage;

                SelectedCannyImage = gray_image;

                //Find the pixels from canny
                SelectedWhite_pixels.Clear();
                SelectedBlack_pixels.Clear();
                FindPixels(gray_image);*/

                FindPixelsCircleBlocks(bitmap, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //public Bitmap Cover_Image;
        public List<Tuple<int, int>> ImageBlockInfo;
        public int MidPointCircleIteration;
        public List<Tuple<int, int>> SelectedPixels = new List<Tuple<int, int>>();

        private void FindPixelsCircleBlocks(Bitmap cover_image, int CoverOrStego) 
        {
            try
            {
                MidPointCircleIteration = 0;

                ImageBlockInfo = new List<Tuple<int, int>>();

                var imgarray = new Image[9];

                var img = cover_image;
                int imgHeight = cover_image.Height / 3;
                int imgWidth = cover_image.Width / 3;

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
                    if (CoverOrStego == 0)
                        image.Save(Path.GetDirectoryName(selectCoverImagePathForEmbed) + @"\" + i_count + "C.png");
                    else
                        image.Save(Path.GetDirectoryName(selectCoverImagePathForEmbed) + @"\" + i_count + "S.png");

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
                SelectedPixels.Clear();
                Bitmap PixelSelectionsImage = new Bitmap(cover_image.Width, cover_image.Height);
                foreach (var block in AllBlocksSelectedPixels)
                {
                    foreach (var pixels in block)
                    {
                        SelectedPixels.Add(pixels);

                        PixelSelectionsImage.SetPixel(pixels.Item1, pixels.Item2, cover_image.GetPixel(pixels.Item1, pixels.Item2));
                    }
                }

                

                if (CoverOrStego == 0)
                {
                    pictureBoxSetgo.Image = PixelSelectionsImage;
                    pictureBoxSetgo.SizeMode = PictureBoxSizeMode.StretchImage;
                    PixelSelectionsImage.Save(Path.GetDirectoryName(selectCoverImagePathForEmbed) + @"\SelectedPixelsCover.png");
                }
                else
                {
                    pictureBoxStegoExtractEdge.Image = PixelSelectionsImage;
                    pictureBoxStegoExtractEdge.SizeMode = PictureBoxSizeMode.StretchImage;
                    PixelSelectionsImage.Save(Path.GetDirectoryName(selectCoverImagePathForEmbed) + @"\SelectedPixelsStego.png");
                }
                

                lblCirclePixelSelctionInfo.Text = $"Selected Pixels Info: {SelectedPixels.Count}/{cover_image.Height* cover_image.Width}; {Math.Round((SelectedPixels.Count * 100.0) / (cover_image.Height * cover_image.Width))}%; MaxCapacity:  {(SelectedPixels.Count * 3) / 8}bytes";
            }
            catch (Exception ex)
            {

            
            }
        }

        public static Point Center(Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2,
                rect.Top + rect.Height / 2);
        }

        /*public List<Tuple<int, int>> SelectedWhite_pixels = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> SelectedBlack_pixels = new List<Tuple<int, int>>();
        private void FindPixels(Bitmap gray_image)
        {
            try
            {
                int blackPixel = 0;
                int whitePixel = 0;
                double totalPixels = gray_image.Height * gray_image.Width;

                int algo = 0;
                if (metroRadioButtonEvenPair.Checked == true)
                    algo = 0; //White Region
                else
                    algo = 1; //black Region

                for (int i = 0; i < gray_image.Height; i++)
                {
                    for (int j = 0; j < gray_image.Width; j++)
                    {
                        Color color = gray_image.GetPixel(i, j);
                        if (color.R <= 0)
                        {
                            blackPixel++;
                            SelectedBlack_pixels.Add(new Tuple<int, int>(i, j));
                        }
                        else
                        {
                            whitePixel++;
                            SelectedWhite_pixels.Add(new Tuple<int, int>(i, j));

                        }
                    }
                }

                lblBlackRegionInfoEmbed.Text = $"{blackPixel}/{totalPixels}; {Math.Round((blackPixel * 100) / totalPixels)}%; MaxCapacity:  {(blackPixel * 3) / 8}bytes";
                lblWhiteRegionInfoEmbed.Text = $"{whitePixel}/{totalPixels}; {Math.Round((whitePixel * 100) / totalPixels)}%; MaxCapacity:  {(whitePixel * 3) / 8}Bytes";
            }
            catch (Exception ex)
            {

            }
        }*/


        /*public List<Tuple<int, int>> SelectedWhite_pixelsEx = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> SelectedBlack_pixelsEx = new List<Tuple<int, int>>();
        private void FindPixelsExtract(Bitmap gray_image)
        {
            try
            {
                int blackPixel = 0;
                int whitePixel = 0;
                double totalPixels = gray_image.Height * gray_image.Width;

                int algo = 0;
                if (metroRadioButtonEvenPair.Checked == true)
                    algo = 0; //White Region
                else
                    algo = 1; //black Region

                for (int i = 0; i < gray_image.Height; i++)
                {
                    for (int j = 0; j < gray_image.Width; j++)
                    {
                        Color color = gray_image.GetPixel(i, j);
                        if (color.R <= 0)
                        {
                            blackPixel++;
                            SelectedBlack_pixelsEx.Add(new Tuple<int, int>(i, j));
                        }
                        else
                        {
                            whitePixel++;
                            SelectedWhite_pixelsEx.Add(new Tuple<int, int>(i, j));

                        }
                    }
                }

                lblExtractBlackRegion.Text = $"{blackPixel}/{totalPixels}; {Math.Round((blackPixel * 100) / totalPixels)}%; MaxCapacity: {(blackPixel * 3) / 8}bytes";
                lblExtractWhiteRegion.Text = $"{whitePixel}/{totalPixels}; {Math.Round((whitePixel * 100) / totalPixels)}%; MaxCapacity: {(whitePixel * 3) / 8}bytes";
            }
            catch (Exception ex)
            {

            }
        }*/

        private void txtEmbed_TextChanged(object sender, EventArgs e)
        {
            label1.Text = txtEmbed.Text.Trim().Count().ToString();
        }

        private void btnEmbed_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to hide message into selected cover image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (selectCoverImagePathForEmbed == null && checkedListBoxEmbed.CheckedItems.Count < 1 && txtEmbed.Text.Trim() == null)
                    {
                        MessageBox.Show("Select Cover Image First", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (metroRadioButtonEvenOdd.Checked == false && metroRadioButtonEvenPair.Checked == false)
                    {
                        MessageBox.Show("Select a pixel filtering algo First", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int algo = 0;
                    if (metroRadioButtonEvenPair.Checked == true)
                        algo = 0;
                    else if (metroRadioButtonEvenOdd.Checked == true)
                        algo = 1;


                    foreach (var item in checkedListBoxEmbed.CheckedItems)
                    {
                        if (item.ToString().Contains("Proposed Model"))
                        {
                            string stegoFileAddress = SelectDestinationToSaveStegoImageFile("Proposed Model");
                            Stopwatch timer = new Stopwatch();
                            timer.Start();
                            selectStegoImagePathForEmbedModelP = stegoFileAddress;
                            Bitmap inputCoverImg = new Bitmap(selectCoverImagePathForEmbed);


                            //List<Tuple<int, int>> coveredFiltered_pixels = inputCoverImg != null ? EdgeDetectionPairOdd(inputCoverImg, algo) : null;
                            List<Tuple<int, int>> coveredFiltered_pixels = new List<Tuple<int, int>>();
                            //if (algo == 0)
                            //    coveredFiltered_pixels = SelectedWhite_pixels;
                            //else if(algo == 1)
                            //    coveredFiltered_pixels = SelectedBlack_pixels;
                            coveredFiltered_pixels = SelectedPixels;



                            ProposedAlgorithm proposedAlgorithm = new ProposedAlgorithm();
                            string proposedModelHidingStatus = proposedAlgorithm.HideMessage(txtEmbed.Text.Trim(), selectStegoImagePathForEmbedModelP, selectCoverImagePathForEmbed, coveredFiltered_pixels);
                            var proposedModelImageQualityMatrics = proposedAlgorithm.CheckValidation(selectCoverImagePathForEmbed, selectStegoImagePathForEmbedModelP);
                            if (proposedModelHidingStatus.Contains("Success"))
                            {
                                Bitmap bitmap = new Bitmap(selectStegoImagePathForEmbedModelP);
                                pictureBoxCover.Image = bitmap;
                                pictureBoxCover.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            timer.Stop();
                            TimeSpan timeTaken = timer.Elapsed;
                            this.dataGridViewImageQualityMatrics.Rows.Add("Proposed Model", label1.Text.Trim(), $"{inputCoverImg.Width}X{inputCoverImg.Height}", proposedModelImageQualityMatrics.Item1, proposedModelImageQualityMatrics.Item2, proposedModelImageQualityMatrics.Item3, timeTaken.Milliseconds);
                            Console.WriteLine($"Proposed Model {label1.Text.Trim()} {inputCoverImg.Width}X{inputCoverImg.Height} {proposedModelImageQualityMatrics.Item1} {proposedModelImageQualityMatrics.Item2} {proposedModelImageQualityMatrics.Item3} {timeTaken.Milliseconds}");
                        }
                        if (item.ToString().Contains("8 Directional Model"))
                        {
                            string stegoFileAddress = SelectDestinationToSaveStegoImageFile("8 Directional Model");
                            Stopwatch timer = new Stopwatch();
                            timer.Start();
                            selectStegoImagePathForEmbedModel_8 = stegoFileAddress;
                            _8DirBasedAlgorithm _8DirBasedAlgorithm = new _8DirBasedAlgorithm();
                            _8DirBasedAlgorithm.HideMessage(txtEmbed.Text.Trim(), selectStegoImagePathForEmbedModel_8, selectCoverImagePathForEmbed);
                            var proposedModelImageQualityMatrics = _8DirBasedAlgorithm.CheckValidation(selectCoverImagePathForEmbed, selectStegoImagePathForEmbedModel_8);
                            Bitmap bitmap = new Bitmap(selectStegoImagePathForEmbedModel_8);
                            pictureBoxCover.Image = bitmap;
                            pictureBoxCover.SizeMode = PictureBoxSizeMode.StretchImage;
                            timer.Stop();
                            TimeSpan timeTaken = timer.Elapsed;
                            this.dataGridViewImageQualityMatrics.Rows.Add("8 Directional Model", label1.Text.Trim(), $"{bitmap.Width}X{bitmap.Height}", proposedModelImageQualityMatrics.Item1, proposedModelImageQualityMatrics.Item2, proposedModelImageQualityMatrics.Item3, timeTaken.Milliseconds);
                            Console.WriteLine($"8 Directional Model {label1.Text.Trim()} {bitmap.Width}X{bitmap.Height} {proposedModelImageQualityMatrics.Item1} {proposedModelImageQualityMatrics.Item2} {proposedModelImageQualityMatrics.Item3} {timeTaken.Milliseconds}");
                        }
                        if (item.ToString().Contains("XOR Sub Model"))
                        {
                            string stegoFileAddress = SelectDestinationToSaveStegoImageFile("XOR Sub Model");

                            Stopwatch timer = new Stopwatch();
                            timer.Start();
                            selectStegoImagePathForEmbedModel_8 = stegoFileAddress;
                            XORBasedTechnique XORBasedTechnique = new XORBasedTechnique();
                            XORBasedTechnique.HideMessage(txtEmbed.Text.Trim(), selectStegoImagePathForEmbedModel_8, selectCoverImagePathForEmbed);
                            var proposedModelImageQualityMatrics = XORBasedTechnique.CheckValidation(selectCoverImagePathForEmbed, selectStegoImagePathForEmbedModel_8);
                            Bitmap bitmap = new Bitmap(selectStegoImagePathForEmbedModel_8);
                            pictureBoxCover.Image = bitmap;
                            pictureBoxCover.SizeMode = PictureBoxSizeMode.StretchImage;
                            timer.Stop();
                            TimeSpan timeTaken = timer.Elapsed;
                            this.dataGridViewImageQualityMatrics.Rows.Add("XOR Sub Model", label1.Text.Trim(), $"{bitmap.Width}X{bitmap.Height}", proposedModelImageQualityMatrics.Item1, proposedModelImageQualityMatrics.Item2, proposedModelImageQualityMatrics.Item3, timeTaken.Milliseconds);
                            Console.WriteLine($"XOR Sub Model {label1.Text.Trim()} {bitmap.Width}X{bitmap.Height} {proposedModelImageQualityMatrics.Item1} {proposedModelImageQualityMatrics.Item2} {proposedModelImageQualityMatrics.Item3} {timeTaken.Milliseconds}");
                        }
                        if (item.ToString().Contains("Nobel Encryption"))
                        {
                            MessageBox.Show("", "This model is not implemented", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //string stegoFileAddress = SelectDestinationToSaveStegoImageFile("Nobel Encryption");

                            //Stopwatch timer = new Stopwatch();
                            //timer.Start();
                            //selectStegoImagePathForEmbedModel_8 = stegoFileAddress;
                            //XORBasedTechnique XORBasedTechnique = new XORBasedTechnique();
                            //XORBasedTechnique.HideMessage(txtEmbed.Text.Trim(), selectStegoImagePathForEmbedModel_8, selectCoverImagePathForEmbed);
                            //var proposedModelImageQualityMatrics = XORBasedTechnique.CheckValidation(selectCoverImagePathForEmbed, selectStegoImagePathForEmbedModel_8);
                            //Bitmap bitmap = new Bitmap(selectStegoImagePathForEmbedModel_8);
                            //pictureBoxCover.Image = bitmap;
                            //pictureBoxCover.SizeMode = PictureBoxSizeMode.StretchImage;
                            //timer.Stop();
                            //TimeSpan timeTaken = timer.Elapsed;
                            //this.dataGridViewImageQualityMatrics.Rows.Add("Nobel Encryption", label1.Text.Trim(), $"{bitmap.Width}X{bitmap.Height}", proposedModelImageQualityMatrics.Item1, proposedModelImageQualityMatrics.Item2, proposedModelImageQualityMatrics.Item3, timeTaken.Milliseconds);
                            //Console.WriteLine($"Nobel Encryption {label1.Text.Trim()} {bitmap.Width}X{bitmap.Height} {proposedModelImageQualityMatrics.Item1} {proposedModelImageQualityMatrics.Item2} {proposedModelImageQualityMatrics.Item3} {timeTaken.Milliseconds}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SelectDestinationToSaveStegoImageFile(string model)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = $"Where you going to save your stego image file for ({model})?",
                Filter = "Image file (*.png)|*.png",
                FileName = $"{model}Stego{Path.GetFileName(selectCoverImagePathForEmbed)}"
            };
            string stegoFileAddress = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                stegoFileAddress = saveFileDialog.FileName;

            if (String.IsNullOrEmpty(stegoFileAddress))
                throw new Exception("Save file is not be empty. Try again later!");
            return stegoFileAddress;
        }

        public List<Tuple<int, int>> EdgeDetectionPairOdd(Bitmap inputCoverImg, int algo = 0)
        {
            List<Tuple<int, int>> selected_pixels = new List<Tuple<int, int>>();
            FilteringPixels(selected_pixels, inputCoverImg, algo);
            return selected_pixels;
        }

        private void FilteringPixels(List<Tuple<int, int>> selected_pixels, Bitmap bmp, int algo = 0)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    var r = Convert.ToString(bmp.GetPixel(x, y).R, 2).PadLeft(8, '0');
                    if (r[0] == r[1])
                    {
                        if (algo == 0)
                            selected_pixels.Add(new Tuple<int, int>(x, y));
                    }
                    else
                    {
                        if (algo != 0)
                            selected_pixels.Add(new Tuple<int, int>(x, y));
                    }

                }
            }
        }

        private void btnLoadStego_Click(object sender, EventArgs e)
        {
            try
            {
                int threshold_value = 0;
                if (String.IsNullOrEmpty(txtThresoldValueEmbedding.Text.Trim()))
                {
                    MessageBox.Show("You have to provide threshold value first!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                threshold_value = Convert.ToInt32(txtThresoldValueRetrieving.Text.Trim());

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

                Bitmap bitmap = null;
                if (File.Exists(fileWav))
                {
                    bitmap = new Bitmap(fileWav);
                    pictureBoxStegoExtract.Image = bitmap;
                    pictureBoxStegoExtract.SizeMode = PictureBoxSizeMode.StretchImage;
                    selectStegoImagePathForExtract = fileWav;
                }

                /*sobelEdgeDetectorHelper = new SobelEdgeDetectorHelper(SobelEdgeDetectorHelper.FilterType.NoEdgeDetection, new Bitmap(selectStegoImagePathForExtract));
                sobelEdgeDetectorHelper.ConvertToGrayScale();
                Bitmap gray_image = sobelEdgeDetectorHelper.Bmp;
                sobelEdgeDetectorHelper = new SobelEdgeDetectorHelper(SobelEdgeDetectorHelper.FilterType.SobelFilter, sobelEdgeDetectorHelper.Bmp);
                sobelEdgeDetectorHelper.Threshold = threshold_value;
                sobelEdgeDetectorHelper.ApplyFilter();

                pictureBoxStegoExtractEdge.Image = sobelEdgeDetectorHelper.Bmp;
                pictureBoxStegoExtractEdge.SizeMode = PictureBoxSizeMode.StretchImage;

                SelectedCannyImageEx = gray_image;

                //Find the pixels from canny
                SelectedWhite_pixelsEx.Clear();
                SelectedBlack_pixelsEx.Clear();
                FindPixelsExtract(gray_image);*/

                FindPixelsCircleBlocks(bitmap, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to extract message from selected stego image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (checkedListBoxExtract.Items.Count > 1 && selectStegoImagePathForExtract == null)
                    {
                        MessageBox.Show("Select cover image and Select only one technique", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int algo = 0;
                    if (metroRadioButtonEvenExtract.Checked == true)
                        algo = 0;
                    else if (metroRadioButtonOddExtract.Checked == true)
                        algo = 1;

                    foreach (var item in checkedListBoxExtract.CheckedItems)
                    {
                        if (item.ToString().Contains("Proposed Model"))
                        {
                            Bitmap inputCoverImg = new Bitmap(selectStegoImagePathForExtract);
                            //List<Tuple<int, int>> coveredFiltered_pixels = inputCoverImg != null ? EdgeDetectionPairOdd(inputCoverImg, algo) : null;
                            List<Tuple<int, int>> coveredFiltered_pixels = new List<Tuple<int, int>>();
                            //if (algo == 0)
                            //    coveredFiltered_pixels = SelectedWhite_pixelsEx;
                            //else if (algo == 1)
                            //    coveredFiltered_pixels = SelectedBlack_pixelsEx;

                            coveredFiltered_pixels = SelectedPixels;

                            ProposedAlgorithm proposedAlgorithm = new ProposedAlgorithm();
                            string secretMessage = proposedAlgorithm.ExtractSecretMessage(selectStegoImagePathForExtract, coveredFiltered_pixels);
                            txtExtract.Text = secretMessage;
                        }
                        if (item.ToString().Contains("8 Directional Model"))
                        {
                            _8DirBasedAlgorithm _8DirBasedAlgorithm = new _8DirBasedAlgorithm();
                            string secretMessage = _8DirBasedAlgorithm.ExtractSecretMessage(selectStegoImagePathForExtract);
                            txtExtract.Text = secretMessage;
                        }
                        if (item.ToString().Contains("XOR Sub Model"))
                        {
                            XORBasedTechnique XORBasedTechnique = new XORBasedTechnique();
                            string secretMessage = XORBasedTechnique.ExtractSecretMessage(selectStegoImagePathForExtract);
                            txtExtract.Text = secretMessage;
                        }
                        if (item.ToString().Contains("Nobel Encryption"))
                        {
                            MessageBox.Show("It is not implemented!");
                            //XORBasedTechnique XORBasedTechnique = new XORBasedTechnique();
                            //string secretMessage = XORBasedTechnique.ExtractSecretMessage(selectStegoImagePathForExtract);
                            //txtExtract.Text = secretMessage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDownloadCannyImage_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Title = "Where you going to save your canny image?",
                    Filter = "Image file (*.png)|*.png",
                    FileName = "Canny"
                };
                string FileAddress = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    FileAddress = saveFileDialog.FileName;

                if (String.IsNullOrEmpty(FileAddress))
                    throw new Exception("Save file is not be empty. Try again later!");

                SelectedCannyImage.Save(FileAddress, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show("", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExCannyDownload_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Title = "Where you going to save your canny image?",
                    Filter = "Image file (*.png)|*.png",
                    FileName = "Canny"
                };
                string FileAddress = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    FileAddress = saveFileDialog.FileName;

                if (String.IsNullOrEmpty(FileAddress))
                    throw new Exception("Save file is not be empty. Try again later!");

                SelectedCannyImageEx.Save(FileAddress, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show("", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtExtract_TextChanged(object sender, EventArgs e)
        {
            label4.Text = txtEmbed.Text.Trim().Count().ToString();
        }
    }
}
