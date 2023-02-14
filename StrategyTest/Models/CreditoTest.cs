using Shouldly;
using Strategy.Models;

namespace StrategyTest.Models
{
    public class CreditoTest
    {
        [Fact(DisplayName = "Recebe o valor de um pagamento menor ou igual a 5, aplica regra e retorna valor normal sem desconto e sem juros")]
        public void RecebeValorPagamento_ExecutaPagamento_RetornaValorNormalSemJuros()
        {
            // Arrange
            var pagamento = new Credito(limiteDisponivel: 5000, limiteUtilizado: 600, parcelas: 4);

            // Act
            pagamento.Executa(1000);

            // Assert
            pagamento.ValorTotal.ShouldBe(1000);
            pagamento.LimiteDisponivel.ShouldBe(5000);
            pagamento.LimiteUtilizado.ShouldBe(850);
            pagamento.Mensagem.ShouldBe("Pagamento crédito no valor de: R$1000 aprovado com sucesso");
        }

        [Fact(DisplayName = "Recebe o valor de um pagamento maior ou igual a 6, aplica regra e retorna valor com juros")]
        public void RecebeValorPagamento_ExecutaPagamento_RetornaValorComJuros()
        {
            // Arrange
            var pagamento = new Credito(limiteDisponivel: 5000, limiteUtilizado: 600, parcelas: 6);

            // Act
            pagamento.Executa(1000);

            // Assert
            pagamento.ValorTotal.ShouldBe(1070);
            pagamento.LimiteDisponivel.ShouldBe(5000);
            pagamento.LimiteUtilizado.ShouldBe(778.33m);
            pagamento.Mensagem.ShouldBe("Pagamento crédito no valor de: R$1070,00 aprovado com sucesso");
        }


        [Fact(DisplayName = "Recebe o valor de um pagamento que ultrapasse o limite disponível, não realiza pagamento, retorna mensagem de limite insuficiente")]
        public void ValorPagamentoMaiorQueSaldo_NaoRealizaPagamento_RetornaMensagemSaldoInsuficiente()
        {
            // Arrange
            var pagamento = new Credito(limiteDisponivel: 5000, limiteUtilizado: 4800, parcelas: 4);

            // Act
            pagamento.Executa(6000);

            // Assert
            pagamento.ValorTotal.ShouldBe(0);
            pagamento.LimiteDisponivel.ShouldBe(5000);
            pagamento.LimiteUtilizado.ShouldBe(4800);
            pagamento.Mensagem.ShouldBe("Pagamento não aprovado, limite liberado insuficiente");
        }
    }
}
