using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Generic
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] float weightLimit;

        public Dictionary<Item, int> ItemList { get; private set; }

        [SerializeField] private float currentWeight;

        private void Awake()
        {
            this.ItemList = new Dictionary<Item, int>();
           
        }

        public bool AddItem(Item item, int amount = 1)
        {

            if (this.currentWeight + item.Weight <= this.weightLimit)
            {
                if (!this.ItemList.ContainsKey(item)) this.ItemList.Add(item, amount);
                else this.ItemList[item] += amount;
                this.currentWeight += (item.Weight * amount);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItem(Item item, int amount = 1)

        { 
            if (this.ItemList.ContainsKey(item) && this.ItemList[item] <= amount){ //TODO check if runtime error occurs
                this.currentWeight -= (item.Weight * amount);
                this.ItemList[item] -= amount;
                if (this.ItemList[item] <= 0) this.ItemList.Remove(item);
                return true;
            }
            else
            {
                Debug.Log(item + " " + item.Name + " not found in Inventory of " + this.gameObject);
                return false;
            }
        }

    }
}