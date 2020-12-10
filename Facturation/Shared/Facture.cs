using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Shared
{
    public class Facture
    {
        public string code { get; }
        public string client { get; }
        public DateTime dateEmission { get; }
        public DateTime dateReglement { get; }
        public double montantDu { get; }
        public double montantRegle { get; }

        public Facture() { }

        public Facture(string cod, string c, DateTime dateE, DateTime dateR, double montantD, double montantR)
        {
            code = cod; client = c; dateEmission = dateE; dateReglement = dateR;
            montantDu = montantD; montantRegle = montantR;
        }
        
        public string getCode()
        {
            return code;
        }

        public double getMontantR()
        {
            return montantRegle;
        }

        public double getMontantD()
        {
            return montantDu;
        }
        public string getDateR()
        {
            return dateReglement.Date.ToString("dd-MM-yyyy");
        }

        public string getDateE()
        {
            return dateEmission.Date.ToString("dd-MM-yyyy");
        }
    }
}
