using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;

namespace Project.Repositories;

public class PessoaRepositorie
{
    private readonly ApplicationDbContext _context;
    private readonly EnderecoRepositorie _enderecoRepositorio;
	public PessoaRepositorie(ApplicationDbContext context, EnderecoRepositorie enderecoRepositorio)
	{
        _enderecoRepositorio = enderecoRepositorio;
        _context = context;
    }
    public string AdicionarPessoa(Pessoa pessoa)
    {
        try
        {
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
            return "Usuario criado com sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public IEnumerable<Pessoa> BuscarTodasPessoas()
    {
        return _context.Pessoa.Include(pessoa => pessoa.Endereco).ToList();
    }

    public Pessoa BuscarPessoaPorId(int id)
    {
        return _context.Pessoa.Include(pessoa => pessoa.Endereco).FirstOrDefault(pessoa => pessoa.Id == id);
    }

    public string AdicionarListaDePessoa(IEnumerable<Pessoa> pessoas)
    {
        
        try
        {
            foreach (var pessoa in pessoas)
                _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
            return "Usuario criado com sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }   

}
