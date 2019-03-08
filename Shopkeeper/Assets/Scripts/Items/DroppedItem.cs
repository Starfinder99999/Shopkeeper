using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class DroppedItem : MonoBehaviour
    {

        [SerializeField] public GameObject canvas;
        [SerializeField] public UnityEngine.UI.Text itemNameText;
        [SerializeField] public int itemID;
        [SerializeField] Items.ItemManagerSingleton itemManager;
        private Items.Item item;

        // Use this for initialization
        void Awake()
        {
            item = itemManager.CreateItem(itemID);
            itemNameText.text = item.Name;
            HideDetails();
            
        }

        private void OnEnable()
        {
            Generic.EventManager.OnShowDetails += ShowDetails;
            Generic.EventManager.OnHideDetails += HideDetails;
        }

        private void OnDisable()
        {
            Generic.EventManager.OnShowDetails -= ShowDetails;
            Generic.EventManager.OnHideDetails -= HideDetails;
        }

        // Update is called once per frame


        private void Interact(Character.Character player)
        {
            player.inventory.AddItem(item, 1);
            Destroy(this.gameObject);
        }

        void ShowDetails()
        {
            canvas.SetActive(true);
        }

        void HideDetails()
        {
            canvas.SetActive(false);
        }
    }
}
