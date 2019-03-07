using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class ItemManagerSingleton : MonoBehaviour {

        private static ItemManagerSingleton singleton;

        // Use this for initialization
        void Awake() {
            if (!singleton) singleton = this;
            else
            {
                Debug.Log("Double Singleton detected");
                Destroy(this);
            }
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