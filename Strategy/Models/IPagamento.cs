namespace Strategy.Models
{
    public interface IPagamento
    {
        public decimal ValorTotal { get; set; }

        public string? Mensagem { get; set; }

        IPagamento Executa(decimal valorPagamento);
    }
}
