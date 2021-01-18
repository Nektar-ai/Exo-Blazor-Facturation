using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation.Shared
{
    public class ChiffreAffaire
    {        
       
        public double chiffreAffairesD { get; set; }
        public double chiffreAffairesR { get; set; }
        public List<Facture> listFac { set; get; }
        public string year { get; set; }

        public ChiffreAffaire() { }

        public ChiffreAffaire(string y, List<Facture> listF)
        {
            this.year = y;
            listFac = listF;                                    
        }

        public ChiffreAffaire(List<Facture> listF)
        {
            listFac = listF;
            
        }

        public ChiffreAffaire (string y)
        {
            this.year = y;
        }


/*        public List<Facture> getListFac()
        {
            return listFac;
        }*/

        public string getYear()
        {
            return this.year;
        }

        public double getCAD()
        {
            return this.chiffreAffairesD;
        }

        public double getCAR()
        {
            return this.chiffreAffairesR;
        }


        /*
                public void CalculerCAD()
                {
                    foreach (Facture f in this.listFac)
                    {
                        this.chiffreAffairesD += f.getMontantD();
                    }

                }

                public void CalculerCAR()
                {
                    foreach (Facture f in this.listFac)
                    {
                        this.chiffreAffairesR += f.getMontantR();
                    }

                }*/
    }
}
