namespace ConvertImages
{
    partial class ImageConverter
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPDFDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectPDFDirectory = new System.Windows.Forms.Button();
            this.listBoxPDFFiles = new System.Windows.Forms.ListBox();
            this.folderBrowserDialogPDF = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonTakeSelection = new System.Windows.Forms.Button();
            this.buttonRemoveSelection = new System.Windows.Forms.Button();
            this.listBoxSelection = new System.Windows.Forms.ListBox();
            this.comboBoxConvertTo = new System.Windows.Forms.ComboBox();
            this.listBoxFiches = new System.Windows.Forms.ListBox();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonReadPDF = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonSelectOrigine = new System.Windows.Forms.Button();
            this.textBoxOrigine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectDestination = new System.Windows.Forms.Button();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Répertoire PDF";
            // 
            // textBoxPDFDirectory
            // 
            this.textBoxPDFDirectory.Location = new System.Drawing.Point(16, 30);
            this.textBoxPDFDirectory.Name = "textBoxPDFDirectory";
            this.textBoxPDFDirectory.Size = new System.Drawing.Size(325, 20);
            this.textBoxPDFDirectory.TabIndex = 1;
            // 
            // buttonSelectPDFDirectory
            // 
            this.buttonSelectPDFDirectory.Location = new System.Drawing.Point(347, 28);
            this.buttonSelectPDFDirectory.Name = "buttonSelectPDFDirectory";
            this.buttonSelectPDFDirectory.Size = new System.Drawing.Size(27, 23);
            this.buttonSelectPDFDirectory.TabIndex = 2;
            this.buttonSelectPDFDirectory.Text = "...";
            this.buttonSelectPDFDirectory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSelectPDFDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectPDFDirectory.Click += new System.EventHandler(this.buttonSelectPDFDirectory_Click);
            // 
            // listBoxPDFFiles
            // 
            this.listBoxPDFFiles.FormattingEnabled = true;
            this.listBoxPDFFiles.Location = new System.Drawing.Point(16, 135);
            this.listBoxPDFFiles.Name = "listBoxPDFFiles";
            this.listBoxPDFFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxPDFFiles.Size = new System.Drawing.Size(116, 238);
            this.listBoxPDFFiles.Sorted = true;
            this.listBoxPDFFiles.TabIndex = 3;
            this.listBoxPDFFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxPDFFiles_SelectedIndexChanged);
            // 
            // buttonTakeSelection
            // 
            this.buttonTakeSelection.Enabled = false;
            this.buttonTakeSelection.Location = new System.Drawing.Point(138, 164);
            this.buttonTakeSelection.Name = "buttonTakeSelection";
            this.buttonTakeSelection.Size = new System.Drawing.Size(34, 23);
            this.buttonTakeSelection.TabIndex = 5;
            this.buttonTakeSelection.Text = "-->";
            this.buttonTakeSelection.UseVisualStyleBackColor = true;
            this.buttonTakeSelection.Click += new System.EventHandler(this.buttonTakeSelection_Click);
            // 
            // buttonRemoveSelection
            // 
            this.buttonRemoveSelection.Enabled = false;
            this.buttonRemoveSelection.Location = new System.Drawing.Point(138, 193);
            this.buttonRemoveSelection.Name = "buttonRemoveSelection";
            this.buttonRemoveSelection.Size = new System.Drawing.Size(34, 23);
            this.buttonRemoveSelection.TabIndex = 6;
            this.buttonRemoveSelection.Text = "<--";
            this.buttonRemoveSelection.UseVisualStyleBackColor = true;
            this.buttonRemoveSelection.Click += new System.EventHandler(this.buttonRemoveSelection_Click);
            // 
            // listBoxSelection
            // 
            this.listBoxSelection.FormattingEnabled = true;
            this.listBoxSelection.Location = new System.Drawing.Point(178, 135);
            this.listBoxSelection.Name = "listBoxSelection";
            this.listBoxSelection.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSelection.Size = new System.Drawing.Size(116, 238);
            this.listBoxSelection.Sorted = true;
            this.listBoxSelection.TabIndex = 8;
            this.listBoxSelection.TabStop = false;
            this.listBoxSelection.SelectedIndexChanged += new System.EventHandler(this.listBoxSelection_SelectedIndexChanged);
            // 
            // comboBoxConvertTo
            // 
            this.comboBoxConvertTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConvertTo.FormattingEnabled = true;
            this.comboBoxConvertTo.Items.AddRange(new object[] {
            "Bmp vers Jpeg",
            "Jpeg vers Bmp"});
            this.comboBoxConvertTo.Location = new System.Drawing.Point(382, 30);
            this.comboBoxConvertTo.Name = "comboBoxConvertTo";
            this.comboBoxConvertTo.Size = new System.Drawing.Size(99, 21);
            this.comboBoxConvertTo.TabIndex = 9;
            // 
            // listBoxFiches
            // 
            this.listBoxFiches.FormattingEnabled = true;
            this.listBoxFiches.Location = new System.Drawing.Point(380, 135);
            this.listBoxFiches.Name = "listBoxFiches";
            this.listBoxFiches.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiches.Size = new System.Drawing.Size(99, 238);
            this.listBoxFiches.Sorted = true;
            this.listBoxFiches.TabIndex = 10;
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Enabled = false;
            this.buttonSelectAll.Location = new System.Drawing.Point(138, 135);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(34, 23);
            this.buttonSelectAll.TabIndex = 4;
            this.buttonSelectAll.Text = "==>";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Enabled = false;
            this.buttonRemoveAll.Location = new System.Drawing.Point(138, 222);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(34, 23);
            this.buttonRemoveAll.TabIndex = 7;
            this.buttonRemoveAll.Text = "<==";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // buttonReadPDF
            // 
            this.buttonReadPDF.Enabled = false;
            this.buttonReadPDF.Location = new System.Drawing.Point(299, 135);
            this.buttonReadPDF.Name = "buttonReadPDF";
            this.buttonReadPDF.Size = new System.Drawing.Size(75, 23);
            this.buttonReadPDF.TabIndex = 11;
            this.buttonReadPDF.Text = "Lecture";
            this.buttonReadPDF.UseVisualStyleBackColor = true;
            this.buttonReadPDF.Click += new System.EventHandler(this.buttonReadPDF_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 382);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(467, 15);
            this.progressBar.TabIndex = 12;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Enabled = false;
            this.buttonConvert.Location = new System.Drawing.Point(298, 164);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 13;
            this.buttonConvert.Text = "Conversion";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonSelectOrigine
            // 
            this.buttonSelectOrigine.Location = new System.Drawing.Point(347, 67);
            this.buttonSelectOrigine.Name = "buttonSelectOrigine";
            this.buttonSelectOrigine.Size = new System.Drawing.Size(27, 23);
            this.buttonSelectOrigine.TabIndex = 16;
            this.buttonSelectOrigine.Text = "...";
            this.buttonSelectOrigine.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSelectOrigine.UseVisualStyleBackColor = true;
            this.buttonSelectOrigine.Click += new System.EventHandler(this.buttonSelectOrigine_Click);
            // 
            // textBoxOrigine
            // 
            this.textBoxOrigine.Location = new System.Drawing.Point(16, 70);
            this.textBoxOrigine.Name = "textBoxOrigine";
            this.textBoxOrigine.Size = new System.Drawing.Size(325, 20);
            this.textBoxOrigine.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Répertoire d\'Origine";
            // 
            // buttonSelectDestination
            // 
            this.buttonSelectDestination.Location = new System.Drawing.Point(347, 106);
            this.buttonSelectDestination.Name = "buttonSelectDestination";
            this.buttonSelectDestination.Size = new System.Drawing.Size(27, 23);
            this.buttonSelectDestination.TabIndex = 19;
            this.buttonSelectDestination.Text = "...";
            this.buttonSelectDestination.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSelectDestination.UseVisualStyleBackColor = true;
            this.buttonSelectDestination.Click += new System.EventHandler(this.buttonSelectDestination_Click);
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(16, 110);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(325, 20);
            this.textBoxDestination.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Répertoire de Destination";
            // 
            // ImageConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 400);
            this.Controls.Add(this.buttonSelectDestination);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSelectOrigine);
            this.Controls.Add(this.textBoxOrigine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonReadPDF);
            this.Controls.Add(this.buttonRemoveAll);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.listBoxFiches);
            this.Controls.Add(this.comboBoxConvertTo);
            this.Controls.Add(this.listBoxSelection);
            this.Controls.Add(this.buttonRemoveSelection);
            this.Controls.Add(this.buttonTakeSelection);
            this.Controls.Add(this.listBoxPDFFiles);
            this.Controls.Add(this.buttonSelectPDFDirectory);
            this.Controls.Add(this.textBoxPDFDirectory);
            this.Controls.Add(this.label1);
            this.Name = "ImageConverter";
            this.Text = "Image Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPDFDirectory;
        private System.Windows.Forms.Button buttonSelectPDFDirectory;
        private System.Windows.Forms.ListBox listBoxPDFFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPDF;
        private System.Windows.Forms.Button buttonTakeSelection;
        private System.Windows.Forms.Button buttonRemoveSelection;
        private System.Windows.Forms.ListBox listBoxSelection;
        private System.Windows.Forms.ComboBox comboBoxConvertTo;
        private System.Windows.Forms.ListBox listBoxFiches;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Button buttonReadPDF;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonSelectOrigine;
        private System.Windows.Forms.TextBox textBoxOrigine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectDestination;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label label3;
    }
}

