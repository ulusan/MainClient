using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", 600);
                NetworkStream networkStream = tcpClient.GetStream();
                StreamWriter streamWriter = new StreamWriter("C:\\Deneme\\NewDATA.txt", true);
                StreamReader streamReader = new StreamReader(networkStream);
                string line = "";
                do
                {
                    line = streamReader.ReadLine();
                    if (line != null)
                    {
                        streamWriter.WriteLine(line);
                        streamWriter.Flush();
                        Console.WriteLine(line);
                    }
                } while (line != null);
                networkStream.Close();
                streamWriter.Close();
                streamReader.Close();
                tcpClient.Close();

            }
            catch(Exception exception)
            {
                Console.WriteLine("Hata Oluştu :" +exception.Message);
            }
            Console.Read();
                
        }
    }
}
