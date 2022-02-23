using System;

namespace Design.Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IImposto icms = new ICMS();
            IImposto iss = new ISS();

            Orcamento orcamento = new Orcamento(500.0);

            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            calculador.RealizaImposto(orcamento, icms);
            calculador.RealizaImposto(orcamento, iss);

            Console.ReadKey();
        }
    }
}
