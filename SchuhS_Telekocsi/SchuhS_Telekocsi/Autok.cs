using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Telekocsi
{
    class Autok
    {
        //Indulás;Cél;Rendszám;Telefonszám;Féröhely
        public string Indulas;
        public string Cel;
        public string IndulasCel;
        public string Rendszam;
        public string Telefonszam;
        public int Ferohely;

        public Autok (string sor)
        {
            var dbok = sor.Split(';');
            this.Indulas = dbok[0];
            this.Cel = dbok[1];
            this.IndulasCel = dbok[0] + " - " + dbok[1];
            this.Rendszam = dbok[2];
            this.Telefonszam = dbok[3];
            this.Ferohely = int.Parse(dbok[4]);
        }
    }
}
