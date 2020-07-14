using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Type = "normal"},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0, Type = "ageing food"},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Type = "normal"},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Type = "legendary"},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, Type = "legendary"},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Type = "backstage passes"},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49, Type = "backstage passes"},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49, Type = "backstage passes"},
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Type = "conjured"}
            };
            foreach (var item in Items)
            {
                item.AffixAttributes();
            }// replace this

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
