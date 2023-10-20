using KontaktBok_2._0.Models;

namespace KontaktBok_2._0.Interfaces;

public interface IContactService
{
    public bool CreateContact(Contact contact);         //Tar emot en Contact instans som ska läggas till
    public IEnumerable<Contact> GetAllContacts();       //Hämtar en lista "Contact"
    public Contact GetOneContact(Func<Contact, bool> expression);   //Tar emot ett lambda uttryck/delegat baserat på vilkoret för vilken kontakten som ska hämtas. returnerar en bool om kontakten uppfyller villkoret eller inte
    public bool UpdateContact(Contact updatedContact);  //Tar emot en Contact instans med den uppdaterade kontakten
    public void DeleteContact(string email);    //Tar emot email som en sträng för att ta fram kontakten som ska raderas

}
