using System;
using Warehouse;


//29:21


namespace Pliki
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuActionService actionService = new MenuActionService();
            actionService= Initialize(actionService);

            Console.WriteLine("Witaj!!!");
            Console.WriteLine("Wwybierz co chcesz zrobić z plikiem");
            var mainMenu = actionService.GetMenuActionsByMenuName("Main");
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id}.  {mainMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            ItemService itemService = new ItemService();
            switch(operation.KeyChar)
            {
                case '1':
                    var keyInfo = itemService.AddNewItemView(actionService);
                    var id = itemService.AddNewItem(keyInfo.KeyChar);
                    break;  
                case '2':
                    var removeId = itemService.RemoveItemView();
                    itemService.RemoveItem(removeId);
                    break;  
                case '3':
                    break; 
                case '4':
                    break;
                default:
                    Console.WriteLine("nieprawidłowa akcja!!");
                    break;
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Dodaj plik", "Main");
            actionService.AddNewAction(2, "Usuń plik", "Main");
            actionService.AddNewAction(3, "Zobacz właściwości", "Main");
            actionService.AddNewAction(4, "lista plików", "Main");

            
            actionService.AddNewAction(1, "Muzyka", "Main");
            actionService.AddNewAction(2, "Video", "Main");
            actionService.AddNewAction(3, "PDF", "Main");
           
            return actionService;
        }
    }
}
