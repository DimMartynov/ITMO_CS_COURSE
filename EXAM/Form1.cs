using EXAM.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAM
{
    public partial class Form1 : Form
    {
        private readonly DataBase _dataBase;

        private const string _connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyDB;Data Source=DESKTOP-GN6M6TE\\SQLEXPRESS";

        public Form1()
        {
            InitializeComponent();
            _dataBase = new DataBase(_connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contents = _dataBase.ShowContent();

            var stringContent = contents
                .Select(
                    item =>
                        $"{item.NCanonId}      {item.DtReportDate} " +
                        $"     {item.NTerOtdelenie}      {item.VProcent}" +
                        $"      {item.NTerPodrazdel}")
                .ToList();

            label6.Text = string.Join($"\n", stringContent);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var nCanonId = int.Parse(textBox1.Text);
            var dtReportDate = DateTime.Parse(textBox2.Text);
            var nTerOtdelenie = int.Parse(textBox3.Text);
            var vProcent = textBox4.Text.Split('.');
            var nTerPodrazdel = int.Parse(textBox5.Text);

            var data = new OurTableIn
            {
                NCanonId = nCanonId,
                DtReportDate = dtReportDate,
                NTerOtdelenie = nTerOtdelenie,
                VProcent = vProcent,
                NTerPodrazdel = nTerPodrazdel,
            };

            _dataBase.AddContent(data);
        }

        
    }
}
