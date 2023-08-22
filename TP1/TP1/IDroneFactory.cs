using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public interface IDroneFactory
    {
        Drones CreateDrone(int id, string modelo, string responsable, int capacidad_kilos);
    }
}
