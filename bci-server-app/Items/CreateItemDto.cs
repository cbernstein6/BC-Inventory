using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bci_server_app.Items
{
    public class CreateItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}