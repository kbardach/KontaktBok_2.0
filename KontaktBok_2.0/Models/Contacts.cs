namespace KontaktBok_2._0.Models;

//En modell av hur en kontaktperson ska se ut
//Get; set; görs att den både kan läsas och skrivas till
public class Contact
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
    

}
