namespace ImdbScrapperDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.gradientPanel2 = new ImdbScrapperDesktop.GradientPanel();
            this.btnWL = new System.Windows.Forms.Button();
            this.btnAddWL = new System.Windows.Forms.Button();
            this.btnPersonImages = new System.Windows.Forms.Button();
            this.lstbxGenres = new System.Windows.Forms.ListBox();
            this.btnMovieImages = new System.Windows.Forms.Button();
            this.lblBirthDetails = new System.Windows.Forms.Label();
            this.tbBirthDetails = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.tbReleaseDate = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pcbxImdbLogo = new System.Windows.Forms.PictureBox();
            this.lblPictureboxNotify = new System.Windows.Forms.Label();
            this.lstbxKeys = new System.Windows.Forms.ListBox();
            this.lblActorName = new System.Windows.Forms.Label();
            this.lstbxJobs = new System.Windows.Forms.ListBox();
            this.rtbActorDesc = new System.Windows.Forms.RichTextBox();
            this.pcbxActor = new System.Windows.Forms.PictureBox();
            this.pcbxMovie = new System.Windows.Forms.PictureBox();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.rtbRating = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRoles = new System.Windows.Forms.Label();
            this.lstbxRoles = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstbxActorName = new System.Windows.Forms.ListBox();
            this.lstbxDates = new System.Windows.Forms.ListBox();
            this.richMovieDescr = new System.Windows.Forms.RichTextBox();
            this.lstbxMovieNames = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxImdbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxActor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Angle = 0F;
            this.gradientPanel2.BackColor = System.Drawing.Color.White;
            this.gradientPanel2.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel2.Controls.Add(this.btnWL);
            this.gradientPanel2.Controls.Add(this.btnAddWL);
            this.gradientPanel2.Controls.Add(this.btnPersonImages);
            this.gradientPanel2.Controls.Add(this.lstbxGenres);
            this.gradientPanel2.Controls.Add(this.btnMovieImages);
            this.gradientPanel2.Controls.Add(this.lblBirthDetails);
            this.gradientPanel2.Controls.Add(this.tbBirthDetails);
            this.gradientPanel2.Controls.Add(this.lblDate);
            this.gradientPanel2.Controls.Add(this.tbReleaseDate);
            this.gradientPanel2.Controls.Add(this.pictureBox1);
            this.gradientPanel2.Controls.Add(this.pcbxImdbLogo);
            this.gradientPanel2.Controls.Add(this.lblPictureboxNotify);
            this.gradientPanel2.Controls.Add(this.lstbxKeys);
            this.gradientPanel2.Controls.Add(this.lblActorName);
            this.gradientPanel2.Controls.Add(this.lstbxJobs);
            this.gradientPanel2.Controls.Add(this.rtbActorDesc);
            this.gradientPanel2.Controls.Add(this.pcbxActor);
            this.gradientPanel2.Controls.Add(this.pcbxMovie);
            this.gradientPanel2.Controls.Add(this.lblMovieName);
            this.gradientPanel2.Controls.Add(this.rtbRating);
            this.gradientPanel2.Controls.Add(this.label7);
            this.gradientPanel2.Controls.Add(this.label6);
            this.gradientPanel2.Controls.Add(this.lblRoles);
            this.gradientPanel2.Controls.Add(this.lstbxRoles);
            this.gradientPanel2.Controls.Add(this.label4);
            this.gradientPanel2.Controls.Add(this.label3);
            this.gradientPanel2.Controls.Add(this.lstbxActorName);
            this.gradientPanel2.Controls.Add(this.lstbxDates);
            this.gradientPanel2.Controls.Add(this.richMovieDescr);
            this.gradientPanel2.Controls.Add(this.lstbxMovieNames);
            this.gradientPanel2.Controls.Add(this.btnClear);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.tbSearch);
            this.gradientPanel2.Controls.Add(this.btnSearch);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel2.ForeColor = System.Drawing.Color.Black;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(1528, 537);
            this.gradientPanel2.TabIndex = 0;
            this.gradientPanel2.TabStop = true;
            this.gradientPanel2.TopColor = System.Drawing.Color.DimGray;
            this.gradientPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // btnWL
            // 
            this.btnWL.Location = new System.Drawing.Point(306, 70);
            this.btnWL.Name = "btnWL";
            this.btnWL.Size = new System.Drawing.Size(75, 23);
            this.btnWL.TabIndex = 85;
            this.btnWL.Text = "Watch List";
            this.btnWL.UseVisualStyleBackColor = true;
            this.btnWL.Click += new System.EventHandler(this.btnWL_Click);
            // 
            // btnAddWL
            // 
            this.btnAddWL.Location = new System.Drawing.Point(225, 70);
            this.btnAddWL.Name = "btnAddWL";
            this.btnAddWL.Size = new System.Drawing.Size(75, 23);
            this.btnAddWL.TabIndex = 84;
            this.btnAddWL.Text = "Add";
            this.btnAddWL.UseVisualStyleBackColor = true;
            this.btnAddWL.Click += new System.EventHandler(this.btnAddWL_Click);
            // 
            // btnPersonImages
            // 
            this.btnPersonImages.AllowDrop = true;
            this.btnPersonImages.Location = new System.Drawing.Point(1187, 124);
            this.btnPersonImages.Name = "btnPersonImages";
            this.btnPersonImages.Size = new System.Drawing.Size(75, 23);
            this.btnPersonImages.TabIndex = 83;
            this.btnPersonImages.Text = "Images";
            this.btnPersonImages.UseVisualStyleBackColor = true;
            this.btnPersonImages.Click += new System.EventHandler(this.btnPersonImages_Click);
            // 
            // lstbxGenres
            // 
            this.lstbxGenres.BackColor = System.Drawing.Color.LightGray;
            this.lstbxGenres.FormattingEnabled = true;
            this.lstbxGenres.Location = new System.Drawing.Point(749, 129);
            this.lstbxGenres.Name = "lstbxGenres";
            this.lstbxGenres.Size = new System.Drawing.Size(66, 82);
            this.lstbxGenres.TabIndex = 82;
            // 
            // btnMovieImages
            // 
            this.btnMovieImages.Location = new System.Drawing.Point(665, 130);
            this.btnMovieImages.Name = "btnMovieImages";
            this.btnMovieImages.Size = new System.Drawing.Size(75, 23);
            this.btnMovieImages.TabIndex = 80;
            this.btnMovieImages.Text = "Images";
            this.btnMovieImages.UseVisualStyleBackColor = true;
            this.btnMovieImages.Click += new System.EventHandler(this.btnMovieImages_Click);
            // 
            // lblBirthDetails
            // 
            this.lblBirthDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthDetails.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDetails.Location = new System.Drawing.Point(1184, 174);
            this.lblBirthDetails.Name = "lblBirthDetails";
            this.lblBirthDetails.Size = new System.Drawing.Size(100, 22);
            this.lblBirthDetails.TabIndex = 79;
            this.lblBirthDetails.Text = "Birth Details";
            // 
            // tbBirthDetails
            // 
            this.tbBirthDetails.AcceptsReturn = true;
            this.tbBirthDetails.BackColor = System.Drawing.Color.LightGray;
            this.tbBirthDetails.Location = new System.Drawing.Point(1187, 196);
            this.tbBirthDetails.Name = "tbBirthDetails";
            this.tbBirthDetails.Size = new System.Drawing.Size(233, 20);
            this.tbBirthDetails.TabIndex = 78;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(534, 101);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 22);
            this.lblDate.TabIndex = 77;
            this.lblDate.Text = "Release Date";
            // 
            // tbReleaseDate
            // 
            this.tbReleaseDate.BackColor = System.Drawing.Color.LightGray;
            this.tbReleaseDate.Location = new System.Drawing.Point(534, 130);
            this.tbReleaseDate.Name = "tbReleaseDate";
            this.tbReleaseDate.Size = new System.Drawing.Size(100, 20);
            this.tbReleaseDate.TabIndex = 76;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(942, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // pcbxImdbLogo
            // 
            this.pcbxImdbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pcbxImdbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbxImdbLogo.Image")));
            this.pcbxImdbLogo.Location = new System.Drawing.Point(34, 13);
            this.pcbxImdbLogo.Name = "pcbxImdbLogo";
            this.pcbxImdbLogo.Size = new System.Drawing.Size(100, 50);
            this.pcbxImdbLogo.TabIndex = 74;
            this.pcbxImdbLogo.TabStop = false;
            // 
            // lblPictureboxNotify
            // 
            this.lblPictureboxNotify.AutoSize = true;
            this.lblPictureboxNotify.BackColor = System.Drawing.Color.Transparent;
            this.lblPictureboxNotify.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPictureboxNotify.Location = new System.Drawing.Point(31, 356);
            this.lblPictureboxNotify.Name = "lblPictureboxNotify";
            this.lblPictureboxNotify.Size = new System.Drawing.Size(89, 18);
            this.lblPictureboxNotify.TabIndex = 73;
            this.lblPictureboxNotify.Text = "Movie image";
            // 
            // lstbxKeys
            // 
            this.lstbxKeys.BackColor = System.Drawing.Color.LightGray;
            this.lstbxKeys.FormattingEnabled = true;
            this.lstbxKeys.Location = new System.Drawing.Point(1426, 245);
            this.lstbxKeys.Name = "lstbxKeys";
            this.lstbxKeys.Size = new System.Drawing.Size(67, 108);
            this.lstbxKeys.TabIndex = 72;
            // 
            // lblActorName
            // 
            this.lblActorName.AutoSize = true;
            this.lblActorName.BackColor = System.Drawing.Color.Transparent;
            this.lblActorName.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActorName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblActorName.Location = new System.Drawing.Point(928, 93);
            this.lblActorName.Name = "lblActorName";
            this.lblActorName.Size = new System.Drawing.Size(156, 29);
            this.lblActorName.TabIndex = 71;
            this.lblActorName.Text = "Actor Name";
            // 
            // lstbxJobs
            // 
            this.lstbxJobs.BackColor = System.Drawing.Color.LightGray;
            this.lstbxJobs.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxJobs.FormattingEnabled = true;
            this.lstbxJobs.ItemHeight = 17;
            this.lstbxJobs.Location = new System.Drawing.Point(933, 369);
            this.lstbxJobs.Name = "lstbxJobs";
            this.lstbxJobs.Size = new System.Drawing.Size(235, 106);
            this.lstbxJobs.TabIndex = 70;
            this.lstbxJobs.SelectedIndexChanged += new System.EventHandler(this.lstbxJobs_SelectedIndexChanged);
            // 
            // rtbActorDesc
            // 
            this.rtbActorDesc.BackColor = System.Drawing.Color.LightGray;
            this.rtbActorDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbActorDesc.Location = new System.Drawing.Point(1187, 247);
            this.rtbActorDesc.Name = "rtbActorDesc";
            this.rtbActorDesc.Size = new System.Drawing.Size(233, 106);
            this.rtbActorDesc.TabIndex = 69;
            this.rtbActorDesc.Text = "";
            // 
            // pcbxActor
            // 
            this.pcbxActor.BackColor = System.Drawing.Color.Transparent;
            this.pcbxActor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbxActor.Location = new System.Drawing.Point(933, 124);
            this.pcbxActor.Name = "pcbxActor";
            this.pcbxActor.Size = new System.Drawing.Size(233, 229);
            this.pcbxActor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxActor.TabIndex = 68;
            this.pcbxActor.TabStop = false;
            // 
            // pcbxMovie
            // 
            this.pcbxMovie.BackColor = System.Drawing.Color.Transparent;
            this.pcbxMovie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbxMovie.Location = new System.Drawing.Point(32, 124);
            this.pcbxMovie.Name = "pcbxMovie";
            this.pcbxMovie.Size = new System.Drawing.Size(349, 229);
            this.pcbxMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxMovie.TabIndex = 67;
            this.pcbxMovie.TabStop = false;
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.BackColor = System.Drawing.Color.Transparent;
            this.lblMovieName.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMovieName.Location = new System.Drawing.Point(29, 92);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(162, 29);
            this.lblMovieName.TabIndex = 66;
            this.lblMovieName.Text = "Movie Name";
            // 
            // rtbRating
            // 
            this.rtbRating.BackColor = System.Drawing.Color.LightGray;
            this.rtbRating.Location = new System.Drawing.Point(393, 129);
            this.rtbRating.Name = "rtbRating";
            this.rtbRating.Size = new System.Drawing.Size(100, 21);
            this.rtbRating.TabIndex = 65;
            this.rtbRating.Text = "";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(387, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 33);
            this.label7.TabIndex = 64;
            this.label7.Text = "Description";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(390, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 22);
            this.label6.TabIndex = 63;
            this.label6.Text = "Rating";
            // 
            // lblRoles
            // 
            this.lblRoles.BackColor = System.Drawing.Color.Transparent;
            this.lblRoles.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoles.Location = new System.Drawing.Point(634, 365);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(106, 18);
            this.lblRoles.TabIndex = 62;
            this.lblRoles.Text = "Roles";
            // 
            // lstbxRoles
            // 
            this.lstbxRoles.BackColor = System.Drawing.Color.LightGray;
            this.lstbxRoles.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxRoles.FormattingEnabled = true;
            this.lstbxRoles.ItemHeight = 17;
            this.lstbxRoles.Location = new System.Drawing.Point(640, 387);
            this.lstbxRoles.Name = "lstbxRoles";
            this.lstbxRoles.Size = new System.Drawing.Size(175, 89);
            this.lstbxRoles.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(390, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 60;
            this.label4.Text = "Date";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(284, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 26);
            this.label3.TabIndex = 59;
            this.label3.Text = "Found movies";
            // 
            // lstbxActorName
            // 
            this.lstbxActorName.BackColor = System.Drawing.Color.LightGray;
            this.lstbxActorName.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxActorName.FormattingEnabled = true;
            this.lstbxActorName.ItemHeight = 17;
            this.lstbxActorName.Location = new System.Drawing.Point(491, 387);
            this.lstbxActorName.Name = "lstbxActorName";
            this.lstbxActorName.Size = new System.Drawing.Size(143, 89);
            this.lstbxActorName.TabIndex = 58;
            this.lstbxActorName.SelectedIndexChanged += new System.EventHandler(this.lstbxActorName_SelectedIndexChanged_1);
            // 
            // lstbxDates
            // 
            this.lstbxDates.BackColor = System.Drawing.Color.LightGray;
            this.lstbxDates.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxDates.FormattingEnabled = true;
            this.lstbxDates.ItemHeight = 17;
            this.lstbxDates.Location = new System.Drawing.Point(390, 387);
            this.lstbxDates.Name = "lstbxDates";
            this.lstbxDates.Size = new System.Drawing.Size(95, 89);
            this.lstbxDates.TabIndex = 57;
            // 
            // richMovieDescr
            // 
            this.richMovieDescr.BackColor = System.Drawing.Color.LightGray;
            this.richMovieDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richMovieDescr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richMovieDescr.Location = new System.Drawing.Point(390, 210);
            this.richMovieDescr.Name = "richMovieDescr";
            this.richMovieDescr.Size = new System.Drawing.Size(425, 143);
            this.richMovieDescr.TabIndex = 56;
            this.richMovieDescr.Text = "";
            // 
            // lstbxMovieNames
            // 
            this.lstbxMovieNames.BackColor = System.Drawing.Color.LightGray;
            this.lstbxMovieNames.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxMovieNames.FormattingEnabled = true;
            this.lstbxMovieNames.ItemHeight = 17;
            this.lstbxMovieNames.Location = new System.Drawing.Point(287, 387);
            this.lstbxMovieNames.Name = "lstbxMovieNames";
            this.lstbxMovieNames.Size = new System.Drawing.Size(94, 89);
            this.lstbxMovieNames.TabIndex = 55;
            this.lstbxMovieNames.SelectedIndexChanged += new System.EventHandler(this.lstbxMovieNames_SelectedIndexChanged_1);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(166, 441);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 34);
            this.btnClear.TabIndex = 54;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(485, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 53;
            this.label1.Text = "Cast";
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.LightGray;
            this.tbSearch.Location = new System.Drawing.Point(32, 410);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(238, 20);
            this.tbSearch.TabIndex = 52;
            this.tbSearch.Text = "Search...";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(32, 442);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 34);
            this.btnSearch.TabIndex = 51;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(1528, 537);
            this.Controls.Add(this.gradientPanel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "IMDB Search Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxImdbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxActor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMovie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GradientPanel gradientPanel2;
        private System.Windows.Forms.Label lblBirthDetails;
        private System.Windows.Forms.TextBox tbBirthDetails;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox tbReleaseDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pcbxImdbLogo;
        private System.Windows.Forms.Label lblPictureboxNotify;
        private System.Windows.Forms.ListBox lstbxKeys;
        private System.Windows.Forms.Label lblActorName;
        private System.Windows.Forms.ListBox lstbxJobs;
        private System.Windows.Forms.RichTextBox rtbActorDesc;
        private System.Windows.Forms.PictureBox pcbxActor;
        private System.Windows.Forms.PictureBox pcbxMovie;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.RichTextBox rtbRating;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.ListBox lstbxRoles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListBox lstbxActorName;
        private System.Windows.Forms.ListBox lstbxDates;
        private System.Windows.Forms.RichTextBox richMovieDescr;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnMovieImages;
        public System.Windows.Forms.ListBox lstbxMovieNames;
        private System.Windows.Forms.ListBox lstbxGenres;
        private System.Windows.Forms.Button btnPersonImages;
        private System.Windows.Forms.Button btnAddWL;
        private System.Windows.Forms.Button btnWL;
    }
}

