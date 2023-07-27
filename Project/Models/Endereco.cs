using Project.Middlewares.Models;

namespace Project.Models;

public class Endereco
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public string Rua { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }

    public Endereco()
    {

    }

    public Endereco(Localizacao localizacao)
    {
        this.Numero = localizacao.Rua.Numero;
        this.Rua = localizacao.Rua.Nome;
        this.Cidade = localizacao.Cidade;
        this.Estado = localizacao.Estado;
        this.Pais = localizacao.Pais;
    }
}
