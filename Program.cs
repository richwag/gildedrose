using System;
using System.Collections.Generic;
using System.Text;

namespace csharp
{
    public class Program
    {
        private const int Days = 31;

        public static void Main(string[] args)
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Bananas", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Eggs", SellIn = 5, Quality = 7},
                new Item {Name = "Eggs", SellIn = 12, Quality = 5},
                new Item {Name = "Canned Beans", SellIn = 0, Quality = 80},
                new Item {Name = "Canned Beans", SellIn = -1, Quality = 80},
                
                // This Baked good does not work properly yet!
                new Item {Name = "Baked Sourdough Bread", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < (Days + 1); i++)
            {
                sb.AppendLine("-------- day " + i + " --------");
                sb.AppendLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    sb.AppendLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                sb.AppendLine("");
                app.UpdateQuality();
            }

            StringBuilder sb2 = new StringBuilder();

            IList<Item> Items2 = new List<Item>{
                new Item {Name = "Bananas", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Eggs", SellIn = 5, Quality = 7},
                new Item {Name = "Eggs", SellIn = 12, Quality = 5},
                new Item {Name = "Canned Beans", SellIn = 0, Quality = 80},
                new Item {Name = "Canned Beans", SellIn = -1, Quality = 80},
                
                // This Baked good does not work properly yet!
                new Item {Name = "Baked Sourdough Bread", SellIn = 3, Quality = 6}
            };

            var app2 = new GildedRose2(Items2);

            for (var i = 0; i < (Days + 1); i++)
            {
                sb2.AppendLine("-------- day " + i + " --------");
                sb2.AppendLine("name, sellIn, quality");
                for (var j = 0; j < Items2.Count; j++)
                {
                    sb2.AppendLine(Items2[j].Name + ", " + Items2[j].SellIn + ", " + Items2[j].Quality);
                }
                sb2.AppendLine("");
                app2.UpdateQuality();
            }

            if (sb.ToString() == sb2.ToString())
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine(sb.ToString());
                Console.WriteLine(sb2.ToString());
                Console.WriteLine("Failure");
            }
        }
    }
}
