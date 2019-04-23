using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTask
{
    public partial class HotelApp : Form
    {
        public HotelApp()
        {
            InitializeComponent();
        }
        public Rooms Rooms { get; set; }

        private void From_ValueChanged(object sender, EventArgs e)
        {
            From.Value.ToString("dd/mm/yyyy");
        }

        private void To_ValueChanged(object sender, EventArgs e)
        {
            To.Value.ToString("dd/mm/yyyy");
        }

        private void HotelApp_Load(object sender, EventArgs e)
        {
            Peoples.Text = Rooms.NumberOfPersons;
            Beds.Text = Rooms.NumberOfBeds;
            From.Value = Rooms.ResidencyFrom;
            To.Value = Rooms.ResidencyTo;
        }

        private void Peoples_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             var Rooms = new Rooms();
             Rooms.NumberOfPersons = Peoples.Text;
             Rooms.NumberOfBeds = Beds.Text;
             Rooms.ResidencyFrom = From.Value;
             Rooms.ResidencyTo = To.Value;
             listBox2.Items.Add(Rooms);
             //listBox2.Items.Clear();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is Rooms)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = listBox2.SelectedItem is Rooms;
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox2.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                var item = (Rooms)listBox2.Items[index];
                var ff = new ShortForm() { Rooms = item };
                if (ff.ShowDialog(this) == DialogResult.OK)
                {
                    listBox2.Items.Remove(item);
                    listBox2.Items.Insert(index, item);
                }
            }
        }
    }
}
