using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket
{
    
   public abstract class ItemUpdater
   {
       protected Item item;

       protected ItemUpdater(Item item)
       {
           this.item = item;
       }

       public void Update()
       {
           UpdateQuality();
           UpdateSellIn();
           HandleExpired();
       }

       protected virtual void UpdateQuality() { }
       protected virtual void UpdateSellIn() { item.SellIn--; }
       protected virtual void HandleExpired() { }
   }
}
