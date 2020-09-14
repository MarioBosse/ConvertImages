using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using org.pdfclown.documents;
using org.pdfclown.documents.contents;
using org.pdfclown.documents.contents.fonts;
using org.pdfclown.documents.contents.objects;
using org.pdfclown.files;
using org.pdfclown.tools;
using System.Linq.Expressions;
using ConvertImages.Record;
using ConvertImages.INIFile;

namespace ConvertImages
{
    public partial class ImageConverter : Form
    {
        private String iniFile = "ConvertImages.INI";
        private List<RecordEtudiant> recordEtudiants = new List<RecordEtudiant>();
        public ImageConverter()
        {
            InitializeComponent();
            ReadINIFile();
        }
        private String FormatPath(String pDir)
        {
            String ret = "";
            String[] conv = pDir.Split('\\');
            foreach (String s in conv)
            {
                if (s == "")
                {
                    ret += "\\";
                }
                else
                {
                    ret += s;
                }
            }
            return ret;
        }
        private void ReadINIFile()
        {
            INIFile.INIFile IniFile = new INIFile.INIFile(this.iniFile);
            if (IniFile.IsOpen)
            {
                // Get Directory PDF
                textBoxPDFDirectory.Text = IniFile.GetVariableFrom("Directory", "PDF");
                LoadPDFDescription(FormatPath(textBoxPDFDirectory.Text));

                // Get Directory Source
                textBoxOrigine.Text = IniFile.GetVariableFrom("Directory", "Origine");
                textBoxOrigine.Text = FormatPath(textBoxOrigine.Text);

                // Get Directory Destination
                textBoxDestination.Text = IniFile.GetVariableFrom("Directory", "Destination");
                textBoxDestination.Text = FormatPath(textBoxDestination.Text);

                // Get Convertion type
                comboBoxConvertTo.SelectedIndex = Convert.ToInt32(IniFile.GetVariableFrom("Format", "ImportFormat"));

                PdfSelection(IniFile.GetVariableFrom("PDF", "Selection"));
                Selection(IniFile.GetVariableFrom("SELECTION", "Selection"));

                if (listBoxSelection.Items.Count > 0)
                {
                    SelectSelection();
                    String[] s = { textBoxOrigine.Text, textBoxDestination.Text };
                    LunchConvertion(s, true);
                }
            }
        }
        private void SelectSelectionAlls()
        {
            foreach(Object s in listBoxSelection.Items)
            {
                SelectSelection(s.ToString());
            }
        }
        private void Selection(String pSelection)
        {
            switch (pSelection.ToUpper())
            {
                case "ALL":
                    SelectSelectionAlls();
                    break;
            }
        }
        private void PdfSelection(String pSelection)
        {
            switch(pSelection.ToUpper())
            {
                case "ALL":
                    SelectPDFAlls();
                    break;
            }
        }
        private void SetListboxButtonPDF()
        {
            if (listBoxPDFFiles.Items.Count > 0)
            {
                buttonSelectAll.Enabled = true;
            }
            else
            {
                buttonSelectAll.Enabled = false;
                buttonTakeSelection.Enabled = false;
            }
            if (listBoxPDFFiles.SelectedItems.Count > 0)
            {
                buttonTakeSelection.Enabled = true;
            }
            else
            {
                buttonTakeSelection.Enabled = false;
            }
        }
        private void SetListboxButtonSelection()
        {
            if (listBoxSelection.Items.Count > 0)
            {
                buttonRemoveAll.Enabled = true;
            }
            else
            {
                buttonRemoveSelection.Enabled = false;
                buttonRemoveAll.Enabled = false;
            }
            if (listBoxPDFFiles.SelectedItems.Count > 0)
            {
                buttonTakeSelection.Enabled = true;
                buttonReadPDF.Enabled = true;
            }
            else
            {
                buttonTakeSelection.Enabled = false;
                buttonReadPDF.Enabled = false;
            }
        }
        private void SetButtonConvert()
        {
            if ((listBoxFiches.Items.Count > 0) && (textBoxOrigine.Text.Length > 0) && (textBoxDestination.Text.Length > 0))
            {
                buttonConvert.Enabled = true;
            }
            else
            {
                buttonConvert.Enabled = false;
            }
        }
        private void DisplayButton()
        {
            SetListboxButtonPDF();
            SetListboxButtonSelection();
            SetButtonConvert();
        }
        private void LoadPDFDescription(String pDirectory)
        {
            listBoxPDFFiles.Items.Clear();
            String ret = "";
            textBoxPDFDirectory.Text = pDirectory;
            if (Directory.Exists(textBoxPDFDirectory.Text))
            {
                String[] fileList = Directory.GetFiles(textBoxPDFDirectory.Text);
                foreach (String s in fileList)
                {
                    String[] r = s.Split('\\');
                    foreach (String rs in r)
                    {
                        ret = rs;
                    }
                    String[] fType = ret.Split('.');
                    if (fType.Length == 2)
                    {
                        if (fType[1].ToUpper() == "PDF")
                        {
                            listBoxPDFFiles.Items.Add(fType[0]);
                        }
                    }
                }
            }
            DisplayButton();
        }
        private void buttonSelectPDFDirectory_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialogPDF.Description = "Choisisez le répertoire de fichier PDF à lire";
            this.folderBrowserDialogPDF.ShowNewFolderButton = false;

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialogPDF.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadPDFDescription(folderBrowserDialogPDF.SelectedPath);
            }
        }
        private void SelectPDFAlls()
        {
            listBoxSelection.Items.Clear();
            foreach (String s in listBoxPDFFiles.Items)
            {
                listBoxSelection.Items.Add(s);
            }
            listBoxPDFFiles.Items.Clear();
            DisplayButton();
        }
        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            SelectPDFAlls();
        }
        private void buttonTakeSelection_Click(object sender, EventArgs e)
        {
            while (listBoxPDFFiles.SelectedItems.Count > 0)
            {
                listBoxSelection.Items.Add(listBoxPDFFiles.SelectedItems[0]);
                listBoxPDFFiles.Items.Remove(listBoxPDFFiles.SelectedItems[0]);
            }
            DisplayButton();
        }
        private void buttonRemoveSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxSelection.SelectedItems.Count; i++)
            {
                listBoxPDFFiles.Items.Add(listBoxSelection.SelectedItems[i]);
                listBoxSelection.Items.Remove(listBoxSelection.SelectedItems[i]);
            }
            DisplayButton();
        }
        private Boolean PresentInList(String pSelection, ListBox.ObjectCollection pList)
        {
            foreach(String s in pList)
            {
                if(pSelection == s)
                {
                    return true;
                }
            }
            return false;
        }
        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            // Si la destination est vide, ont les prends tous
            if (listBoxPDFFiles.Items.Count == 0)
            {
                foreach (String s in listBoxSelection.Items)
                {
                    listBoxPDFFiles.Items.Add(s);
                }
                listBoxSelection.Items.Clear();
                listBoxFiches.Items.Clear();
            }
            else
            {
                foreach (String s in listBoxSelection.Items)
                {
                    listBoxSelection.Items.Remove(s);
                    listBoxPDFFiles.Items.Add(s);
                }
            }
            DisplayButton();
        }
        private void listBoxPDFFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxPDFFiles.SelectedItems.Count > 0)
            {
                buttonTakeSelection.Enabled = true;
            }
            else
            {
                buttonTakeSelection.Enabled = false;
            }
        }
        private void listBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSelection.SelectedItems.Count > 0)
            {
                buttonRemoveSelection.Enabled = true;
                buttonReadPDF.Enabled = true;
            }
            else
            {
                buttonRemoveSelection.Enabled = false;
                buttonReadPDF.Enabled = false;
            }
        }
        private Boolean IsStudent(String PdfString)
        {
            Boolean ret = false;
            String[] sAnalyse = PdfString.Split(' ');
            try
            {
                if (Convert.ToInt32(sAnalyse[0].ToString()) > 0)
                {
                    recordEtudiants.Add(new RecordEtudiant(sAnalyse));
                    return true;
                }
            }
            catch(Exception ex)
            { }
            return false;
        }
        private void SetProgress(Int32 pMax)
        {
            progressBar.Minimum = 1;
            progressBar.Maximum = pMax;
            progressBar.Step = 1;
        }
        private void DisplayProgress()
        {
            progressBar.PerformStep();
        }
        private void SelectSelection(String pSelection)
        {
            SetProgress(listBoxSelection.SelectedItems.Count + 1);
            DisplayProgress();
            String filename = textBoxPDFDirectory.Text + "\\" + pSelection + ".pdf";
            using (org.pdfclown.files.File file = new org.pdfclown.files.File(filename))
            {
                Document document = file.Document;
                TextExtractor extractor = new TextExtractor();

                // 2. Text extraction from the document pages.
                foreach (Page page in document.Pages)
                {
                    IList<ITextString> textStrings = extractor.Extract(page)[TextExtractor.DefaultArea];
                    foreach (ITextString textString in textStrings)
                    {
                        // Identifier si le texte est un registre d'élève.
                        if (IsStudent(textString.Text))
                        {
                            RectangleF textStringBox = textString.Box.Value;
                            listBoxFiches.Items.Add(recordEtudiants[recordEtudiants.Count - 1].Fiche);
                            Console.WriteLine("Text ["
                                                + "x:" + Math.Round(textStringBox.X) + ","
                                                + "y:" + Math.Round(textStringBox.Y) + ","
                                                + "w:" + Math.Round(textStringBox.Width) + ","
                                                + "h:" + Math.Round(textStringBox.Height)
                                                + "]: " + textString.Text);
                        }
                        listBoxFiches.Update();
                    }
                }
            }
        }
        private void SelectSelection()
        {
            SetProgress(listBoxSelection.SelectedItems.Count + 1);
            listBoxFiches.Items.Clear();
            foreach (String s in listBoxSelection.SelectedItems)
            {
                DisplayProgress();
                String filename = textBoxPDFDirectory.Text + "\\" + s + ".pdf";
                using (org.pdfclown.files.File file = new org.pdfclown.files.File(filename))
                {
                    Document document = file.Document;
                    TextExtractor extractor = new TextExtractor();

                    // 2. Text extraction from the document pages.
                    foreach (Page page in document.Pages)
                    {
                        IList<ITextString> textStrings = extractor.Extract(page)[TextExtractor.DefaultArea];
                        foreach (ITextString textString in textStrings)
                        {
                            // Identifier si le texte est un registre d'élève.
                            if (IsStudent(textString.Text))
                            {
                                RectangleF textStringBox = textString.Box.Value;
                                listBoxFiches.Items.Add(recordEtudiants[recordEtudiants.Count - 1].Fiche);
                                Console.WriteLine("Text ["
                                                    + "x:" + Math.Round(textStringBox.X) + ","
                                                    + "y:" + Math.Round(textStringBox.Y) + ","
                                                    + "w:" + Math.Round(textStringBox.Width) + ","
                                                    + "h:" + Math.Round(textStringBox.Height)
                                                    + "]: " + textString.Text);
                            }
                            listBoxFiches.Update();
                        }
                    }
                }
            }
            DisplayButton();
        }
        private void buttonReadPDF_Click(object sender, EventArgs e)
        {
            SelectSelection();
        }
        private void LunchConvertion(String[] s, Boolean bAutomatic = false)
        {
            ConvertImages.Conversion.ConvertImage winConvert =
                      new Conversion.ConvertImage(recordEtudiants, s, comboBoxConvertTo.Text);
            switch (winConvert.ShowDialog())
            {
                default:
                    break;
            }
        }
        private void buttonConvert_Click(object sender, EventArgs e)
        {
            String[] s = { textBoxOrigine.Text, textBoxDestination.Text };
            LunchConvertion(s);
        }

        private void buttonSelectOrigine_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialogPDF.Description = "Choisisez le répertoire d'origine des images";
            this.folderBrowserDialogPDF.ShowNewFolderButton = false;

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialogPDF.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxOrigine.Text = folderBrowserDialogPDF.SelectedPath;
                DisplayButton();
            }
        }
        private void buttonSelectDestination_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialogPDF.Description = "Choisisez le répertoire de résultat";
            this.folderBrowserDialogPDF.ShowNewFolderButton = true;

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialogPDF.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxDestination.Text = folderBrowserDialogPDF.SelectedPath;
                DisplayButton();
            }
        }
    }
}

