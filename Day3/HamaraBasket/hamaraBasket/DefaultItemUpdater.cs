using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket
{
    public class DefaultItemUpdater : ItemUpdater
    {
        public DefaultItemUpdater(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            if (item.Quality > 0)
                item.Quality--;
        }

        protected override void HandleExpired()
        {
            if (item.SellIn < 0 && item.Quality > 0)
                item.Quality--; // Degrades twice as fast after expiry
        }
    }
}
