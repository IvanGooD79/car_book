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

namespace client
{
    public partial class Form1 : Form
    {
        Socket mySocket;
        IPAddress IPAddr;
        IPEndPoint IPHost;

        int p_in, p_out;
        String IP_Address_Source;
        System.Windows.Forms.Timer TMR_Rec;
        int pRows = 0;
        bool freq = false;
        int count_car = 0;
        
         public Form1()
        {
            InitializeComponent();
            CreateSocetRec();

            var colum1 = new DataGridViewColumn();
            colum1.HeaderText = "№";
            colum1.Width = 40;
            colum1.ReadOnly = true;
            colum1.Name = "number";
            colum1.Frozen = true;
            colum1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum1.CellTemplate = new DataGridViewTextBoxCell();

            var colum2 = new DataGridViewColumn();
            colum2.HeaderText = "марка\n авто";
            colum2.Width = 80;
            colum2.ReadOnly = true;
            colum2.Name = "name";
            colum2.Frozen = true;
            colum2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum2.CellTemplate = new DataGridViewTextBoxCell();

            var colum3 = new DataGridViewColumn();
            colum3.HeaderText = "год\n выпуска";
            colum3.Width = 80;
            colum3.ReadOnly = true;
            colum3.Name = "year";
            colum3.Frozen = true;
            colum3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum3.CellTemplate = new DataGridViewTextBoxCell();

            var colum4 = new DataGridViewColumn();
            colum4.HeaderText = "объем\n двигателя";
            colum4.Width = 80;
            colum4.ReadOnly = true;
            colum4.Name = "engine";
            colum4.Frozen = true;
            colum4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colum4.CellTemplate = new DataGridViewTextBoxCell();

            var colum5 = new DataGridViewColumn();
            colum5.HeaderText = "дверей";
            colum5.Width = 80;
            colum5.ReadOnly = true;
            colum5.Name = "door";
            colum5.Frozen = true;
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
                Enabled = true
            };
            TMR_Rec.Tick += TimerRec;
        }

        private void CreateSocetRec()
        {
            p_in = Convert.ToInt32(this.port_in.Text);
            p_out = Convert.ToInt32(this.port_out.Text);
            IP_Address_Source = ip.Text;

            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            mySocket.ReceiveTimeout = 1;

            String host_name = System.Net.Dns.GetHostName();
            IPHostEntry host1 = Dns.GetHostEntry(host_name);

            //p_in = Convert.ToInt32(this.port_in.Text);
            IPAddr = IPAddress.Any;
            IPHost = new IPEndPoint(IPAddr, p_in);
            mySocket.Bind(IPHost);
        }

        private void TimerRec(object sender, EventArgs e)
        {
            EndPoint Remote = (EndPoint)IPHost;
            int recv = 0;
            byte[] buff = new byte[1024];

                try
                {
                    recv = mySocket.ReceiveFrom(buff, ref Remote);
                }
                catch { }

                if (recv > 0)
                {
                    if (buff[0] == 0x10)
                    {
                        if (buff[1] == 0xf1 || buff[1] == 0xf2)
                        {
                            ParserData(buff, recv, Remote);
                            freq = false;
                            WriteTerminal(buff, recv, Remote);
                    }
                    }
                    else
                    {
                        if (buff[0] == 0x11)
                        {
                            if (buff[1] == 0xef)
                            {
                                count_car = buff[2];
                                WriteTerminal(buff, recv, Remote);
                            }
                        }
                    }

                }
                else { }
        }

        private void ParserData(byte[] data, int size, EndPoint endP)
        {
            List<string> st_list = new List<string>();
            string stbuff = "";

            if (data[2] == 0x02 && data[3] > 0)
            {
                byte cfield = data[3];
                
                for (int i = 4; i < size; i++)
                {
                    if (data[i] == 0x09)
                    {
                        //if (data[i + 1] > 0)
                        //{
                            int n = data[i + 1];
                            byte[] name = new byte[n];
                            Array.Copy(data, i + 2, name, 0, n);
                            stbuff = Encoding.ASCII.GetString(name);
                            st_list.Add(stbuff);
                            i += n + 2;
                        //}
                        //else { i+=2; st_list.Add("-"); }
                    } 
                    else st_list.Add("-");

                    if (data[i] == 0x12)
                    {
                        
                        byte[] b = new byte[2];
                        b[0] = data[i + 1];
                        b[1] = data[i + 2];
                        int year = b[0];
                            year+= b[1]<<8;

                        stbuff = year.ToString();
                        st_list.Add(stbuff);
                        i += 3;
                    } else st_list.Add("-");

                    if (data[i] == 0x13)
                    {

                        byte[] b = new byte[4];
                        b[0] = data[i + 1];
                        b[1] = data[i + 2];
                        b[2] = data[i + 3];
                        b[3] = data[i + 4];
                        float engine = BitConverter.ToSingle(b, 0);

                        stbuff = engine.ToString();
                        st_list.Add(stbuff);
                        i += 5;
                    } else st_list.Add("-");

                    if (data[i] == 0x14)
                    {
                        byte door = data[i + 1];
                        stbuff = door.ToString();
                        st_list.Add(stbuff);
                        i += 2;
                    } else st_list.Add("-");
                }
                WriteTable(st_list);
            }

        }

        private void WriteTable(List<string> element)
        {
            int n = data_base.Rows.Add();
            data_base.Rows[n].Cells[0].Value = n + 1;
            data_base.Rows[n].Selected = true;
            for (int i = 1; i < element.Count + 1; i++)
                data_base.Rows[n].Cells[i].Value = element.ElementAt(i-1);

            data_base.FirstDisplayedScrollingRowIndex = data_base.Rows[n].Index;
            c_data.Text = "загружено " + data_base.Rows.Count.ToString();
        }

        private void WriteTerminal(byte[] recdata, int size, EndPoint endP)
        {
            String TData = "";
            String time = "время:" + System.DateTime.Now.Hour.ToString() + ":"
                        + System.DateTime.Now.Minute.ToString() + ":"
                        + System.DateTime.Now.Second.ToString() + "."
                        + System.DateTime.Now.Millisecond.ToString();

            for (int i = 0; i < size; i++)
                TData += recdata[i].ToString("X2") + " ";

            terminal.ClearSelected();
            terminal.Items.Insert(pRows, ">> " + size + " байт -- получено (<ответ от сервера>) данных в базе [ " + count_car.ToString() + " ]");
            terminal.SetSelected(pRows++, true);
            terminal.Items.Insert(pRows, TData);
            terminal.SetSelected(pRows++, true);
            terminal.Items.Insert(pRows, time);
            terminal.SetSelected(pRows++, true);
            pRows = 0;

            if (count_car > 0 && freq == true)
            {
                    byte[] data = new byte[2];
                    data[0] = 0x10;
                    data[1] = 0xf1;
                    SendData(data);
            }
        }

        private void req1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[2];
            data[0] = 0x11;
            data[1] = 0xfe;
            freq = false;
            SendData(data);
        }

        private void req2_Click(object sender, EventArgs e)
        {
            if (count_car > 0)
            {
                data_base.Rows.Clear();
                byte[] data = new byte[3];
                data[0] = 0x10;
                data[1] = 0xf2;
                data[2] = byte.Parse(textBox1.Text.ToString());
                freq = false;
                if (data[2] != 0) SendData(data);
            }
            else 
            {
                byte[] data = new byte[2];
                data[0] = 0x11;
                data[1] = 0xfe;
                freq = false;
                SendData(data);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            terminal.Items.Clear();
            pRows = 0;
        }

        private void req3_Click(object sender, EventArgs e)
        {
            freq = true;
            data_base.Rows.Clear();
            byte[] data = new byte[2];
            // запрос статуса
            data[0] = 0x11;
            data[1] = 0xfe;
            SendData(data);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            data_base.Rows.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection match = regex.Matches(textBox1.Text);
            String filter = "";
            for (int count = 0; count < match.Count; count++)
                filter += match[count].Value;
            textBox1.Text = filter;
        }

        private void port_in_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection match = regex.Matches(port_in.Text);
            String filter = "";
            for (int count = 0; count < match.Count; count++)
                filter += match[count].Value;
            port_in.Text = filter;

            CreateSocetRec();
        }

        private void port_out_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection match = regex.Matches(port_out.Text);
            String filter = "";
            for (int count = 0; count < match.Count; count++)
                filter += match[count].Value;
            port_out.Text = filter;
        }

        private void ip_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[0-9 \.]");
            MatchCollection match = regex.Matches(ip.Text);

            String filter = "";
            for (int count = 0; count < match.Count; count++)
                filter += match[count].Value;
            ip.Text = filter;
        }

        private void SendData(byte[] data)
        {
           try
            {
                p_in = Convert.ToInt32(this.port_in.Text);
                p_out = Convert.ToInt32(this.port_out.Text);
                IP_Address_Source = ip.Text;

                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP_Address_Source), p_out);
                IPEndPoint iep_ = new IPEndPoint(IPAddress.Parse("127.0.0.1"), p_in);
                sock.Bind(iep_);
                sock.SendTo(data, iep);
                sock.Dispose();
                sock.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error "+ ex); }
        }


    }
}
