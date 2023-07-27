using System.Text.Json.Serialization;

namespace Project.Middlewares.Models;

public class Localizacao
{
    [JsonPropertyName("street")]
    public Rua Rua { get; set; }
    [JsonPropertyName("city")]
    public string Cidade { get; set; }
    [JsonPropertyName("state")]
    public string Estado { get; set; }
    [JsonPropertyName("country")]
    public string Pais { get; set; }



}
