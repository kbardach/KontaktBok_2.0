using KontaktBok_2._0.Interfaces;
using KontaktBok_2._0.Models;

namespace KontaktBok_2._0.Services;

//Implementerar metoder från interfacet IMenuService
public class MenuService : IMenuService
{
    //En instans till ContactService som används för att skapa, hämta, uppdatera  och radera kontakter baserat på interfacet IContactService
    private readonly IContactService _contactService = new ContactService(); 

    public void MainMenu()
    {
        /* En Do-While sats som körs så länge exit = false. Exit ges till en början värdet "false"
           och så fort användare matar in "0" så blir exit "true" och loopen avbryts och programmet avslutas */
        var exit = false;

        do 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" --- Kontaktbok --- ");
            Console.WriteLine("--------------------");
            Console.ResetColor();
            Console.WriteLine("1. Lägg till kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Sök bland kontakter");
            Console.WriteLine("4. Uppdatera kontakt");
            Console.WriteLine("5. Radera kontakt");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Välj ett av ovanstående alternativ. (0-5): ");
            Console.ResetColor();


            // Option är en variabel som sparar in det alternativet användare matar in och används i switchen
            var option = Console.ReadLine();

            // En SWITCH som skickar användaren vidare beroende på vad användaren matar in så körs en metod baserat på vilket val användare gör
            switch (option) 
            {
                case "1":
                    CreateContactMenu();
                    break;
                case "2":
                    GetAllContactsMenu(); 
                    break;
                case "3":
                    GetOneContactMenu();
                    break;
                case "4":
                    UpdateContactMenu();
                    break;
                case "5":
                    DeleteContactMenu();
                    break;
                case "0": 
                    exit = true;
                    break;
                default:
                    break;
            }



        } while (exit == false);
    }

    public void CreateContactMenu()
    {
        //Här skapas instanser av classerna "Contact" & "Address"
        var contact = new Contact();      
        var address = new Address(); 

        Console.Clear();
        Console.WriteLine(" -- Personuppgifter -- ");
        Console.WriteLine("-----------------------");
        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine(); 
        Console.Write("Efternamn: ");
        contact.LastName = Console.ReadLine();
        Console.Write("Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine();
        Console.Write("E-postadress: ");
        contact.Email = Console.ReadLine()!.Trim().ToLower();                 

        Console.WriteLine();
        Console.WriteLine(" -- Adress -- ");
        Console.WriteLine("--------------");
        Console.Write("Gatuadress: ");
        address.StreetName = Console.ReadLine();
        Console.Write("Stad: ");
        address.City = Console.ReadLine();
        Console.Write("Postnummer: ");
        address.PostalCode = Console.ReadLine()!.Trim().ToLower();            
        Console.WriteLine();
        
        

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("En ny kontakt har blivit tillagd i kontaktboken!");
        Console.ResetColor();

        //Här länkar vi samman Address med Contact objektet
        contact.Address = address;

        //Här anropar vi metoden från ContactService classen och skickar vidare informationen dit och sparar
        _contactService.CreateContact(contact);

        Console.ReadKey();

    }
    public void GetAllContactsMenu()
    {
        Console.Clear();
        Console.WriteLine(" -- Alla Kontakter --");
        Console.WriteLine("----------------------");

        //Metoden GetAllContacts anropas från min Contactservice
        //Foreach loopen körs igenom och hämtar hem alla kontakterna från listan _contactService och sorterar dem i alfabetisk ordning
        foreach (var contact in _contactService.GetAllContacts().OrderBy(contact => contact.FirstName))
        {
            Console.WriteLine($"Förnamn: {contact.FirstName}");
            Console.WriteLine($"Efternamn: {contact.LastName}");
            Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();

        }
        Console.ReadKey();
    }
    public void GetOneContactMenu()
    {
        Console.Clear();
        Console.WriteLine(" -- Hämta EN kontakt -- ");
        Console.WriteLine("------------------------");
        Console.Write("E-postadress: ");
        var email = Console.ReadLine()!.Trim().ToLower();

        //Anropar metoden GetOneContact för att se om email som användaren matar in matchar ihop med Email i Contacts
        var contact = _contactService.GetOneContact(contact => contact.Email == email);

        if (contact != null)
        {
            Console.Clear();
            Console.WriteLine(" -- Din kontakt -- ");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Förnamn: {contact.FirstName}");
            Console.WriteLine($"Efternamn: {contact.LastName}");
            Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
            Console.WriteLine($"E-postadress: {contact.Email}");
            Console.WriteLine();
            Console.WriteLine($"Gatuadress: {contact?.Address?.StreetName}");
            Console.WriteLine($"Postnummer: {contact?.Address?.PostalCode}");
            Console.WriteLine($"Stad: {contact?.Address?.City}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Kunde tyvärr inte hitta någon med den e-postadressen..");
            Console.ResetColor();
        }

        Console.ReadKey();
    }
    public void UpdateContactMenu()
    {
        Console.Clear();
        Console.WriteLine(" -- Uppdatera en kontakt -- ");
        Console.WriteLine("----------------------------");
        Console.Write("E-post till kontakten som ska uppdateras: ");
        var email = Console.ReadLine()!.Trim().ToLower();

        //Hämtar en kontakt med metoden GetOneContact baserat på EMAIL
        var updateContact = _contactService.GetOneContact(contact => contact.Email == email);

        if (updateContact != null)
        {
            Console.Clear();
            Console.WriteLine("Här är kontakten du vill uppdatera");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Förnamn: {updateContact.FirstName}");
            Console.WriteLine($"Efternamn: {updateContact.LastName}");
            Console.WriteLine($"Telefonnummer: {updateContact.PhoneNumber}");
            Console.WriteLine($"E-postadress: {updateContact.Email}");
            Console.WriteLine($"Gatuadress: {updateContact.Address?.StreetName}");
            Console.WriteLine($"Postnummer:{updateContact.Address?.PostalCode}");
            Console.WriteLine($"Stad: {updateContact.Address?.City}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ange nya uppgifter där ändringar önskas. Lämna övriga fält tomma.");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Nytt förnamn: ");
            var newFirstName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newFirstName)) updateContact.FirstName = newFirstName;
            Console.Write("Nytt efternamn: ");

            var newLastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newLastName)) updateContact.LastName = newLastName;

            Console.Write("Nytt telefonnummer: ");
            var newPhoneNumber = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPhoneNumber)) updateContact.PhoneNumber = newPhoneNumber;

            Console.Write("Ny e-postadress: ");
            var newEmail = Console.ReadLine()?.Trim().ToLower();
            if (!string.IsNullOrEmpty(newEmail)) updateContact.Email = newEmail;

            Console.Write("Ny gatuadress: ");
            var newStreetName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newStreetName)) updateContact.Address!.StreetName = newStreetName;

            Console.Write("Nytt postnummer: ");
            var newPostalCode = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPostalCode)) updateContact.Address!.PostalCode = newPostalCode;

            Console.Write("Ny stad: ");
            var newCity = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCity)) updateContact.Address!.City = newCity;
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Om ändringar har gjorts, så har kontakten uppdaterats!");
            Console.ResetColor();

            //Anropar UpdateContact för att lägga till dom ändringar som gjorts
            _contactService.UpdateContact(updateContact);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Kunde tyvärr inte hitta någon med den e-postadressen..");
            Console.ResetColor();
        }

        Console.ReadKey();
    }
    public void DeleteContactMenu()
    {
        Console.Clear();
        Console.WriteLine(" -- Radera en kontakt -- ");
        Console.WriteLine("------------------------");
        Console.Write("E-postadress: ");
        var email = Console.ReadLine()!.Trim().ToLower();

        //Anropar metoden GetOneContact för att se om email som användaren matar in matchar ihop med Email i Contacts
        var deleteContact = _contactService.GetOneContact(contact => contact.Email == email);

        if (deleteContact != null) 
        {
            //Här anropars metoden DeleteContact för att radera kontakten baserat på e-postadressen
            _contactService.DeleteContact(deleteContact.Email!);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Kontakten {deleteContact.Email} har raderats");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kunde inte hitta någon kontakt med den e-postadressen!");
            Console.ResetColor();
        }

        Console.ReadKey();
    }

   

    
    
}
