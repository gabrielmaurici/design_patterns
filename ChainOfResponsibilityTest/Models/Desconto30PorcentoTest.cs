using ChainOfResponsibility.models;

namespace ChainOfResponsibilityTest.Models
{
    public class Desconto30PorcentoTest : GenericDescontoTest<Desconto30Porcento>
    {
        [Fact(DisplayName = "Passa valor que se enquadra na regra de 30%, retorna valor com desconto de 30%")]
        public void ValorCompraDentroRegraDesconto_CalculaDesconto30Porcento_RetornaValorDesconto()
            => base.DadoValorCompra_CalculaDesconto_RetornaValorDesconto(730, 511);

        [Fact(DisplayName = "Passa valor que não se enquadra na regra de 30%, retorna valor da compra sem desconto")]
        public void ValorCompraForaDaRegra_NaoPossuiProximaRegra_RetornaValorCompraSemDesconto()
            => base.ValorCompraNaoSeEnquadraNoDesconto_NaoPossuiProximaRegra_RetornaValorCompraSemDesconto(200);

        [Fact(DisplayName = "Passa valor que não se enquadra na regra de 30%, retorna valor com desconto da próxima regra")]
        public void ValorCompraForaDaRegra_ProximaRegra20Porcento_RetornaValorDesconto20Porcento()
            => base.ValorCompraNaoSeEnquadraNoDesconto_PossuiProximaRegra_RetornaValorDescontoBaseadoNaProximaRegra(160, 144, new Desconto10Porcento());
    }
}