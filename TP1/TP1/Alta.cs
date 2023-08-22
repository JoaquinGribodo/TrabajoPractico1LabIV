using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class Alta : Form
    {

        private int? id;
        public Alta(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if(this.id != null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            DronesDB drone = DronesDB.Instance;
            Drones drones = drone.GetDronesList((int)id, new DroneFactory());
            txtModel.Text = drones.modelo;
            txtReponsable.Text = drones.responsable;
            txtCapacidad.Text = drones.capacidad_kilos.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DronesDB drones = DronesDB.Instance;
            try
            {
                if(id == null)
                {
                    drones.Add(txtModel.Text, txtReponsable.Text, int.Parse(txtCapacidad.Text));
                }
                else
                {
                    drones.Update((int)id, txtModel.Text, txtReponsable.Text, int.Parse(txtCapacidad.Text));
                }
                this.Close();

            }
            catch
            {
                MessageBox.Show("Ocurrió un error al agregar.");
            }
        }


    }
}
