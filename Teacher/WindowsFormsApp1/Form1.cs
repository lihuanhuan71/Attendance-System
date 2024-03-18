using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Net.NetworkInformation;
//using System.DirectoryServices;
using System.Management;
//using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Timers;
using System.Net.Sockets;
using System.Threading;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (var i in Program.studentList)
            {
                string str = " server=192.168.1.111;User ID=connect;Password=131;Database=DATABASE1.MDF";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string sql = "select Id,name from students where name!='" + i + "';";
                SqlCommand com = con.CreateCommand();
                dataGridView1.DataSource = con;

            }
        }
    }
}
