namespace ChainOfResponsibility.models
{
    public abstract class AbstractDesconto : IDesconto
    {
        protected AbstractDesconto(decimal valorMinimo, decimal valorMaximo, decimal porcentagemRegra)
        {
            ValorMinimo = valorMinimo;
            ValorMaximo = valorMaximo;
            PorcentagemRegra = porcentagemRegra;
        }

        public decimal ValorMinimo { get; private set; }

        public decimal ValorMaximo { get; private set; }

        public decimal PorcentagemRegra { get; private set; }

        public IDesconto Proximo { get ; set ; } = null!;


        public decimal Calcula(decimal valorCompra)
        {
            if(valorCompra >= ValorMinimo && valorCompra <= ValorMaximo)
                return valorCompra - valorCompra * PorcentagemRegra;

            if(Proximo == null)
                return valorCompra;

            return Proximo.Calcula(valorCompra);
        }

        public IDesconto SetaProximo(IDesconto desconto)
        {
            Proximo = desconto;
            return desconto;
        }
    }
}