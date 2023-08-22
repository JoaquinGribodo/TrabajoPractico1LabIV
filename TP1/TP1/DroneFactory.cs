using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class DroneFactory : IDroneFactory
    {
        public Drones CreateDrone(int id, string modelo, string responsable, int capacidad_kilos)
        {
            return new Drones
            {
                id = id,
                modelo = modelo,
                responsable = responsable,
                capacidad_kilos = capacidad_kilos
            };
        }
    }
}
