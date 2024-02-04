using ContactManagementAPI.Models.Entities;

namespace ContactManagementAPI.Models.DTO;

public class ContactDTO
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public ContactDTO(Contact contact)
    {
        Id = contact.Id;
        FirstName = contact.FirstName;
        LastName = contact.LastName;
        Phone = contact.Phone;
        Email = contact.Email;
    }

}