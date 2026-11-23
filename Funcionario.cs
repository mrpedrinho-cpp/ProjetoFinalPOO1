using System;

public class Funcionario : Usuario
{
    private Estoque _estoque;

    public Funcionario(int id, string nome, string login, string senha, Estoque estoque)
        : base(id, nome, login, senha)
    {
        _estoque = estoque;
    }

    public override void Menu()
    {
        bool executando = true;
        while (executando)
        {
            Console.Clear();
            Console.WriteLine($"--- Menu do Funcionário: {Nome} ---");
            Console.WriteLine("1. Registrar Saída de Produto");
            Console.WriteLine("2. Visualizar Estoque");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    MenuRegistrarSaida();
                    break;
                case "2":
                    VisualizarEstoque(_estoque);
                    Console.WriteLine("\nPressione qualquer tecla para voltar...");
                    Console.ReadKey();
                    break;
                case "3":
                    executando = false;
                    Console.WriteLine("Saindo do menu do Funcionário...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private void MenuRegistrarSaida()
    {
        Console.WriteLine("\n--- Registrar Saída ---");
        Console.Write("Nome do Produto: ");
        string nome = Console.ReadLine();

        Produto produto = _estoque.BuscarProduto(nome);

        if (produto != null)
        {
            try
            {
                Console.Write("Quantidade de saída (int): ");
                if (!int.TryParse(Console.ReadLine(), out int qtd)) throw new FormatException("Quantidade inválida.");

                RegistrarSaida(produto, qtd);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na saída: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    public void RegistrarSaida(Produto produto, int quantidade)
    {
        produto.Remover(quantidade);
        MovimentoEstoque movimento = new MovimentoEstoque(0, produto, this, "saida", DateTime.Now, quantidade);
        movimento.RegistrarMovimento();
        Console.WriteLine($"Saída de {quantidade} unidades do produto {produto.Nome} registrada. Novo estoque: {produto.Quantidade}");
    }

    public void VisualizarEstoque(Estoque estoque)
    {
        Console.WriteLine("\n--- Visualização de Estoque (Funcionário) ---");
        var produtos = estoque.ListarProdutos();
        if (produtos.Count == 0)
        {
            Console.WriteLine("O estoque está vazio.");
            return;
        }
        foreach (var p in produtos)
        {
            Console.WriteLine($"- ID: {p.Id}, Nome: {p.Nome}, Tipo: {p.Tipo}, Qtd: {p.Quantidade}");
        }
    }
}