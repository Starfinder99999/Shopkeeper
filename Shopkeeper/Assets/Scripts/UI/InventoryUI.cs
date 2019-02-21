using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Generic;
using Items;

namespace GameUI
{
    public class InventoryUI : MonoBehaviour
    {

        [SerializeField] Inventory inventory;

        // Use this for initialization
        void Awake()
        {
            //this.gameObject.SetActive(false);
            this.OpenInventory();
        }

        public void ToggleInventory()
        {
            if (this.gameObject.activeSelf == true)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.OpenInventory();
            }
        }
        private void OpenInventory()
        {
            foreach (Item item in inventory.ItemList.Keys)
            {
                this.CreateItemSlot(item, inventory.ItemList[item]);
            }

             ///TODO make Refresh Item List function
            this.gameObject.SetActive(true);
        }

        private void CreateItemSlot(Item item, int amount)
        {
            Debug.Log(item.Name + "Hello");
        }

        public void RefreshItemList()
        {
            //TODO RefreshItemList()
        }
    }
}