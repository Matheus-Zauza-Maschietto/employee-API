using System.Text.Json.Serialization;

namespace Project.Middlewares.Models;

public class Resultado
{
    [JsonPropertyName("results")]
    public List<Mid_Pessoa> Pessoas { get; set; }
}
