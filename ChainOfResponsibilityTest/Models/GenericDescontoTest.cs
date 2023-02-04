using ChainOfResponsibility.models;
using Shouldly;

namespace ChainOfResponsibilityTest.Models
{
    public abstract class GenericDescontoTest<T> where T : IDesconto
    {
        public void DadoValorCompra_CalculaDesconto_RetornaValorDesconto(decimal valorCompra, decimal valorDesconto)
        {
            // Arrange
            T tipoDesconto = Activator.CreateInstance<T>();

            // Act
            var valorDescontoAplicado = tipoDesconto.Calcula(valorCompra);

            // Assert
            valorDescontoAplicado.ShouldBe(valorDesconto);
        }

        public void ValorCompraNaoSeEnquadraNoDesconto_NaoPossuiProximaRegra_RetornaValorCompraSemDesconto(decimal valorCompra)
        {
            // Arrange
            T tipoDesconto = Activator.CreateInstance<T>();

            // Act
            var valorDesconto = tipoDesconto.Calcula(valorCompra);

            // Assert
            valorDesconto.ShouldBe(valorCompra);
        }

        public void ValorCompraNaoSeEnquadraNoDesconto_PossuiProximaRegra_RetornaValorDescontoBaseadoNaProximaRegra(
            decimal valorCompra, decimal valorDesconto, IDesconto proximo)
        {
            // Arrange
            T tipoDesconto = Activator.CreateInstance<T>();
            tipoDesconto.SetaProximo(proximo);

            // Act
            var valorDescontoProximaRegra = tipoDesconto.Calcula(valorCompra);

            // Assert
            valorDescontoProximaRegra.ShouldBe(valorDesconto);
        }
    }
}