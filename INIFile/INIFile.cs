using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertImages.INIFile
{
    class INIFile
    {
        private StreamReader read;
        public String Filename { get; set; }
        public Boolean IsOpen { get { return isOpen; } }
        private Boolean isOpen = false;
        public INIFile(String pFilename)
        {
            Filename = pFilename;
            try
            {
                read = File.OpenText(Filename);
                isOpen = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("*** ERREUR *** Fichier " + Filename + " introuvable.");
            }
        }
        public String GetVariableFrom(String pGroup, String pTag)
        {
            Boolean gotGroup = false;
            String ret = "";
            String s;
            if(!IsOpen)
            {
                read = File.OpenText(Filename);
                isOpen = true;
            }
            while ((s =  read.ReadLine()) != null)
            {
                if (s.Length > 0)
                {
                    // Trouve le groupe
                    if (s[0] != ';') // N'est pas un Commentaire;
                    {
                        if (s[0] == '[') // Un nouveau Group
                        {
                            String[] g = s.Split(new char[] { '[', ']' });
                            if (g[1] == pGroup) // Le Group a été identifié
                            {
                                gotGroup = true;
                            }
                            else
                            {
                                gotGroup = false;
                            }
                        }
                        if (gotGroup) // Trouver le Tag
                        {
                            String[] t = s.Split('=');
                            if (t[0] == pTag)
                            {
                                ret = t[1];
                                break;
                            }
                        }
                    }
                }
            }
            read.Close();
            isOpen = false;
            return ret;
        }
    }
}
