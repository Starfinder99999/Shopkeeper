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
        public Armor RightShoe { get;private set; }

        public Clothing Shirt { get; private set; }
        public Clothing Trousers { get; private set; }

        public Accessoir[] Fingers { get; private set; } = new Accessoir[10];
        public Accessoir[] HandWrist { get; private set; } = new Accessoir[6];
        public Accessoir[] Neck { get; private set; } = new Accessoir[2];

        public Weapon LeftWeapon { get; private set; }
        public Weapon RightWeapon { get; private set; }




        public Equipment EquipArmor(Armor item) {
            Armor oldArmor;
            switch (item.Type)
            {
                case ArmorTypes.Chestplate:
                    oldArmor = this.Chestplate;
                    this.Chestplate = item;
                    break;
            }

        }
        public Equipment EquipClothing(Clothing item)
        {

        }
        public Equipment EquipAccessoir(Accessoir item)
        {

        }
    }
}