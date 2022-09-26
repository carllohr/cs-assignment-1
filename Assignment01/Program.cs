using Assignment01.Services;

// enter wanted file path, change file here
MenuMethods menu = new MenuMethods($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json");
while (true)
{
    menu.MainMenu();
}