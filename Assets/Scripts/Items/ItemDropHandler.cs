using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal;

public class ItemDropHandler : MonoBehaviour, IDropHandler, IEndDragHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var ItemOnSlot = eventData.pointerDrag.GetComponentInParent<InventorySlot>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var hittedObject = hit.collider;
            if(hittedObject.tag == "Pot" && ItemOnSlot.item.itemObject.tag == "Ground" && !hittedObject.GetComponent<Pot>().hasGround)
            {
                ItemOnSlot.UseItemOn(hittedObject.gameObject, ItemOnSlot.item.itemObject);
                ItemOnSlot.RemoveItem();
            }
            else if(hittedObject.tag == "Ground" && ItemOnSlot.item.itemObject.tag == "Seedling"  && hittedObject.GetComponent<Ground>().isInPot)
            {
                ItemOnSlot.UseItemOn(hittedObject.gameObject, ItemOnSlot.item.itemObject);
                ItemOnSlot.RemoveItem();
            }
            else if(hittedObject.tag == "Seedling" && ItemOnSlot.item.itemObject.tag == "WaterCan" && hittedObject.gameObject.GetComponent<Seedling>().isPlanted)
            {
                ItemOnSlot.UseItemOn(hittedObject.gameObject, ItemOnSlot.item.itemObject);
                //ItemOnSlot.RemoveItem();
                //Debug.Log("watered down " + hittedObject.name);
            }
            else
            {
                Debug.Log("I cant place that here...");
            }
        }
        //RectTransform inventoryPanel = transform as RectTransform;

        //if (!RectTransformUtility.RectangleContainsScreenPoint(inventoryPanel, Input.mousePosition))
        //{
        //    var Item = eventData.pointerDrag.GetComponentInParent<InventorySlot>();
        //    Debug.Log("Dropped " + Item.item.itemName);
        //    Item.RemoveItem();
        //}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        
    }
}
