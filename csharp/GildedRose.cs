using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                // update item properties
                if (item.MileStones != null)
                {
                    item.Change = item.MileStones.ContainsKey(item.SellIn) ? item.MileStones[item.SellIn] : item.Change;
                }
                item.Quality = item.Perishable && item.SellIn < 0 ? 0 : item.Quality + item.Change;
                item.SellIn += item.Type == "legendary" ? 0 : -1;
                
                // conditions on quality
                item.Quality = item.Quality > 50 && item.Type != "legendary"? 50 : item.Quality;
                item.Quality = item.Quality < 0 ? 0 : item.Quality;
            }
        }
    }
}
