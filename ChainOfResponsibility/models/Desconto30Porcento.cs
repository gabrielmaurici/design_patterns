namespace ChainOfResponsibility.models
{
    public class Desconto30Porcento : AbstractDesconto
    {
        public Desconto30Porcento() : base (valorMinimo: 401, valorMaximo: 800, porcentagemRegra: 0.3m)
        {
        }
    }
}