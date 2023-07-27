using System.Text.Json.Serialization;

namespace Project.Middlewares.Models;

public class Mid_Pessoa
{
    [JsonPropertyName("gender")]
    public string Genero { get; set; }

    [JsonPropertyName("name")]
    public Nome Nome { get; set; }

    [JsonPropertyName("location")]
    public Localizacao Localizacao { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("login")]
    public Login Login { get; set; }
    [JsonPropertyName("phone")]
    public string Telefone { get; set; }

}
