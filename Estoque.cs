using System.Collections.Generic;
using System.Linq;
using System;

public class Estoque
{
    private List<Produto> produtos;

    public Estoque()
    {
        produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        if (produtos.Any(p => p.Nome.Equals(produto.Nome, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Produto '{produto.Nome}' já existe no estoque.");
        }
        else
        {
            produtos.Add(produto);
        }
    }

    public void RemoverProduto(Produto produto)
    {
        produtos.Remove(produto);
    }

    public Produto BuscarProduto(string nome)
    {
        return produtos.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public List<Produto> ListarProdutos()
    {
        return produtos;
    }
}