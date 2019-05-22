using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Media;


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

        private void Services_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            Rooms.Services = new List<string>();        
            
            foreach (string s in Services.CheckedItems)                         
                if (s != null) Rooms.Services.Add(s);

            listBox2.Items.Add(Rooms);         
            this.tabControl1.SelectedIndex = 1;

            // чистка полей

            Peoples.Text = null;
            Beds.Text = null;
            From.Value = DateTime.Now;
            To.Value = DateTime.Now;
            for (int i = 0; i<4; i++ )
                Services.SetItemChecked(i, false); 
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
        //private DateTime expiry;

        private void Alert_Click(object sender, EventArgs e) // ОЧЕНЬ ВАЖНАЯ КНОПКА
        {
            string title = " КРАСТНАЯ УГРОЗА ";
            TabPage ALERT = new TabPage(title);
            ALERT.BackColor = Color.Red;
            tabControl1.TabPages.Add(ALERT);
            this.tabControl1.SelectedIndex = 3;



            // label настройка и добавление

            Label label = new Label();
            label.Location = new Point(0, 0);
            label.Text = "ВЫ БУДЕТЕ РАССТРЕЛЯНЫ, ЗА СБОР ЛИЧНОЙ ИНФОРМАЦИИ \nВСЕГО ХОРОШЕГО!";
            label.Font = new Font("Tobota", 13, FontStyle.Bold);
            label.ForeColor = Color.Snow;
            label.AutoSize = true;
            ALERT.Controls.Add(label);

            //Timer timer = new Timer();
            //TimeSpan delay = TimeSpan.FromMinutes(1);

            //expiry = DateTime.Now.Add(delay);
            //timer.Start();
            //TextBox textBox = new TextBox();
            //textBox.Location = new Point(0, 40);
            //textBox.Font = new Font("Tobota", 13, FontStyle.Bold);

            //TimeSpan remaining = expiry - DateTime.Now;
            //textBox.Text = remaining.ToString();
             
            try
            {
                SoundPlayer sndplayr = new
                         SoundPlayer(FormTask.Properties.Resources.SSSR);
                sndplayr.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + ex.StackTrace.ToString(),
                               "Error");
            }
        }

        private void NO_Click(object sender, EventArgs e)
        {
            label14.Text =  "*Невозможно выполнить эту операцию";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Peoples.Text = null;
            Beds.Text = null;
            From.Value = DateTime.Now;
            To.Value = DateTime.Now;
            for (int i = 0; i < 4; i++)
                Services.SetItemChecked(i, false);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Заявка|*.hotelapp" };

            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;

            var rooms = new Rooms()
            {
                ResidencyTo = To.Value,
                ResidencyFrom = From.Value,
                NumberOfPersons = Peoples.Text,
                NumberOfBeds = Beds.Text,
            };
            var xs = new XmlSerializer(typeof(Rooms));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, rooms);
            file.Close();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Заявка|*.hotelapp" };

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(Rooms));
            var file = File.OpenRead(ofd.FileName);
            var rooms = (Rooms)xs.Deserialize(file);
            file.Close();

            To.Value = rooms.ResidencyTo;
            From.Value = rooms.ResidencyFrom;
            Peoples.Text = rooms.NumberOfPersons;
            Beds.Text = rooms.NumberOfBeds;
            listBox2.Items.Add(rooms);
            this.tabControl1.SelectedIndex = 2;
        }
    }
}
