using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bci_server_app.Model;
using bci_server_app.Items;


namespace bci_server_app.ItemsService
{
    public interface IItemService
    {
        Task<Item> GetItem(int index);
        // Task<IEnumerable<Item>> GetItems();
        IEnumerable<Item> GetItems();
        Task<Item> AddItem(CreateItemDto item);
        Task RemoveItem(int index);
        Task<Item> UpdateItem(Item item);

    }
}