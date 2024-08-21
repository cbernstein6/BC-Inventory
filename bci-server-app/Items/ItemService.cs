using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bci_server_app.ItemsService;
using bci_server_app.Model;
using bci_server_app.Context;
using AutoMapper;

namespace bci_server_app.Items
{
    public class ItemService : IItemService
    {
        private readonly BciDbContext _context;
        private readonly IMapper _mapper;
        public ItemService(BciDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        public Task<Item> GetItem(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public Task<Item> AddItem(CreateItemDto newItem)
        {
            Item item = _mapper.Map<Item>(newItem);
            _context.Items.Add(item);
            _context.SaveChanges();
            return Task.FromResult(item);
        }


        public Task RemoveItem(int id)
        {
            Item item = _context.Items.Find(id);

            if (item != null)
            {
                Console.WriteLine(id);
                _context.Items.Remove(item);
                _context.SaveChanges();
            }

            return Task.CompletedTask;
        }

        public Task<Item> UpdateItem(Item item)
        {
            Item update = _context.Items.FirstOrDefault(x => x.Id == item.Id);

            if (item != null)
            {
                update.Title = item.Title;
                update.Description = item.Description;
                update.Category = item.Category;
                update.ImageUrl = item.ImageUrl;
                update.Price = item.Price;
                update.Quantity = item.Quantity;
            }
            else throw new KeyNotFoundException("Item not found");

            _context.SaveChanges();

            return Task.FromResult(update);
        }
    }
}