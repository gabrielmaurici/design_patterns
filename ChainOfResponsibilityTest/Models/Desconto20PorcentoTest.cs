using ChainOfResponsibility.models;

namespace ChainOfResponsibilityTest.Models
{
    public class Desconto20PorcentoTest : GenericDescontoTest<Desconto20Porcento>
    {
        [Fact(DisplayName = "Passa valor que se enquadra na regra de 20%, retorna valor com desconto de 20%")]
        public void ValorCompraDentroRegraDesconto_CalculaDesconto30Porcento_RetornaValorDesconto()
            => base.DadoValorCompra_CalculaDesconto_RetornaValorDesconto(350, 280);

        [Fact(DisplayName = "Passa valor que não se enquadra na regra de 20%, retorna valor da compra sem desconto")]
        public void ValorCompraForaDaRegra_NaoPossuiProximaRegra_RetornaValorCompraSemDesconto()
            => base.ValorCompraNaoSeEnquadraNoDesconto_NaoPossuiProximaRegra_RetornaValorCompraSemDesconto(100);

        [Fact(DisplayName = "Passa valor que não se enquadra na regra de 20%, retorna valor com desconto da próxima regra")]
        public void ValorCompraForaDaRegra_ProximaRegra20Porcento_RetornaValorDesconto20Porcento()
            => base.ValorCompraNaoSeEnquadraNoDesconto_PossuiProximaRegra_RetornaValorDescontoBaseadoNaProximaRegra(730, 511, new Desconto30Porcento());
    }
}
