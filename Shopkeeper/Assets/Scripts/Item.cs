using System.Collections;
using System.Collections.Generic;


namespace Items
{
    public enum ItemQuality
    {
        lowQuality,
        common,
        highQuality,
        mastercraft,
        masterwork,
        legendary,
        divine,
        organic
    }

    public class Item
    {
        public string Name { get; private set; }
        public float Weight { get; private set; }
        public ItemQuality Quality { get; private set; }

        public Item(string name, float weight, ItemQuality quality)
        {
            this.Name = name;
            this.Weight = weight;
            this.Quality = quality;
        }

        virtual public void Use()
        {
            
        }
    }
}