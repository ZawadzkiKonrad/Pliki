using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Warehouse;

namespace Pliki
{
    public class ItemService
    {
        public List<Item> Items { get; set; }
        public ItemService()
        {
            Items = new List<Item>();
        }
        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {
            var addNewItemMenu = actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("wybierz typ pliku:");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}.  {addNewItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            return operation;
        }

        public int AddNewItem(char itemType)
        {
            int itemTypeId;
            Int32.TryParse(itemType.ToString(), out itemTypeId);
            Item item = new Item();
            item.TypeId = itemTypeId;
            Console.WriteLine("podaj id nowego pliku");
            var id = Console.ReadLine();
            int itemId;
            Int32.TryParse(id, out itemId);
            Console.WriteLine("Podaj nazwe");
            var name = Console.ReadLine();

            item.Id = itemId;
            item.Name = name;
            Items.Add(item);
            return itemId;
        }

        public void RemoveItem(int removeId)
        {
            Item productToRemove = new Item();
            foreach (var item in Items)
            {
                if (item.Id==removeId)
                {
                    productToRemove = item;
                    break;
                }
            }
            Items.Remove(productToRemove);
        }

      

        public int RemoveItemView()
        {
            Console.WriteLine("Podaj id pliku do usuniecia");
            var ItemId = Console.ReadKey();
            int id;
            Int32.TryParse(ItemId.KeyChar.ToString(), out id);

            return id;

        }
    }
}



