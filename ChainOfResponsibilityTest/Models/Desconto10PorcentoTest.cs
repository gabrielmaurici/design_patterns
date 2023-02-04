using ChainOfResponsibility.models;

namespace ChainOfResponsibilityTest.Models
{
    public class Desconto10PorcentoTest : GenericDescontoTest<Desconto10Porcento>
    {
        [Fact(DisplayName = "Passa valor que se enquadra na regra de 10%, retorna valor com desconto de 10%")]
        public void ValorCompraDentroRegraDesconto_CalculaDesconto10Porcento_RetornaValorDesconto()
            => base.DadoValorCompra_CalculaDesconto_RetornaValorDesconto(160, 144);

        [Fact(DisplayName = "Passa valor que não se enquadra na regra de 10%, retorna valor da compra sem desconto")]
        public void ValorCompraForaDaRegra_NaoPossuiProximaRegra_RetornaValorCompraSemDesconto()
            => base.ValorCompraNaoSeEnquadraNoDesconto_NaoPossuiProximaRegra_RetornaValorCompraSemDesconto(300);

        [Fact(DisplayName = "Passa valor que não se enquadra na regra de 10%, retorna valor com desconto da próxima regra")]
        public void ValorCompraForaDaRegra_ProximaRegra20Porcento_RetornaValorDesconto20Porcento()
            => base.ValorCompraNaoSeEnquadraNoDesconto_PossuiProximaRegra_RetornaValorDescontoBaseadoNaProximaRegra(350, 280, new Desconto20Porcento());
    }
}
