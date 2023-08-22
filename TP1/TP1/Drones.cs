using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public class Drones : CloneDrone
    {
        public int id { get; set; }
        public string modelo { get; set; }
        public string responsable { get; set; }
        public int capacidad_kilos { get; set; }

        public override CloneDrone Clone()
        {
            return (CloneDrone)this.MemberwiseClone();
        }

    }
}
