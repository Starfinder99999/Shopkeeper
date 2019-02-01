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

        /// <summary>
        /// Adds amount to value of key item.
        /// If the Inventory does not contain the key item, its adds a key with the value of amount.
        /// </summary>
        /// <param name="item">Key in Dictionary</param>
        /// <param name="amount"> amount >= 0 </param>
        /// <returns>Returns false if not successfull</returns>
        public bool AddItem(Item item, int amount = 1)
        {

            if (this.currentWeight + item.Weight <= this.weightLimit && amount >= 0)
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

        /// <summary>
        /// Reduces value of key item by amount.
        /// If amount = value, the key is deleted.
        /// If amount > value, returns false.
        /// </summary>
        /// <param name="item">key</param>
        /// <param name="amount">value >= 0</param>
        /// <returns>False if unsuccessfull</returns>
        public bool RemoveItem(Item item, int amount = 1)

        { 
            if (this.ItemList.ContainsKey(item) && this.ItemList[item] <= amount){ //CHECK if runtime error occurs
                this.currentWeight -= (item.Weight * amount);
                this.ItemList[item] -= amount;
                if (this.ItemList[item] <= 0) this.ItemList.Remove(item);
                return true;
            }
            else
            {
               
                return false;
            }
        }

    }
}