using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Items.Equipment;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public EquipmentInventory PlayerEquipment { get; private set; }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class EquipmentInventory
    {
        public Armor Helmet { get; private set; }
        public Armor LeftShoulder { get; private set; }
        public Armor RightShoulder { get; private set; }
        public Armor Chestplate { get; private set; }
        public Armor LeftArm { get; private set; }
        public Armor RightArm { get; private set; }
        public Armor LeftShoe { get; private set; }
        public Armor RightShoe { get; private set; }
        public Armor LeftLegGuard { get; set; }
        public Armor RightLegGuard { get; set; }

        public Clothing Shirt { get; private set; }
        public Clothing Trousers { get; private set; }

        public Accessoir[] Fingers { get; private set; } = new Accessoir[8];
        public Accessoir[] HandWrist { get; private set; } = new Accessoir[6];
        public Accessoir[] Neck { get; private set; } = new Accessoir[2];

        public Weapon LeftWeapon { get; private set; }
        public Weapon RightWeapon { get; private set; }




        public Armor Equip(Armor item, int slot = 0)
        {
            Armor oldArmor = null;
            if (slot == 0 || slot > 2) slot = this.DeterminBestArmorSlot(item.Type);

            switch (item.Type)
            {
                case ArmorTypes.Chestplate:
                    oldArmor = this.Chestplate;
                    this.Chestplate = item;
                    break;

                case ArmorTypes.Gauntlet:
                    switch (slot)
                    {
                        case 1:
                            oldArmor = this.LeftArm;
                            this.LeftArm = item;
                            break;

                        case 2:
                            oldArmor = this.RightArm;
                            this.RightArm = item;
                            break;
                    }
                    break;

                case ArmorTypes.Helmet:
                    oldArmor = this.Helmet;
                    this.Helmet = item;
                    break;

                case ArmorTypes.LegGuard:
                    switch (slot)
                    {
                        case 1:
                            oldArmor = this.LeftLegGuard;
                            this.LeftArm = item;
                            break;

                        case 2:
                            oldArmor = this.RightLegGuard;
                            this.RightArm = item;
                            break;
                    }
                    break;

                case ArmorTypes.Shoe:
                    switch (slot)
                    {
                        case 1:
                            oldArmor = this.LeftShoe;
                            this.LeftArm = item;
                            break;

                        case 2:
                            oldArmor = this.RightShoe;
                            this.RightArm = item;
                            break;
                    }
                    break;

                case ArmorTypes.ShoulderPlate:
                    switch (slot)
                    {
                        case 1:
                            oldArmor = this.LeftShoulder;
                            this.LeftArm = item;
                            break;

                        case 2:
                            oldArmor = this.RightShoulder;
                            this.RightArm = item;
                            break;
                    }
                    break;
            }
            return oldArmor;
        }

        public Clothing Equip(Clothing item)
        {
            
            Clothing oldClothing = null;

            switch (item.Type)
            {
                case ClothingTypes.Shirt:
                    oldClothing = this.Shirt;
                    this.Shirt = item;
                    break;

                case ClothingTypes.Trousers:
                    oldClothing = this.Trousers;
                    this.Trousers = item;
                    break;

            } return oldClothing;
        }

        public Equipment Equip(Accessoir item, int slot = 0)
        {
            return null;
        }

        public Equipment Equip(Weapon item, int slot = 0)
        {
            return null;
        }

        private int DeterminBestArmorSlot(ArmorTypes type)
        {
            switch (type)
            {
                case ArmorTypes.Gauntlet:
                    if (this.LeftArm.Worth >= this.RightArm.Worth) return 1;
                    else return 2;

                case ArmorTypes.LegGuard:
                    if (this.LeftLegGuard.Worth >= this.RightLegGuard.Worth) return 1;
                    else return 2;

                case ArmorTypes.Shoe:
                    if (this.LeftShoe.Worth >= this.RightShoe.Worth) return 1;
                    else return 2;

                case ArmorTypes.ShoulderPlate:
                    if (this.LeftShoulder.Worth >= this.RightShoulder.Worth) return 1;
                    else return 2;

                case ArmorTypes.Chestplate:
                    return 1;

                case ArmorTypes.Helmet:
                    return 1;

            }
            return 0;
        }

        private int DeterminBestAccessoirSlot(AccessoryTypes type)
        {
            return 0;
        }
    }
}