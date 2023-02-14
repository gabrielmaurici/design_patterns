using Shouldly;
using Strategy.Models;

namespace StrategyTest.Models
{
    public class DebitoTest
    {
        [Fact(DisplayName = "Recebe o valor de um pagamento, aplica regra de desconto débito e retorna valor com desconto")]
        public void RecebeValorPagamento_ExecutaPagamento_RetornaValorComDescontoDebito()
        {
            // Arrange
            var pagamento = new Debito(4500);

            // Act
            pagamento.Executa(1000);

            // Assert
            pagamento.ValorTotal.ShouldBe(970);
            pagamento.Saldo.ShouldBe(3530);
            pagamento.Mensagem.ShouldBe("Pagamento débito no valor de: R$970,00 efetuado com sucesso");
        }


        [Fact(DisplayName = "Recebe o valor de um pagamento maior que saldo na conta, não realiza pagamento, retorna mensagem de saldo insuficiente")]
        public void ValorPagamentoMaiorQueSaldo_NaoRealizaPagamento_RetornaMensagemSaldoInsuficiente()
        {
            // Arrange
            var pagamento = new Debito(4500);

            // Act
            pagamento.Executa(6000);

            // Assert
            pagamento.ValorTotal.ShouldBe(0);
            pagamento.Saldo.ShouldBe(4500);
            pagamento.Mensagem.ShouldBe("Saldo insuficiente para realizar o pagamento");
        }
    }
}
