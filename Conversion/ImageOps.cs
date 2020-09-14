﻿/*
 * ImageOps.cs
 * by slade73
 * http://sourceforge.net/users/slade73
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ConvertImages.Record;

namespace ConvertImages.Conversion
{
    /// <summary>
    /// A class used to communicate ImageOps events
    /// </summary>
    public class ImageOpsEventArgs : EventArgs
    {
        protected string _imageFilename;

        public string ImageFilename
        {
            get { return _imageFilename; }
        }

        public ImageOpsEventArgs(string filename) : base()
        {
            _imageFilename = filename;
        }
    }


    /// <summary>
    /// A static class containing functionality related to image processing
    /// </summary>
    public static class ImageOps
    {
        public delegate void ImageEvent(ImageOpsEventArgs args);
        public static event ImageEvent OnImageConversionStart;
        public static event ImageEvent OnImageConversionComplete;


        /// <summary>
        /// An enumeration used to specify what should be done when the filename for an output image already 
        /// exists
        /// </summary>
        private enum FilenameAlreadyExistsOption
        {
            Ask,
            Overwrite,
            Skip
        }


        /// <summary>
        /// Gets the file masks which apply to the specified image type
        /// </summary>
        /// <param name="imageType"></param>
        /// <returns></returns>
        public static string[] GetFileMasks(string imageType)
        {
            switch (imageType)
            {
                default:
                    return new string[] { "." + imageType };
            }
        }


        /// <summary>
        /// Converts images to a different format
        /// </summary>
        /// <param name="targetDir">The directory containing the images to be converted</param>
        /// <param name="includeSubDirs">Specifies whether or not to convert images in subdirectories</param>
        /// <param name="convertFromFileMasks">An array of strings containing the file extensions of images 
        /// to be converted</param>
        /// <param name="convertTo">The format to convert images to</param>
        /// <param name="deleteAfterConversion">Specifies whether or not to delete images after converting them</param>
        public static void ConvertImages(string targetDir,
                                string outputDir,
                                List<RecordEtudiant> listEtudiants,
                                string[] convertFromFileMasks,
                                ImageFormat convertTo,
                                bool deleteAfterConversion)
        {
            ConvertImages(targetDir, outputDir, listEtudiants, convertFromFileMasks, convertTo, deleteAfterConversion, FilenameAlreadyExistsOption.Ask);
        }



        /// <summary>
        /// Converts images to a different format
        /// </summary>
        /// <param name="targetDir">The directory containing the images to be converted</param>
        /// <param name="includeSubDirs">Specifies whether or not to convert images in subdirectories</param>
        /// <param name="convertFromFileMasks">An array of strings containing the file extensions of images 
        /// to be converted</param>
        /// <param name="convertTo">The format to convert images to</param>
        /// <param name="Iteration"></param>
        private static void ConvertImages(string targetDir, 
                                        string outputDir,
                                        List<RecordEtudiant> listEtudiants,
                                        string[] convertFromFileMasks, 
                                        ImageFormat convertTo,
                                        bool deleteAfterConversion,
                                        FilenameAlreadyExistsOption filenameAlreadyExistsOpt)
        {
            string newFilename = null;
//            frmFileExists frmExists = null;
            string outputExt = null;

            try
            {

                //If the input path ends with a backslash, remove it
                targetDir = targetDir.Trim();
                if (targetDir.EndsWith("\\")) targetDir.TrimEnd('\\');

                outputExt = GetOutputExtension(convertTo.ToString()).ToLower();

                //Loop through each file of the specified type in the specified directory, and convert it
                foreach (string fileMask in convertFromFileMasks)
                {
                    foreach (RecordEtudiant file in listEtudiants)
                    {
                        newFilename = Path.GetFileNameWithoutExtension(file.Fiche.ToString()) + "." + outputExt;

                        //Check if the new filename already exists
                        if (File.Exists(outputDir + "\\" + newFilename))
                        {
                        }

                        //If OnImageConversionStart event is being subscribed to, raise it
                        if (OnImageConversionStart != null)
                        {
                            OnImageConversionStart(new ImageOpsEventArgs(file.Fiche.ToString() + convertTo.ToString()));
                        }
                        //Create and save new image file
                        String fichier = targetDir + "\\" + file.Fiche.ToString() + convertFromFileMasks[0].ToString();
                        Image img = new Bitmap(fichier);
                        if(img != null)
                        {
                            img.Save(targetDir + "\\" + newFilename, convertTo);
                        }

                        //If OnImageConversionComplete event is being subscribed to, raise it
                        if (OnImageConversionComplete != null)
                            OnImageConversionComplete(new ImageOpsEventArgs(newFilename));
                    } //foreach file in the directory

                } //foreach filemask

            }
            catch(Exception ex)
            {

            }
            finally
            {
//                if (frmExists != null)
//                    frmExists.Dispose();
            }
        }


        /// <summary>
        /// Gets the appropriate extension to use for the selected output image format
        /// </summary>
        /// <param name="inputExtension"></param>
        /// <returns>A string containing the appropriate file extenstion to use for output files</returns>
        private static string GetOutputExtension(string inputExtension)
        {
            switch (inputExtension)
            {
                case "Icon":
                    return "ico";

                case "Jpeg":
                    return "jpg";

                case "Tiff":
                    return "tif";

                default:
                    return inputExtension;
            }
        }

        private static Bitmap GetGrayscale(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            using (Graphics gfx = Graphics.FromImage(output))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][] 
                      {
                         new float[] {.3f, .3f, .3f, 0, 0},
                         new float[] {.59f, .59f, .59f, 0, 0},
                         new float[] {.11f, .11f, .11f, 0, 0},
                         new float[] {0, 0, 0, 1, 0},
                         new float[] {0, 0, 0, 0, 1}
                      });

                ImageAttributes attributes = new ImageAttributes();

                attributes.SetColorMatrix(colorMatrix);

                gfx.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height),
                   0, 0, input.Width, input.Height, GraphicsUnit.Pixel, attributes);
            }
            
            return output;
        }
    }
}
