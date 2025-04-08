using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalimpiaGUI
{
    internal class Paralimpia
    {
        public int Id { get; set; }
        public string Orszag { get; set; }
        public string Varos { get; set; }
        public int Ev { get; set; }
        public int Arany { get; set; }
        public int Ezust { get; set; }
        public int Bronz { get; set; }

        public Paralimpia(string sor)
        {
            var v = sor.Split('\t');
            Id = int.Parse(v[0]);
            Orszag = v[1];
            Varos = v[2];
            Ev = int.Parse(v[3]);
            Arany = int.Parse(v[4]);
            Ezust = int.Parse(v[5]);
            Bronz = int.Parse(v[6]);
        }
    }
}
