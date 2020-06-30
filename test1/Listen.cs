using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace test1
{
    public class Listen
    {
        //TcpListener tcpListen;
        TcpClient tcpclnt;
        Dictionary<int, string> m_dict;
        int res; 
       public Listen(TcpClient t , Dictionary<int,string> d , int r)
        {
            //tcpListen = tl;
            tcpclnt = t;
            m_dict = d;
            res = r; 
        }

        public void fillDict()
       {
            while (true)
            {
                //res = 9;
                NetworkStream stm = tcpclnt.GetStream();
                byte[] ba = new byte[100];
                int k = stm.Read(ba, 0, 100);
                if (k > 0)
                {
                    string Response = Encoding.ASCII.GetString(ba);
                    Response = Response.Substring(0, Response.IndexOf("$"));
                    if(Response == "ack!" )
                    {
                        res = 1; 
                        continue;
                    }
                   else if(Response == "receivernotvalid")
                    {
                        res = 0;
                        continue;
                    }
                    else
                    {
                        res = 9;
                        string[] portdata = Response.Split('|');
                        m_dict.Add(Int32.Parse(portdata[0]), portdata[1]); 
                    } 
                }
            }
       }
    }
}
