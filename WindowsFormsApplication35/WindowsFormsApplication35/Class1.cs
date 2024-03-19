using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication35
{
    class Produs
    {
        public string denumire;
        public int cantitate;
        public int pret;

        public Produs(string d, int c, int p)
        {
            denumire = d;
            cantitate = c;
            pret = p;
        }
        public Produs()
        { }

        public string af()
        {
            return denumire + "............................................................" + Convert.ToString(cantitate) + " x " + Convert.ToString(pret) + "\n";
        }
    }

}
