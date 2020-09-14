using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConvertImages.Conversion;
using ConvertImages.Record;

namespace ConvertImages.Conversion
{
    public partial class ConvertImage : Form
    {
        private String[] strDir = { "Origine     : ",
                                    "Destination : "};
        private String textOutputDirectory = "";
        private String txtImageDirectory = "";
        private String convert;
        private String cboSourceType = "";
        private String cboOutputType = "";
        private List<RecordEtudiant> listEtudiants = new List<RecordEtudiant>();
        public ConvertImage(List<RecordEtudiant> pListEtudiant, String[] pDir, String sConvert)
        {
            convert = sConvert;
            SetFileFormat(convert);
            listEtudiants = pListEtudiant;
            InitializeComponent();
            InitializeForm(listEtudiants);

            txtImageDirectory = pDir[0];
            textOutputDirectory = pDir[1];

            labelOrigine.Text = strDir[0] + txtImageDirectory;
            labelDestination.Text = strDir[1] + textOutputDirectory;
            SetupControls();
            this.Text = "Bulk Image Converter v" + Application.ProductVersion + " by slade73";
            ImageOps.OnImageConversionStart += new ImageOps.ImageEvent(ImageOps_OnImageConversionStart);
            ImageOps.OnImageConversionComplete += new ImageOps.ImageEvent(ImageOps_OnImageConversionComplete);

            ConvertImageFiles();
        }
        private void SetFileFormat(String pConvert)
        {
            String[] selectFormat = pConvert.Split(' ');
            cboSourceType = selectFormat[0];
            cboOutputType = selectFormat[2];
        }
        private void InitializeForm(List<RecordEtudiant> pList)
        {
            if(pList.Count > 0)
            {
                int compteur = 0;
                do
                {
                    listBoxFiches.Items.Add(pList[compteur++].Fiche.ToString());
                } while (compteur < pList.Count);
            }
        }
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Sets up the controls on the form.  No kidding.
        /// </summary>
        protected void SetupControls()
        {
            String[] p = convert.Split(' ');
            //cboSourceTypes.Items = cboSourceTypes.Items;
        }
        void ImageOps_OnImageConversionStart(ImageOpsEventArgs args)
        {
        }
        void ImageOps_OnImageConversionComplete(ImageOpsEventArgs args)
        {
        }
        /// <summary>
        /// Gets the appropriate type of ImageFormat based on the user's output format selection
        /// </summary>
        /// <returns>The ImageFormat object for the user's output format selection</returns>
        protected ImageFormat GetSelectedOutputImageFormat()
        {
            Type type = null;

            try
            {
                type = typeof(ImageFormat);
                return (ImageFormat)type.InvokeMember(cboOutputType, BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty, null, null, null);
            }
            finally
            {
                type = null;
            }
        }
        /// <summary>
        /// Gets the number of files from the specified directory which match the supplied filemask
        /// </summary>
        /// <param name="directory">The directory to get a file count from</param>
        /// <param name="fileMasks">The filemask(s) to count</param>
        /// <param name="includeSubDirs">Specifies whether subdirectories of the specified directory should 
        /// be included</param>
        /// <returns>The total number of files from the specified directory which match the supplied filemask</returns>
        private int GetImagesCount()
        {
            int totalFiles = listEtudiants.Count;
            return totalFiles;
        }
        private void ConvertImageFiles()
        {
            ImageFormat format = null;
            string[] inputFileMasks = null;
            int totalFiles = 0;

            //Make sure we have all the information we need to proceed and that it's valid.  If not, bail.
            if (!OKToProceed()) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                //Disable input controls
                //ToggleInputEnable(false);

                //Get the selected image format and associated filemasks
                format = GetSelectedOutputImageFormat();
                inputFileMasks = ImageOps.GetFileMasks(cboSourceType);

                //Get the total number of files we will be converting
                totalFiles = GetImagesCount();

                //If there are no files to convert, alert the user and bail.  Otherwise, set up the progress bar.
                if (totalFiles == 0)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("There are no files of the type you specified in the chosen directory.",
                        "No files to convert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    progressBar.Value = 0;
                    progressBar.Maximum = totalFiles;
                }

                labelAction.Text = "Beginning conversion";

                ImageOps.ConvertImages(txtImageDirectory,
                    textOutputDirectory,
                    listEtudiants,
                    inputFileMasks,
                    format,
                    false);

                progressBar.Value = progressBar.Maximum;

                this.Cursor = Cursors.Default;
                labelAction.Text = "Conversion complete";
            }
            catch (Exception ex)
            {
                labelAction.Text = "ERROR";
                this.Cursor = Cursors.Default;
                MessageBox.Show("An error has occurred:\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        /// <summary>
        /// Determines whether or not all of the required information for converting images has been supplied and 
        /// is valid
        /// </summary>
        /// <returns>true if the required information is present and valid, false otherwise</returns>
        protected bool OKToProceed()
        {
            return true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }
    }
}
