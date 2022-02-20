using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO;
using my_xml_lib;



namespace car_book
{
    public partial class Form1 : Form
    {            
        Socket mySocket;
        IPAddress IPAddr;
        IPEndPoint IPHost;
        System.Windows.Forms.Timer TMR_Rec;
        System.Windows.Forms.TextBox[] mTB;

        int p_in, p_out;
        bool flag_rec = false;

        String IP_Address_Source;
        String fullPath = Application.StartupPath.ToString() + "\\";
        String xmlName = "CarData.xml";

        public Form1()
        {

            InitializeComponent();
            CreateSocetRec();
            this.Text = fullPath + xmlName;

            mTB = new System.Windows.Forms.TextBox[4];
            mTB[0] = car_name;
            mTB[1] = car_year;
            mTB[2] = car_engine;
            mTB[3] = car_door;


            LIB_XML.SetXMLHead("car-book");
            LIB_XML.AddXMLFieldName("car_name");
            LIB_XML.AddXMLFieldName("car_year");
            LIB_XML.AddXMLFieldName("car_engine");
            LIB_XML.AddXMLFieldName("car_door");


            var colum1 = new DataGridViewColumn
            {
                HeaderText = "№",
                Width = 40,
                ReadOnly = true,
                Name = "number",
                Frozen = true
            };
            colum1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum1.CellTemplate = new DataGridViewTextBoxCell();

            var colum2 = new DataGridViewColumn
            {
                HeaderText = "марка\n авто",
                Width = 80,
                ReadOnly = true,
                Name = "name",
                Frozen = true
            };
            colum2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum2.CellTemplate = new DataGridViewTextBoxCell();

            var colum3 = new DataGridViewColumn
            {
                HeaderText = "год\n выпуска",
                Width = 80,
                ReadOnly = true,
                Name = "year",
                Frozen = true
            };
            colum3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum3.CellTemplate = new DataGridViewTextBoxCell();

            var colum4 = new DataGridViewColumn
            {
                HeaderText = "объем\n двигателя",
                Width = 80,
                ReadOnly = true,
                Name = "engine",
                Frozen = true
            };
            colum4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum4.CellTemplate = new DataGridViewTextBoxCell();

            var colum5 = new DataGridViewColumn
            {
                HeaderText = "дверей",
                Width = 80,
                ReadOnly = true,
                Name = "door",
                Frozen = true
            };
            colum5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum5.CellTemplate = new DataGridViewTextBoxCell();

            data_base.Columns.Add(colum1);
            data_base.Columns.Add(colum2);
            data_base.Columns.Add(colum3);
            data_base.Columns.Add(colum4);
            data_base.Columns.Add(colum5);
            data_base.AllowUserToAddRows = false;
            data_base.AllowUserToResizeColumns = false;
            data_base.AllowUserToResizeRows = false;


            TMR_Rec = new System.Windows.Forms.Timer
            {
                Interval = 10,
                Enabled = false
            };
            TMR_Rec.Tick += TimerRec;

        }
        private void add_Click(object sender, EventArgs e)
        {
            bool flag = false;

                foreach (TextBox v in mTB)
                    if (v.Text != "" && v.Text != "-" && v.Text != " ") flag = true;

            if (!flag)
            {
                MessageBox.Show("Заполните хоть одно поле", "Ошибка.");
            }
            else
            {
                int n = data_base.Rows.Add();
                data_base.Rows[n].Cells[0].Value = n + 1;
                data_base.Rows[n].Selected = true;
               
                for (int i = 1; i < mTB.Length + 1; i++)
                    data_base.Rows[n].Cells[i].Value = mTB[i - 1].Text;

                data_base.FirstDisplayedScrollingRowIndex = data_base.Rows[n].Index;
                //data_base.Columns[0].Visible = true;
                View_Count();
            }

        }

        private void CreateSocetRec()
        {
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            mySocket.ReceiveTimeout = 1;

            String host_name = System.Net.Dns.GetHostName();
            IPHostEntry host1 = Dns.GetHostEntry(host_name);
            this.Text = host_name;

            p_in = Convert.ToInt32(this.port_in.Text);
            IPAddr = IPAddress.Any;
            IPHost = new IPEndPoint(IPAddr, p_in);
            mySocket.Bind(IPHost);
        }

        private void TimerRec(object sender, EventArgs e)
        {
            EndPoint Remote = (EndPoint)IPHost;
            int recv = 0;
            byte[] buff = new byte[3];
            if (flag_rec == true)
            {
                try
                {
                    recv = mySocket.ReceiveFrom(buff, ref Remote);
                    log_rec_size.Text = "принято : " + recv + " байт";
                }
                catch { }

                if (recv > 0)
                {
                    if (buff[0] == 0x10)
                    {
                        SendData(buff, Remote);
                    }
                    else 
                    {
                        if (buff[0] == 0x11)
                        {
                            if (buff[1] == 0xfe) SendReq(Remote);
                        }
                    }

                    log.Text = "";
                    for (int i = 0; i < recv; i++)
                        log.Text += " " + buff[i].ToString();
                    log.Text += " [client::" + Remote.ToString() + "]";

                }
                else { }
            }
        }

        private void SendData(byte[] data, EndPoint endP)
        {                    
            byte[] word = new byte[255];
            int pbyte =0;
            
            if (data[1]==0xf1) // передаем все
            {
                if (data_base.Rows.Count > 0)
                {
                    //List <string> st_list = new List <string>();
                    //string stbuff="";

                    word[pbyte++] = 0x10; //TC
                    word[pbyte++] = 0xf1; //COD  
                    foreach (DataGridViewRow r in data_base.Rows)
                    {
                        byte[] _word = CreateWord(word, r, pbyte);
                        SendUDP(_word, endP);
                        pbyte = 2;
                    }

                }
                else 
                {
                    SendReq(endP); // посылаем ответ что пустые
                }
            }

            if (data[1]==0xf2)
            {
                if (data[2] <= data_base.Rows.Count)
                {
                    byte n = data[2];
                    word[pbyte++] = 0x10; //TC
                    word[pbyte++] = 0xf2; //COD  
                    byte[] _word = CreateWord(word, data_base.Rows[n-1], pbyte);
                    SendUDP(_word, endP);
                }
            }
        }

        private byte[] CreateWord(byte[] word, DataGridViewRow r, int pbyte)
        {
            word[pbyte++] = 0x02;
            word[pbyte++] = Convert.ToByte(Len_struct()); //размер структуры
            
            if (r.Cells[1].Value.ToString().Length > 0 && ValidCell(r.Cells[1].Value.ToString())) // модель
            {   
                word[pbyte++] = 0x09;
                word[pbyte++] = Convert.ToByte(r.Cells[1].Value.ToString().Length);
                byte[] t_byte = Encoding.Default.GetBytes(r.Cells[1].Value.ToString());
                foreach (byte b in t_byte)
                    word[pbyte++] = b;
            }

            if (r.Cells[2].Value.ToString().Length > 0 && ValidCell(r.Cells[2].Value.ToString())) // год
            {
                word[pbyte++] = 0x12;
                int D = int.Parse(r.Cells[2].Value.ToString());
                byte[] B = Dec2Byte(D, 2);
                foreach (byte b in B)
                    word[pbyte++] = b;
            }
            if (r.Cells[3].Value.ToString().Length > 0 && ValidCell(r.Cells[3].Value.ToString())) // двигатель
            {
                word[pbyte++] = 0x13;
                string str = r.Cells[3].Value.ToString();
                if ((str.IndexOf(".")) > 0) str = str.Replace(".", ",");
                float F = float.Parse(str);
                byte[] B = Float2Byte(F);
                foreach (byte b in B)
                    word[pbyte++] = b;
            }
            if (r.Cells[4].Value.ToString().Length > 0 && ValidCell(r.Cells[4].Value.ToString())) // двери
            {
                word[pbyte++] = 0x14;
                byte b = byte.Parse(r.Cells[4].Value.ToString());
                word[pbyte++] = b;
            }

            byte[] _word = new byte[pbyte];
            Array.Copy(word, 0, _word, 0, pbyte);
            return _word;

        }

        private bool ValidCell(string cell)
        {
            if (cell == "" || cell[0] == '-' || cell[0] == ' ') return false;
            return true;
        }

        private int Len_struct()
        {
            int len = 0;
            foreach (TextBox v in mTB)
                if (v.Text != "" && v.Text != "-" && v.Text != " ") len++;
            return len;
        }

        private byte[] Dec2Byte(int Dec, int n)
        {
            byte[] Byte = new byte[n];
            if (n == 2)
            {
                Byte[0] = (Byte)Dec;
                Byte[1] = (Byte)(Dec >> 8);
            }
            if (n == 4)
            {
                Byte[0] = (Byte)Dec;
                Byte[1] = (Byte)(Dec >> 8);
                Byte[2] = (Byte)(Dec >> 16);
                Byte[3] = (Byte)(Dec >> 24);
            }
            return Byte;
        }

        private byte[] Float2Byte(float F)
        {
            byte[] Byte = new byte[4];
            Byte = BitConverter.GetBytes(F);
            return Byte;
        }

        private void SendReq(EndPoint endP)
        {
            byte[] data = new byte[3];
            data[0] = 0x11;
            data[1] = 0xef;
            data[2] = (byte)data_base.Rows.Count;

            SendUDP(data, endP);
        }

        private void SendUDP(byte[] data, EndPoint endP)
        {
            if (fix.Checked == false)
            {            
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                sock.SendTo(data, endP);
                sock.Dispose();
                sock.Close();

            }
            else 
            { 
                p_out = Convert.ToInt32(port_out.Text);
                IP_Address_Source = ip.Text;
                UdpClient udpClient = new UdpClient(IP_Address_Source, p_out);
                udpClient.Send(data, data.Length);
            }   
        }

        private void car_name_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[а-я А-Я \n a-z A-Z]");
            MatchCollection match = regex.Matches(car_name.Text);
            String filter = "";
            for (int count = 0; count < match.Count; count++)
                filter += match[count].Value;
            car_name.Text = filter;
        }

        private void car_year_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection match = regex.Matches(car_year.Text);
            String filter = "";
            for (int count = 0; count < match.Count; count++)
                filter += match[count].Value;
            car_year.Text = filter;
        }

        private void car_tank_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9 \n . \n ,]");
            MatchCollection match = regex.Matches(car_engine.Text);
            String filter = "";
            for (int count = 0; count < match.Count; count++)
                filter += match[count].Value;
            car_engine.Text = filter;
        }

        private void car_door_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9 \n -]");
            MatchCollection match = regex.Matches(car_door.Text);
            String filter = "";
            for (int count = 0; count < match.Count; count++)
                filter += match[count].Value;
            car_door.Text = filter;
        }

        private void save_Click(object sender, EventArgs e)
        {
            List<string> list_data_table = new List<string>();
            
            foreach (DataGridViewRow r in data_base.Rows)
            {
                string srow = "";
                for(int i = 1; i < r.Cells.Count; i++)
                    srow += "#"+r.Cells[i].Value;
                list_data_table.Add(srow);
            }

            if (LIB_XML.Save_XML(list_data_table, fullPath, xmlName))
                MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
            else
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");

        }

        private void load_Click(object sender, EventArgs e)
        {
            data_base.Rows.Clear();
            int c_item;
            if ((c_item = LIB_XML.Load_XML(fullPath, xmlName)) > 0)
            {
                for (int i = 0; i < c_item; i++)
                {
                    int n = data_base.Rows.Add();
                    int p = 0;
                    data_base.Rows[n].Cells[p++].Value = (n + 1).ToString();
                    List<string> r = LIB_XML.GetRows(i);
                    foreach (string s in r)
                        data_base.Rows[n].Cells[p++].Value = s;
                }
            }
            else 
            {
                MessageBox.Show("XML файл не найден.", "Ошибка.");
            }

                //if (File.Exists(fullPath + xmlName))
                //{
                //    DataSet ds = new DataSet(); 
                //    ds.ReadXml(fullPath + xmlName);
                
                //    foreach (DataRow item in ds.Tables[LIB_XML.GetXMLHead()].Rows)
                //    {
                //        int n = data_base.Rows.Add();
                //        data_base.Rows[n].Cells[0].Value = (n+1).ToString(); 
                //        data_base.Rows[n].Cells[1].Value = item["car_name"]; 
                //        data_base.Rows[n].Cells[2].Value = item["car_year"];
                //        data_base.Rows[n].Cells[3].Value = item["car_engine"];
                //        data_base.Rows[n].Cells[4].Value = item["car_door"];
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("XML файл не найден.", "Ошибка.");
                //}

            View_Count();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (data_base.SelectedRows.Count > 0)
            {
                int n = data_base.SelectedRows[0].Index;
                data_base.Rows.RemoveAt(data_base.SelectedRows[0].Index); 
                for (; n < data_base.Rows.Count; n++)
                    data_base.Rows[n].Cells[0].Value = (n + 1).ToString();

            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка.");
            }

            View_Count();
        }
        private void View_Count()
        { 
            c_data.Text = "всего " + data_base.Rows.Count.ToString();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            data_base.Rows.Clear();
            data_base.Refresh();
            View_Count();
        }
        
        private void fix_CheckedChanged(object sender, EventArgs e)
        {
            if (fix.Checked)
            {
                ip.Enabled = false;
                port_out.Enabled = false;
            }
            else
            { 
                ip.Enabled=true;
                port_out.Enabled=true;
            }
        }

        private void svr_run_Click(object sender, EventArgs e)
        {
            CreateSocetRec();

            if (flag_rec == true)
            {
                svr_run.BackColor = Color.WhiteSmoke;
                TMR_Rec.Stop();
            }
            else
            {
                svr_run.BackColor = Color.SkyBlue;
                TMR_Rec.Start();
            }

            flag_rec = !flag_rec;
        }


    }
}
