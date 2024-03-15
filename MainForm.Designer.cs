namespace ImageSteganographyProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroRadioButtonEvenOdd = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButtonEvenPair = new MetroFramework.Controls.MetroRadioButton();
            this.checkedListBoxEmbed = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEmbed = new MetroFramework.Controls.MetroButton();
            this.txtEmbed = new MetroFramework.Controls.MetroTextBox();
            this.btnLoadCover = new MetroFramework.Controls.MetroButton();
            this.pictureBoxSetgo = new System.Windows.Forms.PictureBox();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroRadioButtonOddExtract = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButtonEvenExtract = new MetroFramework.Controls.MetroRadioButton();
            this.checkedListBoxExtract = new System.Windows.Forms.CheckedListBox();
            this.btnExtract = new MetroFramework.Controls.MetroButton();
            this.txtExtract = new MetroFramework.Controls.MetroTextBox();
            this.btnLoadStego = new MetroFramework.Controls.MetroButton();
            this.pictureBoxStegoExtract = new System.Windows.Forms.PictureBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtThresoldValueEmbedding = new System.Windows.Forms.TextBox();
            this.txtThresoldValueRetrieving = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDownloadCannyImage = new MetroFramework.Controls.MetroButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewImageQualityMatrics = new System.Windows.Forms.DataGridView();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RMSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecutionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblWhiteRegionInfoEmbed = new System.Windows.Forms.Label();
            this.lblBlackRegionInfoEmbed = new System.Windows.Forms.Label();
            this.pictureBoxStegoExtractEdge = new System.Windows.Forms.PictureBox();
            this.lblExtractBlackRegion = new System.Windows.Forms.Label();
            this.lblExtractWhiteRegion = new System.Windows.Forms.Label();
            this.btnExCannyDownload = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.lblCirclePixelSelctionInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSetgo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStegoExtract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImageQualityMatrics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStegoExtractEdge)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroRadioButtonEvenOdd
            // 
            this.metroRadioButtonEvenOdd.AutoSize = true;
            this.metroRadioButtonEvenOdd.Location = new System.Drawing.Point(3, 25);
            this.metroRadioButtonEvenOdd.Name = "metroRadioButtonEvenOdd";
            this.metroRadioButtonEvenOdd.Size = new System.Drawing.Size(91, 15);
            this.metroRadioButtonEvenOdd.TabIndex = 9;
            this.metroRadioButtonEvenOdd.Text = "Black Region";
            this.metroRadioButtonEvenOdd.UseVisualStyleBackColor = true;
            // 
            // metroRadioButtonEvenPair
            // 
            this.metroRadioButtonEvenPair.AutoSize = true;
            this.metroRadioButtonEvenPair.Checked = true;
            this.metroRadioButtonEvenPair.Location = new System.Drawing.Point(3, 4);
            this.metroRadioButtonEvenPair.Name = "metroRadioButtonEvenPair";
            this.metroRadioButtonEvenPair.Size = new System.Drawing.Size(94, 15);
            this.metroRadioButtonEvenPair.TabIndex = 8;
            this.metroRadioButtonEvenPair.TabStop = true;
            this.metroRadioButtonEvenPair.Text = "White Region";
            this.metroRadioButtonEvenPair.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxEmbed
            // 
            this.checkedListBoxEmbed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxEmbed.CheckOnClick = true;
            this.checkedListBoxEmbed.FormattingEnabled = true;
            this.checkedListBoxEmbed.Items.AddRange(new object[] {
            "Proposed Model",
            "8 Directional Model",
            "XOR Sub Model",
            "Nobel Encryption"});
            this.checkedListBoxEmbed.Location = new System.Drawing.Point(12, 270);
            this.checkedListBoxEmbed.Name = "checkedListBoxEmbed";
            this.checkedListBoxEmbed.Size = new System.Drawing.Size(155, 137);
            this.checkedListBoxEmbed.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(113, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Letter Count";
            // 
            // btnEmbed
            // 
            this.btnEmbed.Location = new System.Drawing.Point(322, 230);
            this.btnEmbed.Name = "btnEmbed";
            this.btnEmbed.Size = new System.Drawing.Size(133, 36);
            this.btnEmbed.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnEmbed.TabIndex = 5;
            this.btnEmbed.Text = "Embed";
            this.btnEmbed.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnEmbed.Click += new System.EventHandler(this.btnEmbed_Click);
            // 
            // txtEmbed
            // 
            this.txtEmbed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmbed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtEmbed.Location = new System.Drawing.Point(113, 31);
            this.txtEmbed.Multiline = true;
            this.txtEmbed.Name = "txtEmbed";
            this.txtEmbed.Size = new System.Drawing.Size(342, 193);
            this.txtEmbed.TabIndex = 4;
            this.txtEmbed.TextChanged += new System.EventHandler(this.txtEmbed_TextChanged);
            // 
            // btnLoadCover
            // 
            this.btnLoadCover.Location = new System.Drawing.Point(10, 31);
            this.btnLoadCover.Name = "btnLoadCover";
            this.btnLoadCover.Size = new System.Drawing.Size(97, 193);
            this.btnLoadCover.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnLoadCover.TabIndex = 3;
            this.btnLoadCover.Text = "Load Cover Img";
            this.btnLoadCover.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnLoadCover.Click += new System.EventHandler(this.btnLoadCover_Click);
            // 
            // pictureBoxSetgo
            // 
            this.pictureBoxSetgo.BackColor = System.Drawing.Color.White;
            this.pictureBoxSetgo.Location = new System.Drawing.Point(322, 270);
            this.pictureBoxSetgo.Name = "pictureBoxSetgo";
            this.pictureBoxSetgo.Size = new System.Drawing.Size(133, 134);
            this.pictureBoxSetgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSetgo.TabIndex = 2;
            this.pictureBoxSetgo.TabStop = false;
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.Color.White;
            this.pictureBoxCover.Location = new System.Drawing.Point(173, 270);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(143, 134);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 1;
            this.pictureBoxCover.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.metroLabel1.Location = new System.Drawing.Point(227, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(112, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Embedding Panel";
            // 
            // metroRadioButtonOddExtract
            // 
            this.metroRadioButtonOddExtract.AutoSize = true;
            this.metroRadioButtonOddExtract.Location = new System.Drawing.Point(3, 27);
            this.metroRadioButtonOddExtract.Name = "metroRadioButtonOddExtract";
            this.metroRadioButtonOddExtract.Size = new System.Drawing.Size(91, 15);
            this.metroRadioButtonOddExtract.TabIndex = 14;
            this.metroRadioButtonOddExtract.Text = "Black Region";
            this.metroRadioButtonOddExtract.UseVisualStyleBackColor = true;
            // 
            // metroRadioButtonEvenExtract
            // 
            this.metroRadioButtonEvenExtract.AutoSize = true;
            this.metroRadioButtonEvenExtract.Checked = true;
            this.metroRadioButtonEvenExtract.Location = new System.Drawing.Point(3, 6);
            this.metroRadioButtonEvenExtract.Name = "metroRadioButtonEvenExtract";
            this.metroRadioButtonEvenExtract.Size = new System.Drawing.Size(94, 15);
            this.metroRadioButtonEvenExtract.TabIndex = 13;
            this.metroRadioButtonEvenExtract.TabStop = true;
            this.metroRadioButtonEvenExtract.Text = "White Region";
            this.metroRadioButtonEvenExtract.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxExtract
            // 
            this.checkedListBoxExtract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxExtract.CheckOnClick = true;
            this.checkedListBoxExtract.FormattingEnabled = true;
            this.checkedListBoxExtract.Items.AddRange(new object[] {
            "Proposed Model",
            "8 Directional Model",
            "XOR Sub Model",
            "Nobel Encryption"});
            this.checkedListBoxExtract.Location = new System.Drawing.Point(514, 268);
            this.checkedListBoxExtract.Name = "checkedListBoxExtract";
            this.checkedListBoxExtract.Size = new System.Drawing.Size(155, 137);
            this.checkedListBoxExtract.TabIndex = 12;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(838, 230);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(125, 36);
            this.btnExtract.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnExtract.TabIndex = 11;
            this.btnExtract.Text = "Extract";
            this.btnExtract.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // txtExtract
            // 
            this.txtExtract.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExtract.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtExtract.Location = new System.Drawing.Point(620, 31);
            this.txtExtract.Multiline = true;
            this.txtExtract.Name = "txtExtract";
            this.txtExtract.Size = new System.Drawing.Size(343, 193);
            this.txtExtract.TabIndex = 10;
            this.txtExtract.TextChanged += new System.EventHandler(this.txtExtract_TextChanged);
            // 
            // btnLoadStego
            // 
            this.btnLoadStego.Location = new System.Drawing.Point(513, 31);
            this.btnLoadStego.Name = "btnLoadStego";
            this.btnLoadStego.Size = new System.Drawing.Size(97, 193);
            this.btnLoadStego.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnLoadStego.TabIndex = 9;
            this.btnLoadStego.Text = "Load Stego Img";
            this.btnLoadStego.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnLoadStego.Click += new System.EventHandler(this.btnLoadStego_Click);
            // 
            // pictureBoxStegoExtract
            // 
            this.pictureBoxStegoExtract.BackColor = System.Drawing.Color.White;
            this.pictureBoxStegoExtract.Location = new System.Drawing.Point(680, 268);
            this.pictureBoxStegoExtract.Name = "pictureBoxStegoExtract";
            this.pictureBoxStegoExtract.Size = new System.Drawing.Size(135, 132);
            this.pictureBoxStegoExtract.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStegoExtract.TabIndex = 8;
            this.pictureBoxStegoExtract.TabStop = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.metroLabel2.Location = new System.Drawing.Point(771, 9);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(101, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Extracting Panel";
            // 
            // txtThresoldValueEmbedding
            // 
            this.txtThresoldValueEmbedding.Location = new System.Drawing.Point(15, 490);
            this.txtThresoldValueEmbedding.Name = "txtThresoldValueEmbedding";
            this.txtThresoldValueEmbedding.Size = new System.Drawing.Size(157, 20);
            this.txtThresoldValueEmbedding.TabIndex = 15;
            this.txtThresoldValueEmbedding.Text = "100";
            this.txtThresoldValueEmbedding.Visible = false;
            // 
            // txtThresoldValueRetrieving
            // 
            this.txtThresoldValueRetrieving.Location = new System.Drawing.Point(514, 490);
            this.txtThresoldValueRetrieving.Name = "txtThresoldValueRetrieving";
            this.txtThresoldValueRetrieving.Size = new System.Drawing.Size(157, 20);
            this.txtThresoldValueRetrieving.TabIndex = 16;
            this.txtThresoldValueRetrieving.Text = "100";
            this.txtThresoldValueRetrieving.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(15, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Thresold Value";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(511, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Thresold Value";
            this.label3.Visible = false;
            // 
            // btnDownloadCannyImage
            // 
            this.btnDownloadCannyImage.Location = new System.Drawing.Point(391, 410);
            this.btnDownloadCannyImage.Name = "btnDownloadCannyImage";
            this.btnDownloadCannyImage.Size = new System.Drawing.Size(64, 30);
            this.btnDownloadCannyImage.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnDownloadCannyImage.TabIndex = 19;
            this.btnDownloadCannyImage.Text = "Download";
            this.btnDownloadCannyImage.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnDownloadCannyImage.Click += new System.EventHandler(this.btnDownloadCannyImage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(660, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Letter Count";
            // 
            // dataGridViewImageQualityMatrics
            // 
            this.dataGridViewImageQualityMatrics.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewImageQualityMatrics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImageQualityMatrics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Model,
            this.Payload,
            this.Dimension,
            this.PSNR,
            this.MSE,
            this.RMSE,
            this.ExecutionTime});
            this.dataGridViewImageQualityMatrics.Location = new System.Drawing.Point(2, 610);
            this.dataGridViewImageQualityMatrics.Name = "dataGridViewImageQualityMatrics";
            this.dataGridViewImageQualityMatrics.Size = new System.Drawing.Size(961, 112);
            this.dataGridViewImageQualityMatrics.TabIndex = 21;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // Payload
            // 
            this.Payload.HeaderText = "Payload";
            this.Payload.Name = "Payload";
            this.Payload.ReadOnly = true;
            // 
            // Dimension
            // 
            this.Dimension.HeaderText = "Dimension";
            this.Dimension.Name = "Dimension";
            this.Dimension.ReadOnly = true;
            // 
            // PSNR
            // 
            this.PSNR.HeaderText = "PSNR";
            this.PSNR.Name = "PSNR";
            this.PSNR.ReadOnly = true;
            // 
            // MSE
            // 
            this.MSE.HeaderText = "MSE";
            this.MSE.Name = "MSE";
            this.MSE.ReadOnly = true;
            // 
            // RMSE
            // 
            this.RMSE.HeaderText = "RMSE";
            this.RMSE.Name = "RMSE";
            this.RMSE.ReadOnly = true;
            // 
            // ExecutionTime
            // 
            this.ExecutionTime.HeaderText = "ExecutionTime";
            this.ExecutionTime.Name = "ExecutionTime";
            this.ExecutionTime.ReadOnly = true;
            // 
            // lblWhiteRegionInfoEmbed
            // 
            this.lblWhiteRegionInfoEmbed.AutoSize = true;
            this.lblWhiteRegionInfoEmbed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWhiteRegionInfoEmbed.Location = new System.Drawing.Point(104, 6);
            this.lblWhiteRegionInfoEmbed.Name = "lblWhiteRegionInfoEmbed";
            this.lblWhiteRegionInfoEmbed.Size = new System.Drawing.Size(13, 13);
            this.lblWhiteRegionInfoEmbed.TabIndex = 22;
            this.lblWhiteRegionInfoEmbed.Text = "0";
            // 
            // lblBlackRegionInfoEmbed
            // 
            this.lblBlackRegionInfoEmbed.AutoSize = true;
            this.lblBlackRegionInfoEmbed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBlackRegionInfoEmbed.Location = new System.Drawing.Point(104, 27);
            this.lblBlackRegionInfoEmbed.Name = "lblBlackRegionInfoEmbed";
            this.lblBlackRegionInfoEmbed.Size = new System.Drawing.Size(13, 13);
            this.lblBlackRegionInfoEmbed.TabIndex = 23;
            this.lblBlackRegionInfoEmbed.Text = "0";
            // 
            // pictureBoxStegoExtractEdge
            // 
            this.pictureBoxStegoExtractEdge.BackColor = System.Drawing.Color.White;
            this.pictureBoxStegoExtractEdge.Location = new System.Drawing.Point(828, 268);
            this.pictureBoxStegoExtractEdge.Name = "pictureBoxStegoExtractEdge";
            this.pictureBoxStegoExtractEdge.Size = new System.Drawing.Size(135, 134);
            this.pictureBoxStegoExtractEdge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStegoExtractEdge.TabIndex = 24;
            this.pictureBoxStegoExtractEdge.TabStop = false;
            // 
            // lblExtractBlackRegion
            // 
            this.lblExtractBlackRegion.AutoSize = true;
            this.lblExtractBlackRegion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblExtractBlackRegion.Location = new System.Drawing.Point(101, 29);
            this.lblExtractBlackRegion.Name = "lblExtractBlackRegion";
            this.lblExtractBlackRegion.Size = new System.Drawing.Size(13, 13);
            this.lblExtractBlackRegion.TabIndex = 26;
            this.lblExtractBlackRegion.Text = "0";
            // 
            // lblExtractWhiteRegion
            // 
            this.lblExtractWhiteRegion.AutoSize = true;
            this.lblExtractWhiteRegion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblExtractWhiteRegion.Location = new System.Drawing.Point(101, 8);
            this.lblExtractWhiteRegion.Name = "lblExtractWhiteRegion";
            this.lblExtractWhiteRegion.Size = new System.Drawing.Size(13, 13);
            this.lblExtractWhiteRegion.TabIndex = 25;
            this.lblExtractWhiteRegion.Text = "0";
            // 
            // btnExCannyDownload
            // 
            this.btnExCannyDownload.Location = new System.Drawing.Point(899, 408);
            this.btnExCannyDownload.Name = "btnExCannyDownload";
            this.btnExCannyDownload.Size = new System.Drawing.Size(64, 30);
            this.btnExCannyDownload.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnExCannyDownload.TabIndex = 27;
            this.btnExCannyDownload.Text = "Download";
            this.btnExCannyDownload.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnExCannyDownload.Click += new System.EventHandler(this.btnExCannyDownload_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroRadioButtonEvenExtract);
            this.metroPanel1.Controls.Add(this.lblExtractBlackRegion);
            this.metroPanel1.Controls.Add(this.metroRadioButtonOddExtract);
            this.metroPanel1.Controls.Add(this.lblExtractWhiteRegion);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(514, 515);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(379, 46);
            this.metroPanel1.TabIndex = 28;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            this.metroPanel1.Visible = false;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroRadioButtonEvenPair);
            this.metroPanel2.Controls.Add(this.metroRadioButtonEvenOdd);
            this.metroPanel2.Controls.Add(this.lblBlackRegionInfoEmbed);
            this.metroPanel2.Controls.Add(this.lblWhiteRegionInfoEmbed);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(13, 512);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(375, 46);
            this.metroPanel2.TabIndex = 29;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            this.metroPanel2.Visible = false;
            // 
            // lblCirclePixelSelctionInfo
            // 
            this.lblCirclePixelSelctionInfo.AutoSize = true;
            this.lblCirclePixelSelctionInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCirclePixelSelctionInfo.Location = new System.Drawing.Point(12, 415);
            this.lblCirclePixelSelctionInfo.Name = "lblCirclePixelSelctionInfo";
            this.lblCirclePixelSelctionInfo.Size = new System.Drawing.Size(13, 13);
            this.lblCirclePixelSelctionInfo.TabIndex = 24;
            this.lblCirclePixelSelctionInfo.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 722);
            this.Controls.Add(this.lblCirclePixelSelctionInfo);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnExCannyDownload);
            this.Controls.Add(this.pictureBoxStegoExtractEdge);
            this.Controls.Add(this.dataGridViewImageQualityMatrics);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDownloadCannyImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtThresoldValueRetrieving);
            this.Controls.Add(this.txtThresoldValueEmbedding);
            this.Controls.Add(this.checkedListBoxExtract);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.txtExtract);
            this.Controls.Add(this.pictureBoxCover);
            this.Controls.Add(this.btnLoadStego);
            this.Controls.Add(this.checkedListBoxEmbed);
            this.Controls.Add(this.pictureBoxStegoExtract);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxSetgo);
            this.Controls.Add(this.btnEmbed);
            this.Controls.Add(this.btnLoadCover);
            this.Controls.Add(this.txtEmbed);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSetgo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStegoExtract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImageQualityMatrics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStegoExtractEdge)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.PictureBox pictureBoxSetgo;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private MetroFramework.Controls.MetroButton btnLoadCover;
        private MetroFramework.Controls.MetroButton btnEmbed;
        private MetroFramework.Controls.MetroTextBox txtEmbed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxEmbed;
        private System.Windows.Forms.CheckedListBox checkedListBoxExtract;
        private MetroFramework.Controls.MetroButton btnExtract;
        private MetroFramework.Controls.MetroTextBox txtExtract;
        private MetroFramework.Controls.MetroButton btnLoadStego;
        private System.Windows.Forms.PictureBox pictureBoxStegoExtract;
        private MetroFramework.Controls.MetroRadioButton metroRadioButtonEvenOdd;
        private MetroFramework.Controls.MetroRadioButton metroRadioButtonEvenPair;
        private MetroFramework.Controls.MetroRadioButton metroRadioButtonOddExtract;
        private MetroFramework.Controls.MetroRadioButton metroRadioButtonEvenExtract;
        private System.Windows.Forms.TextBox txtThresoldValueEmbedding;
        private System.Windows.Forms.TextBox txtThresoldValueRetrieving;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroButton btnDownloadCannyImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewImageQualityMatrics;
        private System.Windows.Forms.Label lblWhiteRegionInfoEmbed;
        private System.Windows.Forms.Label lblBlackRegionInfoEmbed;
        private System.Windows.Forms.PictureBox pictureBoxStegoExtractEdge;
        private System.Windows.Forms.Label lblExtractBlackRegion;
        private System.Windows.Forms.Label lblExtractWhiteRegion;
        private MetroFramework.Controls.MetroButton btnExCannyDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimension;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecutionTime;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.Label lblCirclePixelSelctionInfo;
    }
}

