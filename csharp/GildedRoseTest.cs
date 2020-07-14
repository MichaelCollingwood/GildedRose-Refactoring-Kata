using NUnit.Framework;
using System.Collections.Generic;
using ApprovalUtilities.Utilities;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void StandardDegradation()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Type = "normal"},
            };
            
            Items.ForEach(x => x.AffixAttributes());
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(19, Items[0].Quality);
        }
        [Test]
        public void StandardAscension()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 20, Type = "ageing food"},
            };
            
            Items.ForEach(x => x.AffixAttributes());
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(21, Items[0].Quality);
        }
        
        [Test]
        public void NonNegativeQualities()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 20, Type = "ageing food"},
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0, Type = "normal"},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 49, Type = "backstage passes"}
            };
            
            Items.ForEach(x => x.AffixAttributes());
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Greater(Items[0].Quality,-1);
            Assert.Greater(Items[1].Quality,-1);
            Assert.Greater(Items[2].Quality,-1);
        }
        
        [Test]
        public void UpperBoundedQualities()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 50, Type = "ageing food"},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 50, Type = "backstage passes"}
            };
            
            Items.ForEach(x => x.AffixAttributes());
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Less(Items[0].Quality,51);
            Assert.Less(Items[1].Quality,51);
        }
        
        [Test]
        public void LegendaryItemStationary()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, Type = "legendary"}
            };
            
            Items.ForEach(x => x.AffixAttributes());
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1,Items[0].SellIn);
            Assert.AreEqual(80,Items[0].Quality);
        }
        
        [Test]
        public void BackStagePasses()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Type = "backstage passes"},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20, Type = "backstage passes"},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20, Type = "backstage passes"},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20, Type = "backstage passes"}
            };
            
            Items.ForEach(x => x.AffixAttributes());
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(21,Items[0].Quality);
            Assert.AreEqual(22,Items[1].Quality);
            Assert.AreEqual(23,Items[2].Quality);
            Assert.AreEqual(0,Items[3].Quality);
        }
        
        [Test]
        public void ConjuredItems()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Type = "conjured"}
            };
            
            Items.ForEach(x => x.AffixAttributes());
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4,Items[0].Quality);
        }
    }
}
