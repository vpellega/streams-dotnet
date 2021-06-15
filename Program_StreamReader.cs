using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Streams.Modelos;

namespace Streams
{
    partial class Program
    {
        static void GetFileWithStreamReader(string[] args)
        {

            using (var fileStream = new FileStream("contas.txt", FileMode.Open))
            using(var streamReader = new StreamReader(fileStream))
            {
                while(!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();

                    var contaCorrente = ConverterStringParaContaCorrente(line);

                    Console.WriteLine(contaCorrente.ToString());
                }
            }

            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] linhaConvertida = linha.Split(',');

            var agencia = int.Parse(linhaConvertida[0]);
            var numero = int.Parse(linhaConvertida[1]);
            var salario = double.Parse(linhaConvertida[2]);
            var titular = linhaConvertida[3];

            var contaCorrente = new ContaCorrente(agencia, numero);
            contaCorrente.Depositar(salario);

            var cliente = new Cliente();
            cliente.Nome = titular;
            contaCorrente.Titular = cliente;

            return contaCorrente;
        }

    }
}
