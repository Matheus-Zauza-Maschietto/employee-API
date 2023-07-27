using System.Text.Json.Serialization;

namespace Project.Middlewares.Models;

public class Nome
{
    [JsonPropertyName("title")]
    public string Titulo { get; set; }

    [JsonPropertyName("first")]
    public string PrimeiroNome { get; set; }

    [JsonPropertyName("last")]
    public string Sobrenome { get; set; }

}
