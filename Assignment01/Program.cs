// See https://aka.ms/new-console-template for more information
using Assignment01.Services;

Console.WriteLine("Hello, World!");
MenuMethods menu = new MenuMethods($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json");
while (true)
{
    menu.MainMenu();
}