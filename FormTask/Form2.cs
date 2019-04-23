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
    public partial class ShortForm : Form
    {
        public ShortForm()
        {
            InitializeComponent();
        }
        public Rooms Rooms { get; set; }

        private void ShortForm_Load(object sender, EventArgs e)
        {
            People.Text = Rooms.NumberOfPersons;
            Beds.Text = Rooms.NumberOfBeds;
            From.Value = Rooms.ResidencyFrom;
            To.Value = Rooms.ResidencyTo;
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            var Rooms = new Rooms();
            Rooms.NumberOfPersons = People.Text;
            Rooms.NumberOfBeds = Beds.Text;
            Rooms.ResidencyFrom = From.Value;
            Rooms.ResidencyTo = To.Value;
        }
    }
}
