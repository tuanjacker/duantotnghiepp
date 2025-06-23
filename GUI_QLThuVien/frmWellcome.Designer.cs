namespace GUI_QLThuVien
{
    partial class frmWellcome
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
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(-2, 781);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1280, 10);
            progressBar.TabIndex = 0;
            // 
            // frmWellcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ưellcome;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1277, 788);
            Controls.Add(progressBar);
            DoubleBuffered = true;
            MaximumSize = new Size(1295, 835);
            MinimumSize = new Size(1295, 835);
            Name = "frmWellcome";
            Text = "frmWellcome";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
    }
}