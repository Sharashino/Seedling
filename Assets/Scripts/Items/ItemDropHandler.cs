using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler, IEndDragHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var Item = eventData.pointerDrag.GetComponentInParent<InventorySlot>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "Pot")
            {
                GameObject Pot = hit.collider.gameObject;
                Item.UseItem();
                Item.RemoveItem();
            }
            else if(hit.collider.tag == "Ground")
            {
                GameObject Pot = hit.collider.gameObject;
                Item.UseItem();
                Item.RemoveItem();
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
