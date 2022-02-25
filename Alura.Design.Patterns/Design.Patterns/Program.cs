using System;

namespace Design.Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Strategy
            // Interface que contém um método genérico e pode ser herdado para classes que queiram implementar sua regra de negócio ao mesmo método

            // Chain of Responsibility
            // Uma interface parecida com o pattern strategy, porém, é possível fazer com que uma corrente de regra de negócio seja executada caso a regra do momento não caiba ao processo.

            // Template Method
            // Consiste em uma classe abstrata onde se encontra um método seguindo um algoritimo padrão e outros métodos abstratos que podem ser implementados de acordo com a regra de negócio da classe que a implemente

            CalculadorDeDescontos calculador = new CalculadorDeDescontos();

            Orcamento orcamento = new Orcamento(500);
            orcamento.AdicionaItem(new Item("Garfo", 80.0));
            orcamento.AdicionaItem(new Item("Faca", 60.0));
            orcamento.AdicionaItem(new Item("Faca", 60.0));
            orcamento.AdicionaItem(new Item("Faca", 60.0));
            orcamento.AdicionaItem(new Item("Faca", 60.0));

            Console.WriteLine(calculador.Calcula(orcamento));

            Console.ReadKey();
        }
    }
}
