using System.Collections.Generic;
using NDesk.Options;

namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public string Type { get; set; }
        public bool Perishable { get; set; }
        public int Change { get; set; }
        public Dictionary<int, int> MileStones { get; set; }
        
        public void AffixAttributes()
        {
            OptionSet typeOptions = new OptionSet()
            {
                {
                    "normal", v =>
                    {
                        Perishable = false;
                        Change = -1;
                        MileStones = new Dictionary<int, int>{{0,Change*2}}; 
                    }
                },
                {
                    "ageing food", v =>
                    {
                        Perishable = true;
                        Change = 1;
                        MileStones = new Dictionary<int, int>{{0,0}}; 
                    }
                },
                {
                    "legendary", v =>
                    {
                        Perishable = false;
                        Change = 0;
                        MileStones = new Dictionary<int, int>(); 
                    }
                },
                {
                    "backstage passes", v =>
                    {
                        Perishable = true;
                        Change = 1;
                        MileStones = new Dictionary<int, int>{{10,2},{5,3},{0,0}}; 
                    }
                },
                {
                    "conjured", v =>
                    {
                        Perishable = false;
                        Change = -2;
                        MileStones = new Dictionary<int, int>{{0,Change*2}}; 
                    }
                }
            };
            typeOptions.Parse(new string[] {"-"+Type});
        }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
