using Strategy.Models;

IPagamento pagamento;

// Pagamento é PIX
pagamento = new Pix(4500);

pagamento.Executa(890);

Console.WriteLine(pagamento.Mensagem);


// Pagamento é Débito
pagamento = new Debito(4500);

pagamento.Executa(890);

Console.WriteLine(pagamento.Mensagem);


// Pagamento é Crédito
pagamento = new Credito(limiteDisponivel: 5500, limiteUtilizado: 1300, parcelas: 6);

pagamento.Executa(890);

Console.WriteLine(pagamento.Mensagem);