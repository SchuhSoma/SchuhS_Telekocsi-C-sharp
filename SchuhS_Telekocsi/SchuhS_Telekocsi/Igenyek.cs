using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Telekocsi
{
    class Igenyek
    {
        //Azonosító;Indulás;Cél;Személyek
        public string Azonosito;
        public string Indulas;
        public string Cel;
        public string IndulasCel;
        public int Szemelyek;

        public Igenyek(string sor)
        {
            var dbok = sor.Split(';');
            this.Azonosito = dbok[0];
            this.Indulas = dbok[1];
            this.Cel = dbok[2];
            this.IndulasCel = dbok[1] + " - " + dbok[2];
            this.Szemelyek = int.Parse(dbok[3]);
        }
    }
}
