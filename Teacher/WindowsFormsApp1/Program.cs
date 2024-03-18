using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    class Program
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int connectionDescription, int reservedValue);


        static List<string> IPHeadList = new List<string>();
        static List<string> macList = new List<string>();
        public static List<string> studentList = new List<string>();
        static SqlConnection con = new SqlConnection();
        static Thread[] threads = new Thread[255];
        static System.Timers.Timer aTimer = new System.Timers.Timer();
        static string path = "D:\\students.txt";
        static void Main(string[] args)
        {
            if (File.Exists(path))
                File.Delete(path);
            getIPHead();
            pingAll();
            GetAllLocalMachines();
            connectSQL();
            sign_in();
            get_name();


            aTimer.Elapsed += new ElapsedEventHandler(Theout);
            aTimer.Interval = 5000;
            aTimer.AutoReset = true;
            //aTimer.Enabled = true;

            con.Close();
            Console.ReadKey(true);
        }

        public static void getIPHead()
        {
            string HostName = Dns.GetHostName(); //得到主机名
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
            for (int i = 0; i < IpEntry.AddressList.Length; i++)
            {
                String IPHead = "";
                if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    string temps = IpEntry.AddressList[i].ToString();
                    char[] temp = temps.ToCharArray();
                    int k = 0;
                    int j = 0;
                    while (k != 3)
                    {
                        if (temp[j] == '.')
                            k++;
                        IPHead = IPHead + temp[j];
                        j++;
                    }
                    // Console.WriteLine(IPHead);
                    IPHeadList.Add(IPHead);
                }
            }
        }

        public static void pingIP(Object i)
        {
            //调用控制台
            /*
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("ping " + pingIP);
            Console.WriteLine(pingIP);
            p.StandardInput.WriteLine("exit");
            */
            Ping myPing = new Ping();
            foreach (var k in IPHeadList)
            {
                string pingIP = k + i.ToString();
                // myPing.Send(pingIP);
                PingReply rep = myPing.Send(pingIP, 200);
                /*(if (rep.Status == IPStatus.Success)
                {
                    Console.WriteLine(pingIP);

                }
                */
            }
        }

        static void pingAll()
        {
            for (int i = 1; i < threads.Length + 1; i++)
            {
                threads[i - 1] = new Thread(new ParameterizedThreadStart(pingIP));
                threads[i - 1].Start(i.ToString());
                threads[i - 1].DisableComObjectEagerCleanup();
            }
        }

        public static void GetAllLocalMachines()
        {
            //Console.WriteLine("arp命令开始执行：");
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("arp -a");
            p.StandardInput.WriteLine("exit");
            // ArrayList list = new ArrayList();
            StreamReader reader = p.StandardOutput;

            //string IPHead = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString().Substring(0, 3);
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                foreach (var temp in IPHeadList)
                {
                    //Console.WriteLine(temp);
                    //IPHead = temp;
                    line = line.Trim();
                    if (line.StartsWith(temp) && (line.IndexOf("动态") != -1))
                    {
                        // string IP = line.Substring(0, 15).Trim();
                        string Mac = line.Substring(line.IndexOf("-") - 2, 0x11).Trim();
                        Console.WriteLine("MAC:" + Mac);
                        if (!macList.Contains(Mac))
                            macList.Add(Mac);
                    }
                }
            }
            p.StandardInput.WriteLine("arp -d");
            p.StandardInput.WriteLine("exit");

            //Console.WriteLine("arp命令执行完毕");

            Console.WriteLine(" ");
        }
        static void connectSQL()
        {
            //string str = " server= http://sk9xh4.natappfree.cc;User ID=connect;Password=131;Database=DATABASE1.MDF";
            string str = " server=127.0.0.1;User ID=connect;Password=131;Database=DATABASE1.MDF";//
            //string str = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\lenovo\\Desktop\\Example_IPHostEntry_Ping\\Example_IPHostEntry_Ping\\App_Data\\Database1.mdf; Integrated Security = True; Connect Timeout = 30";
            con.Close();
            con.ConnectionString = str;
            con.Open();
            //Console.WriteLine("连接数据库成功！");
            //Console.WriteLine(" ");
        }

        private static void sign_in()
        {
            foreach (var i in macList)
            {

                string sql = "select Id,name from students where mac='" + i + "';";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataReader read;
                read = com.ExecuteReader();

                while (read.Read())
                {

                    string id = read["Id"].ToString();
                    string name = read["name"].ToString();

                   // Console.WriteLine(name);
                   // Console.WriteLine(" ");
                    if (!studentList.Contains(name))
                    {
                        studentList.Add(name);
                        Write(path, id, name);
                    }

                }
                read.Close();
            }
            Console.WriteLine("students.txt目录：" + path);
        }


        public static void get_name()
        {
            foreach (var i in studentList)
            {
                string sql = "select Id,name from students where name!='" + i + "';";
                SqlCommand com = con.CreateCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = sql;
            }

        }

        public static void Theout(object source, System.Timers.ElapsedEventArgs e)
        {
            macList.Clear();
            pingAll();
            GetAllLocalMachines();
            connectSQL();
            sign_in();
            con.Close();
        }


        public static void Write(string path, string id, string name)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            //获得字节数组
            StreamWriter writer = new StreamWriter(fs);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            // writer.WriteLine(string.Format("Service Start at {0}", DateTime.Now.ToString()));
            writer.WriteLine(id + "  " + name + DateTime.Now.ToString());
            writer.Flush();
            writer.Close();
        }
    }

}