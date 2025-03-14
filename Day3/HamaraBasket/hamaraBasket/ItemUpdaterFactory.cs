using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket
{
    public static class ItemUpdaterFactory
    {
        public static ItemUpdater Create(Item item)
        {
            return item.Name switch
            {
                "Indian Wine" => new IndianWineUpdater(item),
                "Movie Tickets" => new MovieTicketsUpdater(item),
                "Forest Honey" => new ForestHoneyUpdater(item),
                _ => new DefaultItemUpdater(item)
            };
        }
    }
}
