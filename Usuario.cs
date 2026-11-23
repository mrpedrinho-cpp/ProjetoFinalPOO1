using System;

public abstract class Usuario
{
    public int Id { get; protected set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    protected string Senha { get; set; }

    public Usuario(int id, string nome, string login, string senha)
    {
        Id = id;
        Nome = nome;
        Login = login;
        Senha = senha;
    }

    public bool Autenticar(string login, string senha)
    {
        return Login == login && Senha == senha;
    }

    public abstract void Menu();
}