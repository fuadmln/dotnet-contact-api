using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagementAPI.Data;
using ContactManagementAPI.Models.Entities;
using ContactManagementAPI.Models.DTO;

namespace ContactManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;
    private readonly ApplicationDbContext _context;

    public ContactController(ILogger<ContactController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseDTO<List<ContactDTO>>>> GetAll()
    {
        var contacts = await _context.Contacts.ToListAsync();
        List<ContactDTO> contactsDTO = contacts.Select(contact => new ContactDTO(contact)).ToList();

        return Ok(new ResponseDTO<List<ContactDTO>>(contactsDTO));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseDTO<ContactDTO>>> Get(long id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        return contact == null
            ? NotFound()
            : Ok(new ResponseDTO<ContactDTO>(contact.ToContactDTO()));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(Contact contact)
    {
        _context.Add(contact);
        await _context.SaveChangesAsync();

        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Contact>> Update(long id, Contact newContact)
    {
        // TODO: data validation
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        contact.FirstName = newContact.FirstName;
        contact.LastName = newContact.LastName;
        contact.Phone = newContact.Phone;
        contact.Email = newContact.Email;
        await _context.SaveChangesAsync();

        return Ok(contact);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}