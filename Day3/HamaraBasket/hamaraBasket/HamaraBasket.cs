using System.Collections.Generic;

namespace hamaraBasket
{
    public class HamaraBasket
    {
        IList<Item> Items;

        public HamaraBasket(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                ItemUpdater updater = ItemUpdaterFactory.Create(item);
                updater.Update();
            }
        }
    }
}
