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

            // Decorator
            // É uma forma de fazer com que uma ou mais regras sejam executadas de uma só vez, passando pelo construtor outras classes que contém as suas próprias responsabilidades 

            // State
            // Baseado em um objeto que varia de estados onde cada um possui sua regra de negócio. Possui uma propriedade para controlar seus estados, essa propriedade é uma interface que pode ser herdada por classes que fazem parte do estado do objeto principal, e cada uma dessas classes implementam suas próprias regras.

            Orcamento reforma = new Orcamento(500);

            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Aprova();
            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Finaliza();
            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            Console.ReadKey();
        }
    }
}
