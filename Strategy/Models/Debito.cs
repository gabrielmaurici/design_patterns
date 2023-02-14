namespace Strategy.Models
{
    public class Debito : IPagamento
    {
        public Debito(decimal saldo)
        {
            Saldo = saldo;
        }

        public decimal ValorTotal { get ; set ; }

        public decimal Saldo { get; set; }

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
            ValorTotal = ArredondaValorMonetario(valorPagamento - valorPagamento * 0.03m);
            Saldo -= ArredondaValorMonetario(ValorTotal);
            Mensagem = $"Pagamento débito no valor de: R${ValorTotal} efetuado com sucesso";
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

        private decimal ArredondaValorMonetario(decimal valor)
        {
            return decimal.Round(valor, 2);
        }
    }
}
