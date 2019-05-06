using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using MiniSQLEngine;
using MiniSQLServer;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(2000);
            const string argPrefixIp = "ip=";
            const string argPrefixPort = "port=";

            string ip = "127.0.0.1";
            int port = 2400;
            foreach (string arg in args)
            {
                if (arg.StartsWith(argPrefixIp)) ip = arg.Substring(argPrefixIp.Length);
                else if (arg.StartsWith(argPrefixPort)) port = int.Parse(arg.Substring(argPrefixPort.Length));
            }
            if (ip == null || port == 0)
            {
                Console.WriteLine("ERROR. Usage: TCPClient ip=<ip> port=<port>");
                return;
            }

            using (TcpClient client = new TcpClient(ip, port))
            {
                NetworkStream networkStream = client.GetStream();
                byte[] inputBuffer = new byte[1024];
                byte[] endMessage = Encoding.ASCII.GetBytes("END");
                byte[] outputBuffer;
                MiniSQLClient.XmlParse xmlParse = new MiniSQLClient.XmlParse();
                Console.WriteLine("Write the name of the database: ");
                string dbname = Console.ReadLine();
                xmlParse = new MiniSQLClient.XmlParse();
                xmlParse.AddDatabase(dbname);
                Console.WriteLine("Write the name of the user: ");
                string inputUser = Console.ReadLine();
                xmlParse.AddUserName(inputUser);
                Console.WriteLine("Write the password of the user: ");
                string inputPass = Console.ReadLine();
                xmlParse.AddPassword(inputPass);
                string outputdb = xmlParse.GetOpenDatabase();

                outputBuffer = Encoding.ASCII.GetBytes(outputdb);

                while (Encoding.ASCII.GetString(inputBuffer, 0, networkStream.Read(inputBuffer, 0, 1024)) != "<Success/>")
                {

                    Console.WriteLine("Write the name of the database: ");
                    dbname = Console.ReadLine();
                    xmlParse = new MiniSQLClient.XmlParse();
                    xmlParse.AddDatabase(dbname);
                    Console.WriteLine("Write the name of the user: ");
                    inputUser = Console.ReadLine();
                    xmlParse.AddUserName(inputUser);
                    Console.WriteLine("Write the password of the user: ");
                    inputPass = Console.ReadLine();
                    xmlParse.AddPassword(inputPass);
                    outputdb = xmlParse.GetOpenDatabase();

                    outputBuffer = Encoding.ASCII.GetBytes(outputdb);
                }
                
                while(Console.ReadLine() != "END")
                {
                    xmlParse.AddQuery(Console.ReadLine());
                    outputBuffer = Encoding.ASCII.GetBytes(xmlParse.GetQuery());
                    networkStream.Write(outputBuffer, 0, outputBuffer.Length);

                    int readBytes = networkStream.Read(inputBuffer, 0, 1024);
                    Console.WriteLine("Response received: " + Encoding.ASCII.GetString(inputBuffer, 0, readBytes));

                    Thread.Sleep(2000);
                }
                networkStream.Write(endMessage, 0, endMessage.Length);
            }
        }


    }
}