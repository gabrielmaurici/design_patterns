namespace ChainOfResponsibility.models
{
    public interface IDesconto
    {
        IDesconto Proximo { get; set; }

        IDesconto SetaProximo(IDesconto desconto);

        decimal Calcula(decimal valorCompra);
    }
}