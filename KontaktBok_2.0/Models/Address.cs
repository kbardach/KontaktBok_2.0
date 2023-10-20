namespace KontaktBok_2._0.Models;

//En modell av hur adressuppgifterna ska se ut för en kontaktperson
//Get; set; görs att den både kan läsas och skrivas till
//Anledningen till varför man separerar den på det här viset är för att det ska bli lättare att läsa, förstå och underhålla
//Man kan ha det på det här viset om man tex. vill skilja på företagskunder & privatpersoner
public class Address 
{
    public string? StreetName { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
}
