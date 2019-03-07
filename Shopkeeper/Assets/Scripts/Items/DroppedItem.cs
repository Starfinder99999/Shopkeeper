using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class DroppedItem : MonoBehaviour
    {

        [SerializeField] public Canvas canvas;
        [SerializeField] public int itemID;
        [SerializeField] Items.ItemManagerSingleton itemManager;
        private Items.Item item;

        // Use this for initialization
        void Awake()
        {
            item = itemManager.CreateItem("Bread");
        }

        // Update is called once per frame


        private void Interact(Character player)
        {
            player.inventory.AddItem(item, 1);
            Destroy(this.gameObject);
        }
    }
}
