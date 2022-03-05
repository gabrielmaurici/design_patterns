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

            // Builder
            // É usado para ajudar na criação de um objeto muito grande. Cria-se uma classe builder onde a mesma tem métodos de construção para cada propriedade e um método que retorna o objeto principal por inteiro.

            NotaFiscalBuilder criador = new ();

            criador.ParaEmpresa("Apple")
                .ComCnpj("23.456.789/0001-12")
                .comItem(new ItemDaNota("Iphone", 8500.0))
                .comItem(new ItemDaNota("Apple Watch", 2400.0))
                .NaDataAtual()
                .ComObservacoes("Qualquer");

            NotaFiscal nf = criador.Constroi();

            Console.WriteLine(nf);

            Console.ReadKey();
        }
    }
}
