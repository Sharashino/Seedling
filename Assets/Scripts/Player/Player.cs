using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Camera playerCamera;
    [SerializeField]
    private int plantedSeeds;

    void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        //If player is hovering over inventory
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //If left-clicked 
        else if(Input.GetMouseButtonDown(0))
        {
            LeftClicked();
        }
        //If right-clicked
        else if(Input.GetMouseButtonDown(1))
        {
            RightClicked();
        }
    }

    private void RightClicked()
    {
        Ray mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit = new RaycastHit();

        if (Physics.Raycast(mouseRay, out mouseHit))
        {
            
        }
    }

    private void LeftClicked()
    {
        Ray mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit = new RaycastHit();

        if(Physics.Raycast(mouseRay, out mouseHit))
        {
            ItemPickUp itemToPickUp = mouseHit.collider.GetComponent<ItemPickUp>();
            if(itemToPickUp != null)
            {
                if(itemToPickUp.item.canBePickedUp)
                {
                    itemToPickUp.PickUp(itemToPickUp.item);
                }
            }
            else
            {
                Debug.Log("nie podniose");
            }
        }
    }

    public void PlantGrewUp()
    {
        plantedSeeds++;

        if (plantedSeeds == 3)
        {
            //victory!
            Debug.Log("You won!");
        }
    }
}
