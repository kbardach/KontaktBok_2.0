using KontaktBok_2._0.Interfaces;
using KontaktBok_2._0.Models;
using Newtonsoft.Json;

namespace KontaktBok_2._0.Services;

//Den här classen använder sig utav IContactservice interface
public class ContactService : IContactService
{
    //Listan används som lagringsplats för Contacts medans prog. körs
    private List<Contact> _contacts = new List<Contact>();


    /*En konstruktor för ContactService classen som anropar GetContactFromFile
      varje gång programmet startas så listan alltid är uppdaterad när prog. körs*/
    public ContactService()
    {
        GetContactsFromFile();
    }


    //Returnerar en lista av Contacts
    public List<Contact> GetContactsFromFile()              
    {
        //Läser in filen från FileService
        var file = FileService.ReadFromFile();

        if (!string.IsNullOrEmpty(file))
        {
            //Konverterar JSon filen till en lista av Contacts, och returnerar den
            _contacts = new List<Contact>();
            return _contacts = JsonConvert.DeserializeObject<List<Contact>>(file)!;
        }
        return null!;

    }


    //Hit skickas informationen när användaren har lagt till en kontakt
    public bool CreateContact(Contact contact)
    {
        try
        {
            //Här sparar vi ner kontakten till listan _contacts ovan
            _contacts.Add(contact);

            //Konverterar listan _contacts, sen används FileService för att spara ner den till fil
            var json = JsonConvert.SerializeObject(_contacts);
            FileService.SaveToFile(json);
            return true;
        }
        catch { }
        return false;
 
    }


    //Härifrån anropas metoden GetAllContacts När man vill hämta ut alla sina kontakter
    public IEnumerable<Contact> GetAllContacts()
    {
        //Metoden skickar tillbaka hela listan för att visa den i konsolen
        return _contacts;
    }


    //Hämtar en kontakt baserat på villkoret som finns i expression
    public Contact GetOneContact(Func<Contact, bool> expression)
    {
        try
        {
            //Försöker hitta och retunera den första kontakten från listan _contacts, baserat på "expression"
            var contact = _contacts.FirstOrDefault(expression, null!); 

            if (contact != null) 
            {   
                //Om en matchande kontakt hittas returneras den
                return contact; 
            }
        }
        catch{ }
        return null!;
    }


    //Uppdaterar en befintlig kontakt i _contacts-listan baserat på den medföljande, uppdaterade kontakten
    //En Contact-instans med de nya, uppdaterade uppgifterna
    public bool UpdateContact(Contact updatedContact)
    {
        try
        {
            //Hitta den kontakt som ska uppdateras i _contacts listan baserat på e-post.
            var contactToUpdate = _contacts.FirstOrDefault(contact => contact.Email == updatedContact.Email);

            if (contactToUpdate != null)
            {
                //Uppdatera kontakten.
                contactToUpdate.FirstName = updatedContact.FirstName;
                contactToUpdate.LastName = updatedContact.LastName;
                contactToUpdate.PhoneNumber = updatedContact.PhoneNumber;
                contactToUpdate.Email = updatedContact.Email;
                contactToUpdate.Address = updatedContact.Address; 

                //Konvertera listan _contacts till JSON och spara ner den till en fil.
                var json = JsonConvert.SerializeObject(_contacts);
                FileService.SaveToFile(json);
                return true;
            }
        }
        catch { }
        return false;
    }


    //Kontakten tas bort baserat på stringen email
    public void DeleteContact(string email)
    {
        //Försöker hitta en kontakt från listan _contacts på emailen som matas in, för att sedan tas bort nedan

        try
        {
            var contact = _contacts.FirstOrDefault(contact => contact.Email == email);
            if (contact != null)
            {
                //Om en matchande kontakt hittas så tas den bort
                _contacts.Remove(contact);

                //Konverterar listan _contacts till JSon & sparar ner den till en fil
                var json = JsonConvert.SerializeObject(_contacts);
                FileService.SaveToFile(json);
            }

        }
        catch { }
    }

}
