using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Streams
{
    partial class Program
    {
        static void GetFile()
        {
            
            using(var fileStream = new FileStream("arquivo.txt", FileMode.Open))
            {
                int bytesLidos = -1;

                byte[] buffer = new byte[10];

                while(bytesLidos != 0)
                {
                    bytesLidos = fileStream.Read(buffer, 0, buffer.Length);
                    Read(buffer, bytesLidos);
                }
            }
        }
        static void Read(byte[] bytes, int byteslidos) 
        {
            Encoding encoding = Encoding.UTF8;
            string conteudoArquivo = encoding.GetString(bytes, 0, byteslidos);

            Console.WriteLine($"{conteudoArquivo}, {byteslidos}");
        }
    }
}