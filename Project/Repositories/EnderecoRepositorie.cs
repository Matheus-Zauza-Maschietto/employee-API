using Project.Context;
using Project.Models;

namespace Project.Repositories;

public class EnderecoRepositorie
{
	private readonly ApplicationDbContext _context;
	public EnderecoRepositorie(ApplicationDbContext context)
	{
        _context = context;
    }


}
