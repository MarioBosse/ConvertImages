namespace ConvertImages.Conversion
{
    partial class ConvertImage
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
            this.listBoxFiches = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelAction = new System.Windows.Forms.Label();
            this.process1 = new System.Diagnostics.Process();
            this.labelOrigine = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxFiches
            // 
            this.listBoxFiches.FormattingEnabled = true;
            this.listBoxFiches.Location = new System.Drawing.Point(12, 12);
            this.listBoxFiches.Name = "listBoxFiches";
            this.listBoxFiches.Size = new System.Drawing.Size(120, 199);
            this.listBoxFiches.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 234);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(548, 11);
            this.progressBar.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(404, 193);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Démarer";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(485, 193);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 3;
            this.buttonQuit.Text = "Quitter";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelAction
            // 
            this.labelAction.Location = new System.Drawing.Point(12, 219);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(548, 12);
            this.labelAction.TabIndex = 4;
            this.labelAction.Text = "Traitement";
            this.labelAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // labelOrigine
            // 
            this.labelOrigine.AutoSize = true;
            this.labelOrigine.Location = new System.Drawing.Point(139, 18);
            this.labelOrigine.Name = "labelOrigine";
            this.labelOrigine.Size = new System.Drawing.Size(35, 13);
            this.labelOrigine.TabIndex = 7;
            this.labelOrigine.Text = "label1";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(139, 45);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(35, 13);
            this.labelDestination.TabIndex = 8;
            this.labelDestination.Text = "label2";
            // 
            // ConvertImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 257);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.labelOrigine);
            this.Controls.Add(this.labelAction);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listBoxFiches);
            this.Name = "ConvertImage";
            this.Text = "Convert Image";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFiches;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelAction;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Label labelOrigine;
    }
}