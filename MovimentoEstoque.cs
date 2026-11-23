using System;

public class MovimentoEstoque
{
    public int Id { get; private set; }
    public Produto Produto { get; private set; }
    public Usuario Usuario { get; private set; }
    public string TipoMovimento { get; private set; }
    public DateTime DataHora { get; private set; }
    public int Quantidade { get; private set; }

    public MovimentoEstoque(int id, Produto produto, Usuario usuario, string tipoMovimento, DateTime dataHora, int quantidade)
    {
        Id = id;
        Produto = produto;
        Usuario = usuario;
        TipoMovimento = tipoMovimento;
        DataHora = dataHora;
        Quantidade = quantidade;
    }

    public void RegistrarMovimento()
    {
        Console.WriteLine($"Log: {TipoMovimento} de {Quantidade} unidades do produto {Produto.Nome} por {Usuario.Nome} em {DataHora}.");
    }
}