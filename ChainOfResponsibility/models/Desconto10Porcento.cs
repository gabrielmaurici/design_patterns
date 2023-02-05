namespace ChainOfResponsibility.models
{
    public class Desconto10Porcento : AbstractDesconto
    {
        public Desconto10Porcento() : base (valorMinimo: 100, valorMaximo: 200, porcentagemRegra: 0.1m)
        {
        }
    }
}