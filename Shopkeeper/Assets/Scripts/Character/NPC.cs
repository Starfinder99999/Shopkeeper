using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.NPC
{
    public class NPC : Character
    {
        [SerializeField] public GameObject npcHUD;
        [SerializeField] public List<int> inventoryItems;
        [SerializeField] public GameObject droppedItem;

        private void Awake()
        {
            base.Awake();
            hideHUD();
        }

        private void OnEnable()
        {
            Generic.EventManager.OnShowDetails += showHUD;
            Generic.EventManager.OnHideDetails += hideHUD;
        }

        private void OnDisable()
        {
            Generic.EventManager.OnShowDetails -= showHUD;
            Generic.EventManager.OnHideDetails -= hideHUD;
        }

        void hideHUD()
        {
            npcHUD.SetActive(false);
        }

        void showHUD()
        {
            npcHUD.SetActive(true);
        }

        protected override void Die()
        {
            GameObject droppedItemInstance;
            int inventorySize = inventoryItems.Count;
            int randomIndex;
            for (int i = 1; i <= inventorySize/Random.Range(1.0f, inventorySize/3); i++)
            {
                droppedItemInstance = Instantiate(droppedItem, this.gameObject.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)), new Quaternion(), Items.ItemManagerSingleton.Instance.transform);
                randomIndex = Random.Range((int)0, (int)(inventoryItems.Count - 1));
                droppedItemInstance.GetComponent<Items.DroppedItem>().itemID = inventoryItems[randomIndex];
                inventoryItems.RemoveAt(randomIndex);

            }

            Destroy(this.gameObject);
        }
    }
}