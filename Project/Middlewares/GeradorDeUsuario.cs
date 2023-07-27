using Project.Middlewares.Models;
using System.Collections.Specialized;
using System.Text.Json;

namespace Project.Middlewares;

public class GeradorDeUsuario
{
	private readonly HttpClient client;
	public GeradorDeUsuario(HttpClient _client)
	{
		client = _client;
		client.BaseAddress = new Uri("https://randomuser.me/api/");
    }

	public async Task<Mid_Pessoa> GerarPessoaAleatoria()
	{
		try
		{
            HttpResponseMessage response = await client.GetAsync("");
			string responseSerializada = await response.Content.ReadAsStringAsync();
			var pessoas = DeserializarPessoas(responseSerializada);
            return pessoas[0];
        }
		catch(Exception)
		{
			return null;
		}
	}

	public List<Mid_Pessoa> DeserializarPessoas(string conteudoSerializado)
	{
        Resultado resultado = JsonSerializer.Deserialize<Resultado>(conteudoSerializado);
		return resultado.Pessoas;
    }

	public async Task<List<Mid_Pessoa>> GerarPessoasAleatorias(int quantidadePessoas)
	{
        string conteudoResponse = await client.GetStringAsync($"?results={quantidadePessoas}");
		return DeserializarPessoas(conteudoResponse);
	}

    
}
