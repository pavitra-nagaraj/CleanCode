using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket
{
    public class MovieTicketsUpdater : ItemUpdater
    {
        public MovieTicketsUpdater(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0; // Expires completely after event
                return;
            }

            if (item.Quality < 50 && item.Quality > 0)
            {
                item.Quality++;
                if (item.SellIn < 10) item.Quality++;
                if (item.SellIn < 5) item.Quality++;
            }
        }
    }
}
