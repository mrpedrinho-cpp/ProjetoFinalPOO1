using System;
using System.Linq;

public class Gerente : Usuario
{
    private Estoque _estoque;

    public Gerente(int id, string nome, string login, string senha, Estoque estoque)
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
            Console.WriteLine($"--- Menu do Gerente: {Nome} ---");
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Registrar Entrada de Produto");
            Console.WriteLine("3. Remover Produto");
            Console.WriteLine("4. Visualizar Estoque");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    MenuCadastrarProduto();
                    break;
                case "2":
                    MenuRegistrarEntrada();
                    break;
                case "3":
                    MenuRemoverProduto();
                    break;
                case "4":
                    VisualizarEstoque(_estoque);
                    Console.WriteLine("\nPressione qualquer tecla para voltar...");
                    Console.ReadKey();
                    break;
                case "5":
                    executando = false;
                    Console.WriteLine("Saindo do menu do Gerente...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private void MenuCadastrarProduto()
    {
        Console.WriteLine("\n--- Cadastrar Novo Produto ---");
        try
        {
            Console.Write("ID do Produto (int): ");
            if (!int.TryParse(Console.ReadLine(), out int id)) throw new FormatException("ID inválido.");

            Console.Write("Nome do Produto (string): ");
            string nome = Console.ReadLine();

            Console.Write("Tipo do Produto (string - Ex: Parafuso, Chapa): ");
            string tipo = Console.ReadLine();

            
            Produto novoProduto = new Produto(id, nome, tipo);
            CadastrarProduto(_estoque, novoProduto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar: {ex.Message}");
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    private void MenuRegistrarEntrada()
    {
        Console.WriteLine("\n--- Registrar Entrada ---");
        Console.Write("Nome do Produto: ");
        string nome = Console.ReadLine();

        Produto produto = _estoque.BuscarProduto(nome);

        if (produto != null)
        {
            try
            {
                Console.Write("Quantidade de entrada (int): ");
                if (!int.TryParse(Console.ReadLine(), out int qtd)) throw new FormatException("Quantidade inválida.");

                RegistrarEntrada(produto, qtd, _estoque);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na entrada: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    private void MenuRemoverProduto()
    {
        Console.WriteLine("\n--- Remover Produto ---");
        Console.Write("Nome do Produto a ser removido: ");
        string nome = Console.ReadLine();

        RemoverProduto(_estoque, nome);

        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    public void CadastrarProduto(Estoque estoque, Produto produto)
    {
        estoque.AdicionarProduto(produto);
        Console.WriteLine($"Produto {produto.Nome} cadastrado.");
    }

    public void RemoverProduto(Estoque estoque, string nomeProduto)
    {
        Produto produtoParaRemover = estoque.BuscarProduto(nomeProduto);
        if (produtoParaRemover != null)
        {
            estoque.RemoverProduto(produtoParaRemover);
            Console.WriteLine($"Produto {nomeProduto} removido.");
        }
        else
        {
            Console.WriteLine($"Produto {nomeProduto} não encontrado.");
        }
    }

    public void RegistrarEntrada(Produto produto, int quantidade, Estoque estoque)
    {
        produto.Adicionar(quantidade);
        MovimentoEstoque movimento = new MovimentoEstoque(0, produto, this, "entrada", DateTime.Now, quantidade);
        movimento.RegistrarMovimento();
        Console.WriteLine($"Entrada de {quantidade} unidades do produto {produto.Nome} registrada. Novo estoque: {produto.Quantidade}");
    }

    public void VisualizarEstoque(Estoque estoque)
    {
        Console.WriteLine("\n--- Visualização de Estoque ---");
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