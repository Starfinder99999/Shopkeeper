using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Generic
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] float weightLimit;

        public List<Item> ItemList { get; private set; }

        [SerializeField] private float currentWeight;

        private void Awake()
        {
            this.ItemList = new List<Item>();
           
        }

        public bool AddItem(Item item)
        {

            if (this.currentWeight + item.Weight <= this.weightLimit)
            {
                this.ItemList.Add(item);
                this.currentWeight += item.Weight;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItem(Item item)

        { 
            if (this.ItemList.Contains(item)){
                this.currentWeight -= item.Weight;
                this.ItemList.Remove(item);
                return true;
            }
            else
            {
                Debug.Log(item + " " + item.Name + " not found in Inventory of " + this.gameObject);
                return false;
            }
                
        }

        public Item RemoveItem(int itemIndex)
        {
            if (this.ItemList.Count > itemIndex)
            {
                this.currentWeight -= this.ItemList[itemIndex].Weight;
                Item item = this.ItemList[itemIndex];
                this.ItemList.RemoveAt(itemIndex);
                return item;
            }
            else
            {
                Debug.Log("Index " + itemIndex + " not in Inventory of " + this.gameObject);
                return null;
            }
        }
    }
}