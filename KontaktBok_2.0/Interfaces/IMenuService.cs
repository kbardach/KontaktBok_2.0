namespace KontaktBok_2._0.Interfaces
{
    //Ett interface till min MenuService för att man inte ska kunna göra något annat än vad som anges nedan.
    //Navigeringen för menyn i mitt program.
    public interface IMenuService
    {
        public void MainMenu();
        public void CreateContactMenu();
        public void GetAllContactsMenu();
        public void GetOneContactMenu();
        public void UpdateContactMenu();
        public void DeleteContactMenu();

    }
}
