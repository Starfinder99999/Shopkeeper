using System.Collections;
using System.Collections.Generic;


namespace Items
{
    public class Item
    {
        public string Name { get; private set; }
        public float Weight { get; private set; }

        public Item(string name, float weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
    }
}