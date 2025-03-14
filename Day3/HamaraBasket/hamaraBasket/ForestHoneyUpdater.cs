using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket
{
    public class ForestHoneyUpdater : ItemUpdater
    {
        public ForestHoneyUpdater(Item item) : base(item) { }

        protected override void UpdateSellIn()
        {
            // Forest Honey never decreases in SellIn
        }

        protected override void UpdateQuality()
        {
            // Forest Honey never changes in Quality
        }
    }
}
