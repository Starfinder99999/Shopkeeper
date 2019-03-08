using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class ItemManagerSingleton : MonoBehaviour {

        public static ItemManagerSingleton Instance { get; private set; }

        // Use this for initialization
        void Awake() {
            if (Instance != null && Instance != this)
            {
                Debug.Log("Double Singleton detected");
                Destroy(this);
            }
            else Instance = this;
        }

        public Item CreateItem(int id)
        {
            Item item = new Item("Bread", 1, ItemQuality.common);
            return item;
        }

        public Item CreateItem(string name)
        {
            Item item = new Item(name, 1, ItemQuality.common);
            return item;
        }
    }
}