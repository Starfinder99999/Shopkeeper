using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Items.Equipment;

namespace Character.Player
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
        //Naming is oriented to the UI, switched in players perspective
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


        /* Public Methods */

            /// <summary>
            /// Equips item of type Armor in slot.
            /// </summary>
            /// <param name="item">The Item to be Equipped</param>
            /// <param name="slot">Left = 0, Right = 1</param>
            /// <returns>Previous value of changed Slot</returns>
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

        /// <summary>
        /// Equips item of Type Clothing.
        /// </summary>
        /// <param name="item">The Item to be Equipped</param>
        /// <returns>Previous value of changed Slot</returns>
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

        /// <summary>
        /// Equips item of type Accessoir in slot.
        /// </summary>
        /// <param name="item">The Item to be Equipped</param>
        /// <param name="slot">Slot in which it will be Equipped</param>
        /// <returns>Previous value of changed Slot</returns>
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

        /// <summary>
        /// Equips item of type Weqpon in slot.
        /// </summary>
        /// <param name="item">The Item to be Equipped</param>
        /// <param name="slot">Left = 0, Right = 1</param>
        /// <returns>Previous value of changed Slot</returns>
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

        /// <summary>
        /// Sets the Value of the selected slot to null.
        /// </summary>
        /// <param name="leftWeapon"></param>
        /// <returns>Previous value of changed Slot</returns>
        public Weapon DeEquip(bool leftWeapon)
        {
            Weapon oldWeapon = null;

            if (leftWeapon)
            {
                oldWeapon = this.LeftWeapon;
                this.LeftWeapon = null;
            }
            else
            {
                oldWeapon = this.RightWeapon;
                this.RightWeapon = null;
            }

            return oldWeapon;
        }

        /// <summary>
        /// Sets the Value of selected slot to null.
        /// </summary>
        /// <param name="type">Type of the Armor to DeEquip</param>
        /// <param name="leftArmor"></param>
        /// <returns>Previous value of changed Slot</returns>
        public Armor DeEquip(ArmorTypes type, bool leftArmor = true)
        {
            Armor oldArmor = null;
            switch (type)
            {
                case ArmorTypes.Chestplate:
                    oldArmor = this.Chestplate;
                    this.Chestplate = null;
                    break;

                case ArmorTypes.Gauntlet:
                    if (leftArmor)
                    {
                        oldArmor = this.LeftArm;
                        this.LeftArm = null;
                    }
                    else
                    {
                        oldArmor = this.RightArm;
                        this.RightArm = null;
                    }break;

                case ArmorTypes.Helmet:
                    oldArmor = this.Helmet;
                    this.Helmet = null;
                    break;

                case ArmorTypes.LegGuard:
                    if (leftArmor)
                    {
                        oldArmor = this.LeftLegGuard;
                        this.LeftLegGuard = null;
                    }
                    else
                    {
                        oldArmor = this.RightLegGuard;
                        this.RightLegGuard = null;
                    }break;

                case ArmorTypes.Shoe:
                    if (leftArmor)
                    {
                        oldArmor = this.LeftShoe;
                        this.LeftShoe = null;
                    }
                    else
                    {
                        oldArmor = this.RightShoe;
                        this.RightShoe = null;
                    }break;

                case ArmorTypes.ShoulderPlate:
                    if (leftArmor)
                    {
                        oldArmor = this.LeftShoulder;
                        this.LeftShoulder = null;
                    }
                    else
                    {
                        oldArmor = this.RightShoulder;
                        this.RightShoulder = null;
                    }break;


            }

            return oldArmor;
        }

        /// <summary>
        /// Sets the Value of selected slot to null.
        /// </summary>
        /// <param name="type">Type of the Accessoir to DeEquip</param>
        /// <param name="slot"></param>
        /// <returns>Previous value of changed Slot</returns>
        public Accessoir DeEquip(AccessoryTypes type, int slot = 0)
        {
            Accessoir oldAccessoir = null;

            switch (type)
            {
                case AccessoryTypes.Finger:
                    if (slot > 7 || slot < 0) Debug.LogError("Slot of DeEquip(Fingers) out of range");
                    else if (this.Fingers[slot] == null) Debug.LogWarning("Can't DeEquip(Fingers) slot with null");
                    else
                    {
                        oldAccessoir = this.Fingers[slot];
                        this.Fingers[slot] = null;
                    }break;

                case AccessoryTypes.Handwrist:
                    if (slot > 5 || slot < 0) Debug.LogError("Slot of DeEquip(Handwrist) out of range");
                    else if (this.Fingers[slot] == null) Debug.LogWarning("Can't DeEquip(Handwrist) slot with null");
                    else
                    {
                        oldAccessoir = this.HandWrist[slot];
                        this.HandWrist[slot] = null;
                    }break;

                case AccessoryTypes.Neck:
                    if (slot > 1 || slot < 0) Debug.LogError("Slot of DeEquip(Neck) out of range");
                    else if (this.Fingers[slot] == null) Debug.LogWarning("Can't DeEquip slot(Neck) with null");
                    else
                    {
                        oldAccessoir = this.Neck[slot];
                        this.Neck[slot] = null;
                    }
break;
            }


            return oldAccessoir;
        }

        /// <summary>
        /// Sets the Value of selected slot to null.
        /// </summary>
        /// <param name="type">Type of the Clothing to DeEquip</param>
        /// <returns>Previous value of changed Slot</returns>
        public Clothing DeEquip(ClothingTypes type)
        {
            Clothing oldClothing = null;
            switch (type)
            {
                case ClothingTypes.Shirt:
                    oldClothing = this.Shirt;
                    this.Shirt = null;
                    break;

                case ClothingTypes.Trousers:
                    oldClothing = this.Trousers;
                    this.Trousers = null;
                    break;
            }


            return oldClothing;
        }


        /* Private Methods */

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
                        if (this.Fingers[i] != null)
                        {
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