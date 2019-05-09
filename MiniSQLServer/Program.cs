using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MiniSQLServer;
using System.Text.RegularExpressions;
using MiniSQLEngine;

namespace TCPServerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = null;
            CreateDataBase create = null;
            string res = null;
            const string argPrefixPort = "port=";

            int port = 2400;
            foreach (string arg in args)
            {
                if (arg.StartsWith(argPrefixPort)) port = int.Parse(arg.Substring(argPrefixPort.Length));
            }
            if (port == 0)
            {
                Console.WriteLine("ERROR. Usage: TCPClient ip=<ip> port=<port>");
                return;
            }

            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            Console.WriteLine("Server listening for clients");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connection accepted");

                var childSocketThread = new Thread(() =>
                {
                    byte[] inputBuffer = new byte[1024];

                    NetworkStream networkStream = client.GetStream();
                    string regExp = "<Open Database = \"(\\w+)\" User = \"(\\w+)\" Password = \"(\\w+)\"/>";
                    //Read message from the client
                    int size = networkStream.Read(inputBuffer, 0, 1024);
                    string request = Encoding.ASCII.GetString(inputBuffer, 0, size);
                    MiniSQLServer.XmlParse xmlParse = new MiniSQLServer.XmlParse();
                    byte[] outputBuffer = Encoding.ASCII.GetBytes("My answer is NO");
                    while (request != "END")
                    {
                        Match match = Regex.Match(request, regExp);
                        Console.WriteLine("Request received: " + request);
                        if (match.Success)
                        {
                            string[] data = xmlParse.GetData(request);
                            if(data[1]== "admin" && data[2]== "admin")
                            {
                                create = new CreateDataBase(data[0], data[1], data[2]);
                                 res = create.Execute(db);
                                if (res == MiniSQLEngine.Messages.CreateDatabaseSuccess || res == MiniSQLEngine.Messages.OpenDatabaseSuccess)
                                {
                                    outputBuffer = Encoding.ASCII.GetBytes(xmlParse.SetSuccess());
                                }
                                else
                                {
                                    outputBuffer = Encoding.ASCII.GetBytes(xmlParse.SetError(res));
                                }
                                    db = create.getDatabase();
                            }                  
                        }
                        else
                        {
                            res = db.Query(xmlParse.GetQuery(request));
                            outputBuffer = Encoding.ASCII.GetBytes(xmlParse.AddAnswer(res));
                        }
                        networkStream.Write(outputBuffer, 0, outputBuffer.Length);

                        size = networkStream.Read(inputBuffer, 0, 1024);
                        request = Encoding.ASCII.GetString(inputBuffer, 0, size);
                    }
                    client.Close();
                });
                childSocketThread.Start();
            }
        }
    }
}