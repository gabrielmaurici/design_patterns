using Shouldly;
using Strategy.Models;

namespace StrategyTest.Models
{
    public class PixTest
    {
        [Fact(DisplayName = "Recebe o valor de um pagamento, aplica regra de desconto pix e retorna valor com desconto")]
        public void RecebeValorPagamento_ExecutaPagamento_RetornaValorComDescontoPix()
        {
            // Arrange
            var pagamento = new Pix(4500);

            // Act
            pagamento.Executa(1000);

            // Assert
            pagamento.ValorTotal.ShouldBe(900);
            pagamento.Saldo.ShouldBe(3600);
            pagamento.Mensagem.ShouldBe("Pagamento PIX no valor de: R$900,00 efetuado com sucesso");
        }


        [Fact(DisplayName = "Recebe o valor de um pagamento maior que saldo na conta, não realiza pagamento, retorna mensagem de saldo insuficiente")]
        public void ValorPagamentoMaiorQueSaldo_NaoRealizaPagamento_RetornaMensagemSaldoInsuficiente()
        {
            // Arrange
            var pagamento = new Pix(4500);

            // Act
            pagamento.Executa(6000);

            // Assert
            pagamento.ValorTotal.ShouldBe(0);
            pagamento.Saldo.ShouldBe(4500);
            pagamento.Mensagem.ShouldBe("Saldo insuficiente para realizar o pagamento");
        }
    }
}
