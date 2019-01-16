using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class InventoryUI : MonoBehaviour
    {

        // Use this for initialization
        void Awake()
        {
            this.gameObject.SetActive(false);
        }

        public void OpenInventory()
        {
            this.gameObject.SetActive(true);
        }
    }
}