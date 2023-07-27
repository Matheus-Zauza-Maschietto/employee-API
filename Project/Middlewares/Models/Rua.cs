using System.Text.Json.Serialization;

namespace Project.Middlewares.Models;

public class Rua
{
    [JsonPropertyName("number")]
    public int Numero { get; set; }
    [JsonPropertyName("name")]
    public string Nome { get; set; }
}
