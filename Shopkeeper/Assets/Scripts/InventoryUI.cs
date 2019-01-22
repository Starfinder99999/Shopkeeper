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
        [SerializeField] GameObject uiItem;

        // Use this for initialization
        void Awake()
        {
            this.gameObject.SetActive(false);
        }

        public void OpenInventory()
        {
            /*foreach (Item item in inventory.ItemList)
            {
                GameObject newUiItem = uiItem;
            }
            */
            this.gameObject.SetActive(true);
            
        }
    }
}