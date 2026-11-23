using System;

public class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Tipo { get; private set; }
    public int Quantidade { get; private set; }

    public Produto(int id, string nome, string tipo, int quantidadeInicial = 0)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
        Quantidade = quantidadeInicial;
    }

    public void Adicionar(int qtd)
    {
        if (qtd > 0)
        {
            Quantidade += qtd;
        }
    }

    public void Remover(int qtd)
    {
        if (qtd > 0)
        {
            if (Quantidade >= qtd)
            {
                Quantidade -= qtd;
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente em estoque.");
            }
        }
    }
}