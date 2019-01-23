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
        //Naming is oriented to the UI, switchd in players perspective
        public Armor Helmet { get; private set; } = null;           //Helmet slot 1
        public Armor LeftShoulder { get; private set; } = null;     //Shoulder slot 0
        public Armor RightShoulder { get; private set; } = null;    //Shoulder slot 1
        public Armor Chestplate { get; private set; } = null;       //Chestplate slot 1
        public Armor LeftArm { get; private set; } = null;          //Arm slot 0
        public Armor RightArm { get; private set; } = null;         //Arm slot 1
        public Armor LeftShoe { get; private set; } = null;         //Shoe slot 0
        public Armor RightShoe { get; private set; } = null;        //Shoe slot 1
        public Armor LeftLegGuard { get; set; } = null;             //Leg Guard slot 0
        public Armor RightLegGuard { get; set; } = null;            //Leg Guard slot 1

        public Clothing Shirt { get; private set; } = null;
        public Clothing Trousers { get; private set; } = null;

        public Accessoir[] Fingers { get; private set; } = new Accessoir[8];    //slot range: 0-7
        public Accessoir[] HandWrist { get; private set; } = new Accessoir[6];  //slot range: 0-5
        public Accessoir[] Neck { get; private set; } = new Accessoir[2];       //slot range: 0-1

        public Weapon LeftWeapon { get; private set; } = null;  //Weapon slot 0; primary hand
        public Weapon RightWeapon { get; private set; } = null; //Weapon slot 1; off hand




        public Armor Equip(Armor item, int slot = -1)
        {
            Armor oldArmor = null;
            if (slot < 0 || slot > 1) slot = this.DeterminBestArmorSlot(item.Type);

            switch (item.Type)
            {
                case ArmorTypes.Chestplate:
                    oldArmor = this.Chestplate;
                    this.Chestplate = item;
                    break;

                case ArmorTypes.Gauntlet:
                    switch (slot)
                    {
                        case 0:
                            oldArmor = this.LeftArm;
                            this.LeftArm = item;
                            break;

                        case 1:
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
                        case 0:
                            oldArmor = this.LeftLegGuard;
                            this.LeftArm = item;
                            break;

                        case 1:
                            oldArmor = this.RightLegGuard;
                            this.RightArm = item;
                            break;
                    }
                    break;

                case ArmorTypes.Shoe:
                    switch (slot)
                    {
                        case 0:
                            oldArmor = this.LeftShoe;
                            this.LeftArm = item;
                            break;

                        case 1:
                            oldArmor = this.RightShoe;
                            this.RightArm = item;
                            break;
                    }
                    break;

                case ArmorTypes.ShoulderPlate:
                    switch (slot)
                    {
                        case 0:
                            oldArmor = this.LeftShoulder;
                            this.LeftArm = item;
                            break;

                        case 1:
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

        public Equipment Equip(Accessoir item, int slot = -1)
        {
            Accessoir oldAccessoir = null;
            switch (item.Type)
            {
                case AccessoryTypes.Finger:
                    if (slot < 0 || slot > 7) slot = this.DeterminBestAccessoirSlot(item.Type);
                    oldAccessoir = this.Fingers[slot];
                    this.Fingers[slot] = item;
                    break;

                case AccessoryTypes.Handwrist:
                    if (slot < 0 || slot > 5) slot = this.DeterminBestAccessoirSlot(item.Type);
                    oldAccessoir = this.HandWrist[slot];
                    this.HandWrist[slot] = item;
                    break;

                case AccessoryTypes.Neck:
                    if (slot < 0 || slot > 1) slot = this.DeterminBestAccessoirSlot(item.Type);
                    oldAccessoir = this.Neck[slot];
                    this.Neck[slot] = item;
                    break;
            }
            return oldAccessoir;
        }

        public Equipment[] Equip(Weapon item, int slot = -1)
        {
            Weapon[] oldWeapons = new Weapon[2];
            oldWeapons[0] = null;
            oldWeapons[1] = null;
            switch (item.SlotType)
            {
                case WeaponSlotTypes.Offhand:
                    oldWeapons[1] = this.RightWeapon;
                    if (this.LeftWeapon.SlotType == WeaponSlotTypes.Twohanded) oldWeapons[0] = this.LeftWeapon;
                    this.RightWeapon = item;
                    break;

                case WeaponSlotTypes.OneHanded:
                    if (slot < 0 || slot > 1)
                    {
                        if (this.LeftWeapon.Worth > this.RightWeapon.Worth) slot = 1;
                        else slot = 0;
                    }
                    
                    switch (slot)
                    {
                        case 0:
                            oldWeapons[0] = this.LeftWeapon;
                            this.LeftWeapon = item;
                            break;

                        case 1:
                            oldWeapons[1] = this.RightWeapon;
                            this.RightWeapon = item;
                            break;
                    }
                    break;

                case WeaponSlotTypes.Primaryhand:
                    oldWeapons[0] = this.LeftWeapon;
                    this.LeftWeapon = item;
                    break;

                case WeaponSlotTypes.Twohanded:
                    oldWeapons[0] = this.LeftWeapon;
                    oldWeapons[1] = this.RightWeapon;
                    this.LeftWeapon = item;
                    this.RightWeapon = null;
                    break;

            }
            return oldWeapons;
        }

        private int DeterminBestArmorSlot(ArmorTypes type)
        {
            switch (type)
            {
                case ArmorTypes.Gauntlet:
                    if (this.LeftArm == null) return 0;
                    else if (this.RightArm == null) return 1;
                    if (this.LeftArm.Worth >= this.RightArm.Worth) return 1;
                    else return 0;

                case ArmorTypes.LegGuard:
                    if (this.LeftLegGuard == null) return 0;
                    else if (this.RightLegGuard == null) return 1;
                    if (this.LeftLegGuard.Worth >= this.RightLegGuard.Worth) return 1;
                    else return 0;

                case ArmorTypes.Shoe:
                    if (this.LeftShoe == null) return 0;
                    else if (this.RightShoe == null) return 1;
                    if (this.LeftShoe.Worth >= this.RightShoe.Worth) return 1;
                    else return 0;

                case ArmorTypes.ShoulderPlate:
                    if (this.LeftShoulder == null) return 0;
                    else if (this.RightShoulder == null) return 1;
                    if (this.LeftShoulder.Worth >= this.RightShoulder.Worth) return 1;
                    else return 0;

                case ArmorTypes.Chestplate:
                    return 1;

                case ArmorTypes.Helmet:
                    return 1;

            }
            return 0;
        }

        private int DeterminBestAccessoirSlot(AccessoryTypes type)
        {
            int slot = 0;
            float lowestValue = 23456.789f;
            switch (type)
            {
                case AccessoryTypes.Finger:
                    for (int i = 0; i < this.Fingers.Length; i++)
                    {
                        if (this.Fingers[i] != null) {
                            if (lowestValue == 23456.789f) lowestValue = this.Fingers[i].Worth;
                            else if (this.Fingers[i].Worth > lowestValue)
                            {
                                lowestValue = this.Fingers[i].Worth;
                                slot = i;
                            }
                        }
                        else
                        {
                            slot = i;
                            break;
                        }
                    }
                    break;

                case AccessoryTypes.Handwrist:
                    for (int i = 0; i < this.HandWrist.Length; i++)
                    {
                        if (this.HandWrist[i] != null)
                        {
                            if (lowestValue == 23456.789f) lowestValue = this.HandWrist[i].Worth;
                            else if (this.HandWrist[i].Worth > lowestValue)
                            {
                                lowestValue = this.HandWrist[i].Worth;
                                slot = i;
                            }
                        }
                        else
                        {
                            slot = i;
                            break;
                        }
                    }
                    break;

                case AccessoryTypes.Neck:
                    if (this.Neck[0] == null) { slot = 0; break; }
                    if (this.Neck[1] == null) { slot = 1; break; }
                    if (this.Neck[0].Worth >= this.Neck[1].Worth) slot = 1;
                    else slot = 0;
                    
                    break;
            }
            return slot;
        }
    }
}