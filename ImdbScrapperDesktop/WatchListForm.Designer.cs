namespace ImdbScrapperDesktop
{
    partial class WatchListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchListForm));
            this.gradientPanel1 = new ImdbScrapperDesktop.GradientPanel();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lblWatchedMovies = new System.Windows.Forms.Label();
            this.btnWatched = new System.Windows.Forms.Button();
            this.lstbxWatched = new System.Windows.Forms.ListBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.tbReleaseDate = new System.Windows.Forms.TextBox();
            this.pcbxMovie = new System.Windows.Forms.PictureBox();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.rtbRating = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richMovieDescr = new System.Windows.Forms.RichTextBox();
            this.pcbxImdbLogo = new System.Windows.Forms.PictureBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSetWatched = new System.Windows.Forms.Button();
            this.lstbxWatchList = new System.Windows.Forms.ListBox();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMovie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxImdbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 0F;
            this.gradientPanel1.BackColor = System.Drawing.Color.White;
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.btnOrder);
            this.gradientPanel1.Controls.Add(this.lblWatchedMovies);
            this.gradientPanel1.Controls.Add(this.btnWatched);
            this.gradientPanel1.Controls.Add(this.lstbxWatched);
            this.gradientPanel1.Controls.Add(this.lblDate);
            this.gradientPanel1.Controls.Add(this.tbReleaseDate);
            this.gradientPanel1.Controls.Add(this.pcbxMovie);
            this.gradientPanel1.Controls.Add(this.lblMovieName);
            this.gradientPanel1.Controls.Add(this.rtbRating);
            this.gradientPanel1.Controls.Add(this.label7);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.richMovieDescr);
            this.gradientPanel1.Controls.Add(this.pcbxImdbLogo);
            this.gradientPanel1.Controls.Add(this.btnShow);
            this.gradientPanel1.Controls.Add(this.label6);
            this.gradientPanel1.Controls.Add(this.btnSetWatched);
            this.gradientPanel1.Controls.Add(this.lstbxWatchList);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.ForeColor = System.Drawing.Color.Black;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(436, 624);
            this.gradientPanel1.TabIndex = 1;
            this.gradientPanel1.TopColor = System.Drawing.Color.DimGray;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(299, 423);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 40);
            this.btnOrder.TabIndex = 98;
            this.btnOrder.Text = "Order by rating";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblWatchedMovies
            // 
            this.lblWatchedMovies.BackColor = System.Drawing.Color.Transparent;
            this.lblWatchedMovies.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWatchedMovies.Location = new System.Drawing.Point(265, 268);
            this.lblWatchedMovies.Name = "lblWatchedMovies";
            this.lblWatchedMovies.Size = new System.Drawing.Size(154, 22);
            this.lblWatchedMovies.TabIndex = 96;
            this.lblWatchedMovies.Text = "Watched Movies";
            // 
            // btnWatched
            // 
            this.btnWatched.Location = new System.Drawing.Point(299, 394);
            this.btnWatched.Name = "btnWatched";
            this.btnWatched.Size = new System.Drawing.Size(75, 23);
            this.btnWatched.TabIndex = 95;
            this.btnWatched.Text = "Films";
            this.btnWatched.UseVisualStyleBackColor = true;
            this.btnWatched.Click += new System.EventHandler(this.btnWatched_Click);
            // 
            // lstbxWatched
            // 
            this.lstbxWatched.FormattingEnabled = true;
            this.lstbxWatched.Location = new System.Drawing.Point(262, 293);
            this.lstbxWatched.Name = "lstbxWatched";
            this.lstbxWatched.Size = new System.Drawing.Size(157, 95);
            this.lstbxWatched.TabIndex = 94;
            this.lstbxWatched.SelectedIndexChanged += new System.EventHandler(this.lstbxWatched_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(313, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 22);
            this.lblDate.TabIndex = 92;
            this.lblDate.Text = "Release Date";
            // 
            // tbReleaseDate
            // 
            this.tbReleaseDate.BackColor = System.Drawing.Color.LightGray;
            this.tbReleaseDate.Location = new System.Drawing.Point(313, 50);
            this.tbReleaseDate.Name = "tbReleaseDate";
            this.tbReleaseDate.Size = new System.Drawing.Size(100, 20);
            this.tbReleaseDate.TabIndex = 91;
            // 
            // pcbxMovie
            // 
            this.pcbxMovie.BackColor = System.Drawing.Color.Transparent;
            this.pcbxMovie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbxMovie.Location = new System.Drawing.Point(12, 48);
            this.pcbxMovie.Name = "pcbxMovie";
            this.pcbxMovie.Size = new System.Drawing.Size(184, 122);
            this.pcbxMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbxMovie.TabIndex = 90;
            this.pcbxMovie.TabStop = false;
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.BackColor = System.Drawing.Color.Transparent;
            this.lblMovieName.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMovieName.Location = new System.Drawing.Point(12, 9);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(162, 29);
            this.lblMovieName.TabIndex = 89;
            this.lblMovieName.Text = "Movie Name";
            // 
            // rtbRating
            // 
            this.rtbRating.BackColor = System.Drawing.Color.LightGray;
            this.rtbRating.Location = new System.Drawing.Point(202, 49);
            this.rtbRating.Name = "rtbRating";
            this.rtbRating.Size = new System.Drawing.Size(100, 21);
            this.rtbRating.TabIndex = 88;
            this.rtbRating.Text = "";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(202, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 87;
            this.label7.Text = "Description";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 86;
            this.label1.Text = "Rating";
            // 
            // richMovieDescr
            // 
            this.richMovieDescr.BackColor = System.Drawing.Color.LightGray;
            this.richMovieDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richMovieDescr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richMovieDescr.Location = new System.Drawing.Point(202, 106);
            this.richMovieDescr.Name = "richMovieDescr";
            this.richMovieDescr.Size = new System.Drawing.Size(217, 64);
            this.richMovieDescr.TabIndex = 85;
            this.richMovieDescr.Text = "";
            // 
            // pcbxImdbLogo
            // 
            this.pcbxImdbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pcbxImdbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbxImdbLogo.Image")));
            this.pcbxImdbLogo.Location = new System.Drawing.Point(324, 555);
            this.pcbxImdbLogo.Name = "pcbxImdbLogo";
            this.pcbxImdbLogo.Size = new System.Drawing.Size(100, 50);
            this.pcbxImdbLogo.TabIndex = 75;
            this.pcbxImdbLogo.TabStop = false;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(51, 394);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 65;
            this.btnShow.Text = "Films";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 22);
            this.label6.TabIndex = 64;
            this.label6.Text = "Watch List";
            // 
            // btnSetWatched
            // 
            this.btnSetWatched.Location = new System.Drawing.Point(99, 267);
            this.btnSetWatched.Name = "btnSetWatched";
            this.btnSetWatched.Size = new System.Drawing.Size(75, 23);
            this.btnSetWatched.TabIndex = 2;
            this.btnSetWatched.Text = "Set watched";
            this.btnSetWatched.UseVisualStyleBackColor = true;
            this.btnSetWatched.Click += new System.EventHandler(this.btnSetWatched_Click);
            // 
            // lstbxWatchList
            // 
            this.lstbxWatchList.FormattingEnabled = true;
            this.lstbxWatchList.Location = new System.Drawing.Point(17, 293);
            this.lstbxWatchList.Name = "lstbxWatchList";
            this.lstbxWatchList.Size = new System.Drawing.Size(157, 95);
            this.lstbxWatchList.TabIndex = 1;
            this.lstbxWatchList.SelectedIndexChanged += new System.EventHandler(this.lstbxWatchList_SelectedIndexChanged);
            // 
            // WatchListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 624);
            this.Controls.Add(this.gradientPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WatchListForm";
            this.Text = "Watch List";
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxMovie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxImdbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pcbxImdbLogo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox tbReleaseDate;
        private System.Windows.Forms.PictureBox pcbxMovie;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.RichTextBox rtbRating;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richMovieDescr;
        private System.Windows.Forms.Button btnWatched;
        private System.Windows.Forms.ListBox lstbxWatched;
        private System.Windows.Forms.Label lblWatchedMovies;
        private System.Windows.Forms.Button btnOrder;
        public System.Windows.Forms.Button btnSetWatched;
        public System.Windows.Forms.ListBox lstbxWatchList;
        public System.Windows.Forms.Button btnShow;
    }
}