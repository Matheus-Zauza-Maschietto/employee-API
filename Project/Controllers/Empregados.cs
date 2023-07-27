using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Middlewares;
using Project.Middlewares.Models;
using Project.Repositories;
using Project.Models;
namespace Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Empregados : ControllerBase
{
    private readonly GeradorDeUsuario _geradorDeUsuarios;
    private readonly PessoaRepositorie _pessoaRepositorio;
    public Empregados(GeradorDeUsuario geradorDeUsuarios, PessoaRepositorie pessoaRepositorio)
    {
        _geradorDeUsuarios = geradorDeUsuarios;
        _pessoaRepositorio = pessoaRepositorio;
    }

    [HttpGet("aleatorios")]
    public async Task<IActionResult> GerarPessoa()
    {
        Mid_Pessoa pessoaAleatoria = await _geradorDeUsuarios.GerarPessoaAleatoria();
        if(pessoaAleatoria is null)
        {
            Problem();
        }
        return Ok(pessoaAleatoria);
    }

    [HttpGet("aleatorios/{quantidade:int}")]
    public async Task<IActionResult> GerarPessoas([FromRoute]int quantidade)
    {
        List<Mid_Pessoa> pessoasAleatorias = await _geradorDeUsuarios.GerarPessoasAleatorias(quantidade);
        return Ok(pessoasAleatorias);
    }

    [HttpPost("aleatorios")]
    public async Task<IActionResult> AdicionarPessoaAleatoria()
    {
        Mid_Pessoa pessoaAleatoria = await _geradorDeUsuarios.GerarPessoaAleatoria();

        Pessoa pessoa = new Pessoa(pessoaAleatoria);

        string resultado = _pessoaRepositorio.AdicionarPessoa(pessoa);

        return Ok(resultado);
    }

    [HttpGet]
    public IActionResult BuscarPessoasDoBanco()
    {
        try
        {
            var pessoas = _pessoaRepositorio.BuscarTodasPessoas();
            
            if(pessoas is null)
            {
                return NoContent();
            }

            return Ok(pessoas);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> BuscarPessoaPorId([FromRoute]int id)
    {
        try
        {
            var pessoa = _pessoaRepositorio.BuscarPessoaPorId(id);

            if (pessoa is null)
            {
                return NoContent();
            }

            return Ok(pessoa);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost("{quantidade:int}")]
    public async Task<IActionResult> AdicionarListaDePessoasAleatorias([FromRoute] int quantidade)
    {
        IEnumerable<Mid_Pessoa> pessoasAleatorias = await _geradorDeUsuarios.GerarPessoasAleatorias(quantidade);
        List<Pessoa> pessoas = new();

        foreach(var pessoa in pessoasAleatorias)
            pessoas.Add(new Pessoa(pessoa));

        string resultado = _pessoaRepositorio.AdicionarListaDePessoa(pessoas);

        return Ok(resultado);
    }
}

