namespace Strategy.Models
{
    public class Pix : IPagamento
    {
        public Pix(decimal saldo)
        {
            Saldo = saldo;
        }

        public decimal ValorTotal { get; set; }

        public decimal Saldo { get ; set ; }

        public string? Mensagem { get ; set ; }


        public IPagamento Executa(decimal valorPagamento)
        {
            var validaPagamento = VerificaSaldo(valorPagamento);

            if (!validaPagamento)
                return this;

            AplicaDesconto(valorPagamento);

            return this;
        }

        private void AplicaDesconto(decimal valorPagamento)
        {
            ValorTotal = valorPagamento - valorPagamento * 0.10m;
            Saldo -= ValorTotal;
            Mensagem = $"Pagamento PIX no valor de: R${ValorTotal} efetuado com sucesso";
        }

        private bool VerificaSaldo(decimal valorPagamento)
        {
            if (valorPagamento > Saldo)
            {
                Mensagem = "Saldo insuficiente para realizar o pagamento";
                return false;
            }

            return true;
        }
    }
}
