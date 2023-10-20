using KontaktBok_2._0.Models;
using KontaktBok_2._0.Services;

namespace CreateContact.Test;

public class CreateContactTest
{
    [Fact]
    public void AddContact_ShouldCreateContactToList_IfSuccesfulReturnTrue()
    {
        // Arrange

        //Skapar en instans av ContactService för att testa metoden
        ContactService contactService = new ContactService();

        //Här skappas en kontakt för att använda i testet
        Contact contact = new Contact
        {
            FirstName = "test",
            LastName = "test",
            Email = "test",
            PhoneNumber = "test",

            Address = new Address
            {
                StreetName = "test",
                City = "test",
                PostalCode = "test",
            }
        };


        // Act

        //Vi anropar metoden CreateContact och sparar ner test kontakten
        bool result = contactService.CreateContact(contact);


        // Assert

        //Här kollar vi om 
        Assert.True(result);

    }
}