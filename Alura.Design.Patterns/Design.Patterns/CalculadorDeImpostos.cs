using System;

namespace Design.Patterns
{
    public class CalculadorDeImpostos
    {
        public void RealizaImposto(Orcamento orcamento, IImposto imposto)
        {
            Console.WriteLine(imposto.Calcula(orcamento));
        }
    }
}
