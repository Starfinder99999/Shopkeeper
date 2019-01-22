using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

    [SerializeField] Generic.Inventory inventory;

    Items.Item item;

    public void AddItem()
    {
        
        inventory.AddItem(item);
    }
    
    public void Remove (int index)
    {
        inventory.RemoveItem(index);
    }

    public void Remove()
    {
        inventory.RemoveItem(item);
    }
}
