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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            DronesDB dronesDB = DronesDB.Instance;
            dataGridView1.DataSource = dronesDB.GetDronesList(new DroneFactory());
            if(dataGridView1.Rows.Count <= 0)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alta alta = new Alta();
            alta.ShowDialog();
            Refresh();
        }

        private int GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch(Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if(id != null)
            {
                Alta alta = new Alta(id);
                alta.ShowDialog();
                Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            try
            {
                if (id != null)
                {
                    DronesDB drone = DronesDB.Instance;
                    drone.Delete((int)id);
                    Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al eliminar.");
            }
        }

    }
}
