using System.Collections.Generic;
using System;

namespace csharp
{

    public class GildedRose
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string CANNED_BEANS = "Canned Beans";
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == CANNED_BEANS)
                {
                    continue;
                }

                Items[i].SellIn = Items[i].SellIn - 1;


                if (Items[i].Name.Contains("Baked"))
                {
                    Items[i].Quality = Math.Max(0, Items[i].Quality - 2);
                }
                else if (Items[i].Name == AGED_BRIE)
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
                else
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Canned Beans")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }

                CheckIfItemHasExpired(i);
            }
        }

        private void CheckIfItemHasExpired(int i)
        {
            // If the item has expired
            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name == AGED_BRIE)
                {
                    // Aged Brie increases in value as it gets older
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
                if (Items[i].Name.Contains("Baked"))
                {
                    if (Items[i].Quality > 0)
                    {
                        Items[i].Quality = Items[i].Quality - 2;
                    }
                }
                else
                {
                    // Decrement our quality until it's zero
                    if (Items[i].Quality > 0)
                    {

                        Items[i].Quality = Items[i].Quality - 1;

                    }
                }

            }
        }
    }
}
