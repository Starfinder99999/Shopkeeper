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

        [SerializeField] public Inventory inventory;
        [SerializeField] public GameObject content;
        [SerializeField] public GameObject slotPrefab;

        // Use this for initialization
        void Awake()
        {
            this.CreateItemSlot(new Item("Toast2", 12f, Items.ItemQuality.common), 2);
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
                foreach (GameObject slot in content.GetComponentsInChildren<GameObject>())
                {

                }
                this.CreateItemSlot(item, inventory.ItemList[item]);
            }

             ///TODO make Refresh Item List function
            this.gameObject.SetActive(true);
        }

        private void CreateItemSlot(Item item, int amount)
        {
            GameObject slot = GameObject.Instantiate(slotPrefab);
            slot.transform.SetParent(content.transform);
            slot.GetComponentsInChildren<Text>()[1].text = item.Name;
            slot.GetComponentsInChildren<Text>()[0].text = amount.ToString();
        }

        public void AddItemTo ()
        {
            //TODO RefreshItemList()
        }
    }
}