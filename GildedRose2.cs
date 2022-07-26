using csharp;
using System;
using System.Collections.Generic;

public interface IItemQualityChanger
{
    void Change(Item item);
    int QualityChange { get; set; }
}

public class CannedBeanChanger : IItemQualityChanger
{
    public int QualityChange { get; set; }

    public void Change(Item item)
    {
    }
}

public class AgedBrieChanger : IItemQualityChanger
{
    private const int MAX_BRIE_QUALITY = 50;

    public int QualityChange { get; set; }

    public void Change(Item item)
    {
        --item.SellIn;

        var qualityChange = QualityChange;

        item.Quality = Math.Min(item.Quality + qualityChange, MAX_BRIE_QUALITY);
    }
}

public class DefaultChanger : IItemQualityChanger
{
    public int QualityChange { get; set; }

    public void Change(Item item)
    {
        --item.SellIn;

        var qualityChange = QualityChange;

        if (item.SellIn < 0)
        {
            qualityChange *= 2;
        }

        if (item.Quality > 0)
        {
            item.Quality = Math.Max(0, item.Quality - qualityChange);
        }
    }
}

public class GildedRose2
{

    IList<Item> Items;
    public GildedRose2(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];

            var qualityChanger = GetItemQualityChanger(item);
            qualityChanger.Change(item);
        }
    }

    private IItemQualityChanger GetItemQualityChanger(Item item)
    {
        switch (item.Name)
        {
            case "Canned Beans":
                return new CannedBeanChanger() { QualityChange = 0 };
            case "Aged Brie":
                return new AgedBrieChanger() { QualityChange = 1 };
            default:
                return new DefaultChanger() { QualityChange = item.Name.Contains("Baked") ? 2 : 1 };
        }
    }
}
