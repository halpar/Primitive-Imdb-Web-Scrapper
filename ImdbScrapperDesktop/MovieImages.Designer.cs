namespace ImdbScrapperDesktop
{
    partial class MovieImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieImages));
            this.gradientPanel1 = new ImdbScrapperDesktop.GradientPanel();
            this.gradientPanel2 = new ImdbScrapperDesktop.GradientPanel();
            this.pcbxImdbLogo = new System.Windows.Forms.PictureBox();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxImdbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 0F;
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Location = new System.Drawing.Point(437, 167);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(200, 100);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.TopColor = System.Drawing.Color.Empty;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Angle = 0F;
            this.gradientPanel2.BackColor = System.Drawing.Color.White;
            this.gradientPanel2.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel2.Controls.Add(this.pcbxImdbLogo);
            this.gradientPanel2.ForeColor = System.Drawing.Color.Black;
            this.gradientPanel2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(834, 492);
            this.gradientPanel2.TabIndex = 1;
            this.gradientPanel2.TopColor = System.Drawing.Color.DimGray;
            // 
            // pcbxImdbLogo
            // 
            this.pcbxImdbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pcbxImdbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbxImdbLogo.Image")));
            this.pcbxImdbLogo.Location = new System.Drawing.Point(705, 413);
            this.pcbxImdbLogo.Name = "pcbxImdbLogo";
            this.pcbxImdbLogo.Size = new System.Drawing.Size(100, 50);
            this.pcbxImdbLogo.TabIndex = 74;
            this.pcbxImdbLogo.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 488);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.gradientPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Movie Images";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.gradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxImdbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public GradientPanel gradientPanel1;
        private System.Windows.Forms.PictureBox pcbxImdbLogo;
        public GradientPanel gradientPanel2;
    }
}