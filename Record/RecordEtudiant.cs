using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertImages.Record
{
    public class RecordEtudiant
    {
        public Int16 Numero { get; set; }
        public String NomPrenom { get; set; }
        public String Date { get; set; }
        public UInt32 Fiche { get; set; }
        public Int16 Casier { get; set; }
        public String Telephone { get; set; }
        public RecordEtudiant(String[] pRecord)
        {
            int shift = 0;
            Numero = Convert.ToInt16(pRecord[0]);
            while (pRecord[++shift] != "")
            {
                if (shift > 1) NomPrenom += " ";
                NomPrenom += pRecord[shift];
            }

            // Évaluation du champ suivant, et ne pas traiter la date
            if(pRecord[++shift] == "(")
            {
                Date = pRecord[shift++] + pRecord[shift++] + pRecord[shift++];
            }
            Fiche = Convert.ToUInt32(pRecord[shift]);
            Casier = Convert.ToInt16(pRecord[++shift]);
            Telephone = "(" + pRecord[++shift] + ") " + pRecord[++shift];
        }
    }
}
