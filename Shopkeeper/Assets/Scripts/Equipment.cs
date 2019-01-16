using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items.Equipment
{
    public class Equipment : Item
    {
        
        public Equipment(string name, float weight, ItemQuality quality) : base(name, weight, quality)
        {
            
        }
    }

    public class Weapon : Equipment
    {
        public int Damage { get; set; }

        public Weapon(string name, float weight, ItemQuality quality, int damage) : base(name, weight, quality)
        {
            this.Damage = damage;
        }

        
    }

    public enum ArmorTypes
    {
        Helmet,
        ShoulderPlate,
        Chestplate,
        Gauntlet,
        LegGuard,
        Shoe
    }


    public class Armor : Equipment
    {
        public int Defense { get; private set; }

        public ArmorTypes Type { get; private set; }



        public Armor(string name, float weight, ItemQuality quality, int defense, ArmorTypes type) : base(name, weight, quality)
        {
            this.Defense = defense;
            this.Type = type;
        }
    }

    public enum AccessoryTypes
    {
        Finger,
        Neck,
        Handwrist
    }

    public class Accessoir : Equipment
    {
        public AccessoryTypes Type { get; private set; }

        public Accessoir(string name, float weight, ItemQuality quality, AccessoryTypes type) : base(name, weight, quality)
        {
            this.Type = type;
        }
    }

    public enum ClothingTypes
    {
        Shirt,
        Trousers
    }
     
    public class Clothing : Equipment
    {
        public ClothingTypes Type { get; private set; }

        public Clothing(string name, float weight, ItemQuality quality, ClothingTypes type) : base(name, weight, quality)
        {
            this.Type = type;
        }
    }

}