namespace ChainOfResponsibility.models
{
    public class Desconto20Porcento : AbstractDesconto
    {
        public Desconto20Porcento() : base (valorMinimo: 201, valorMaximo: 400, porcentagemRegra: 0.2m)
        {
        }
    }
}