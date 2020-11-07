using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int inventorySpace = 9;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> items = new List<Item>();

    //Adding item
    public bool AddItem(Item itemToAdd)
    {
        //Checking if player has enough room to pick up an item
        if (items.Count >= inventorySpace)
        {
            Debug.Log("Not enough space...");
            return false;
        }
        else
        {
            items.Add(itemToAdd);
            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            return true;
        }
    }

    //Removing the item
    public void Remove(Item itemToRemove)
    {
        items.Remove(itemToRemove);
        
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
