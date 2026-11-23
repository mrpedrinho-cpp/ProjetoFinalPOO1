using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        
        Estoque estoque = new Estoque();

        List<Usuario> usuarios = new List<Usuario>
        {
            new Gerente(1, "Fulano de Tal", "admin", "admin", estoque),
            new Funcionario(2, "Ciclano de Tal", "funcionario", "funcionario", estoque)
        };

        string login = "";
        string senha = "";
        do
        {
            Console.WriteLine("--- Sistema de Controle de Estoque ---");

            Usuario usuarioLogado = null;
            while (usuarioLogado == null)
            {
                Console.Write("\nLogin: ");
                login = Console.ReadLine();

                Console.Write("Senha: ");
                senha = Console.ReadLine();
                Console.Clear();

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
                {
                    Console.WriteLine("\nSistema encerrado. Obrigado por usar o nosso sistema de estoque!");
                    return;
                }

                usuarioLogado = usuarios.FirstOrDefault(u => u.Autenticar(login, senha));

                if (usuarioLogado == null)
                {
                    Console.WriteLine("Login ou Senha incorretos. Tente novamente.");
                }
            }

            Console.WriteLine($"\nBem-vindo, {usuarioLogado.Nome}!");

            usuarioLogado.Menu();

            usuarioLogado = null;
        } while (true);
    }
}