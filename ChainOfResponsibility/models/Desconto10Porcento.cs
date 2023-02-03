namespace ChainOfResponsibility.models
{
    public class Desconto10Porcento : IDesconto
    {
        public IDesconto Proximo { get ; set ; } = null!;

        public decimal Calcula(decimal valorCompra)
        {
            if(valorCompra >= 100 && valorCompra <= 200)
                return valorCompra - valorCompra * 0.1m;

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