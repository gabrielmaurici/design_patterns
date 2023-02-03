namespace ChainOfResponsibility.models
{
    public class Desconto20Porcento : IDesconto
    {
        public IDesconto Proximo { get ; set ; } = null!;

        public decimal Calcula(decimal valorCompra)
        {
            if(valorCompra >= 201 && valorCompra <= 400)
                return valorCompra - valorCompra * 0.2m;

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