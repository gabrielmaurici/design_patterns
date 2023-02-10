namespace Strategy.Models
{
    public class Credito : IPagamento
    {
        public Credito(decimal limiteDisponivel, decimal limiteUtilizado, short parcelas)
        {
            LimiteDisponivel = limiteDisponivel;
            LimiteUtilizado = limiteUtilizado;
            Parcelas = parcelas;
        }

        public decimal ValorTotal { get ; set ; }

        public decimal LimiteDisponivel { get; set; }

        public decimal LimiteUtilizado { get; set; }

        public short Parcelas { get; set; }

        public string? Mensagem { get ; set ; }


        public IPagamento Executa(decimal valorPagamento)
        {
            var valorCalculado = CalculaJuros(valorPagamento);

            var limiteFuturo = CalculaLimiteFuturo(valorCalculado);

            var valido = VerificaLimite(limiteFuturo);

            if (!valido)
            {
                Mensagem = "Pagamento não aprovado, limite liberado insuficiente";
                return this;
            }

            ValorTotal = valorCalculado;
            Mensagem = $"Pagamento crédito no valor de: R${ValorTotal} aprovado com sucesso";

            return this;
        }

        private bool VerificaLimite(decimal limiteFuturo)
        {
            if (limiteFuturo > LimiteDisponivel)
                return false;

            return true;
        }

        private decimal CalculaLimiteFuturo(decimal valorPagamento)
        {
            var valorMensal = valorPagamento / Parcelas;

            var limiteFuturo = valorMensal + LimiteUtilizado;

            return limiteFuturo;
        }

        private decimal CalculaJuros(decimal valorPagamento)
        {
            if (Parcelas >= 6)
                return valorPagamento + valorPagamento * 0.07m;

            return valorPagamento;
        }

        private void AtualizaLimiteAtualizado(decimal limiteFuturo)
        {
            LimiteUtilizado = limiteFuturo;
        }
    }
}
