using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ContactManagementAPI.Data;
using ContactManagementAPI.Models.Entities;

namespace ContactManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
	private readonly ILogger<ContactController> _logger;
	private readonly ApplicationDbContext _context;
	
	public ContactController(ILogger<ContactController> logger, ApplicationDbContext context)
	{
		_context = context;
	}
	
    [HttpGet]
    public async Task<ActionResult<List<Contact>>> Get()
    {
        /* var contacts = new List<Contact>
        {
            new Contact{Id = 1, FirstName = "Lionel", LastName = "Messi", Phone = "101010"},
            new Contact{Id = 2, FirstName = "Cristiano", LastName = "Ronaldo", Phone = "777777"}
        };

        return Ok(contacts); */
		
		var contacts = await _context.Contacts.ToListAsync();
		
		return Ok(contacts);
    }
}