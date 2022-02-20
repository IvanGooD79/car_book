using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace my_xml_lib
{
    public class LIB_XML
    {
        static string XML_HEAD;
        static List<string> XML_BODY = new List<string>();
        static DataSet ds = new DataSet();

        public static bool Save_XML(List<string> data_field, string fullPath, string xmlName)
        {
            if (ValidXMLFormat())
            {
                try
                {
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    dt.TableName = XML_HEAD;
                    foreach (string name in XML_BODY)
                        dt.Columns.Add(name);
                    ds.Tables.Add(dt);


                    foreach (string data in data_field)
                    {
                        DataRow row = ds.Tables[XML_HEAD].NewRow();
                        string[] s = ParsStr(data);
                        if (XML_BODY.Count == s.Length)
                        {
                            for (int i = 0; i < s.Length; i++)
                            {
                                row[XML_BODY[i]] = s[i];
                            }
                        }
                        else return false;

                        ds.Tables[XML_HEAD].Rows.Add(row);
                    }

                    ds.WriteXml(fullPath + xmlName);
                    return true;
                }
                catch
                {
                    return false;
                }
            } return false;
        }

        public static int Load_XML(string fullPath, string xmlName)
        {
            ds.Clear();
            if (File.Exists(fullPath + xmlName))
            {
                ds.ReadXml(fullPath + xmlName);
                return ds.Tables[GetXMLHead()].Rows.Count;
            }
            else return -1;
        }

        public static List<string> GetRows(int index)
        { 
            DataRow item = ds.Tables[LIB_XML.GetXMLHead()].Rows[index];
            int c_colum = ds.Tables[LIB_XML.GetXMLHead()].Columns.Count;
            List<string> r = new List<string>();
            for (int i = 0;i < c_colum;i++)
                r.Add(item[i].ToString());    
            return r;
        }
        public static void SetXMLHead(string xml_head)
        { 
            XML_HEAD = xml_head;
        }

        public static string GetXMLHead()
        { 
            return XML_HEAD;
        }

        public static void AddXMLFieldName(string name)
        {
            XML_BODY.Add(name);
        }

        public static int GetXMLBodySize()
        { 
            return XML_BODY.Count;
        }

        private static bool ValidXMLFormat()
        { 
            if (XML_BODY.Count == 0 || XML_HEAD.Length == 0) return false;
            else return true;
        }

        private static string[] ParsStr(string str)
        {
            char[] charsToTrim = {'*', ' ', '\'', '#'};
            str = str.Trim(charsToTrim);
            string[] subs = str.Split('#');
            return subs;
        }

    }
}
