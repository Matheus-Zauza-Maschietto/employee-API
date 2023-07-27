namespace Project.Models;

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Usuario { get; set; }
    public string Telefone { get; set; }
    public int EnderecoId { get; set; }
    public Endereco Endereco { get; set; }

    public Pessoa()
    {

    }

    public Pessoa(Middlewares.Models.Mid_Pessoa pessoa)
    {
        this.Nome = pessoa.Nome.PrimeiroNome + pessoa.Nome.Sobrenome;
        this.Email = pessoa.Email;
        this.Usuario = pessoa.Login.Usuario;
        this.Telefone = pessoa.Telefone;
        this.Endereco = new Endereco(pessoa.Localizacao);
    }

}
