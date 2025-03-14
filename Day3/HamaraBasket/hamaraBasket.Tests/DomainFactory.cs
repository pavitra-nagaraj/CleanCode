using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket.Tests
{
    public class DomainFactory
    {
        public static IList<Item> PrepareSingleItemList(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            return items;
        }

        public static Item GetItemAfterHamaraBasketUpdate(IList<Item> items)
        {
            HamaraBasket app = new HamaraBasket(items);
            app.UpdateQuality();
            return items[0];
        }
    }
}
