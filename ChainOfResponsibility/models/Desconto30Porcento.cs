namespace ChainOfResponsibility.models
{
    public class Desconto30Porcento : IDesconto
    {
        public IDesconto Proximo { get ; set ; } = null!;

        public decimal Calcula(decimal valorCompra)
        {
            if(valorCompra >= 401 && valorCompra <= 800)
                return valorCompra - valorCompra * 0.3m;

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