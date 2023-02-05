using ChainOfResponsibility.models;

namespace ChainOfResponsibility;
class Program
{
    static void Main(string[] args)
    {
        var desconto10Porcento = new Desconto10Porcento();
        var desconto20Porcento = new Desconto20Porcento();
        var desconto30Porcento = new Desconto30Porcento();

        desconto10Porcento.SetaProximo(desconto20Porcento)
                          .SetaProximo(desconto30Porcento);

        var valorDesconto = desconto10Porcento.Calcula(250);

        Console.WriteLine(valorDesconto);
    } 
}
