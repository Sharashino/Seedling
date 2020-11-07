using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;

        //Subscribed to onItemChangedCallback event, when it runs, run also UpdateUI
        inventory.onItemChangedCallback += UpdateUI;

        //Getting our inventory slots
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //Checking if there are more items to add
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            //Clear the slot
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
