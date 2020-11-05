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
            if(hittedObject.tag == "Pot")
            {
                ItemOnSlot.UseItemOn(hittedObject.gameObject, ItemOnSlot.item.itemObject);
                ItemOnSlot.RemoveItem();
            }
            else if(hittedObject.tag == "Ground")
            {
                ItemOnSlot.UseItemOn(hittedObject.gameObject, ItemOnSlot.gameObject);
                ItemOnSlot.RemoveItem();
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
