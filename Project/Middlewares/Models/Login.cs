using System.Text.Json.Serialization;

namespace Project.Middlewares.Models;

public class Login
{
    [JsonPropertyName("username")]
    public string Usuario { get; set; }
}
