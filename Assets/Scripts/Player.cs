using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Seedling carriedSeedling;
    public bool isCarryingSeedling;
    public bool isCarryingWaterCan;
    public bool isFocused;
    public List<GameObject> AllPots = new List<GameObject>();

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private int plantedSeeds;
    
    [SerializeField]
    private List<GameObject> inventory = new List<GameObject>();

    void Start()
    {
        playerCamera = Camera.main;
        plantedSeeds = 0;
    }

    private void Update()
    {
        
        //if left-clicked 
        if(Input.GetMouseButtonDown(0))
        {
            LeftClicked();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Defocus();
        }
    }
   
    private void LeftClicked()
    {
        //Getting mouse position from main camera
        Ray mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit = new RaycastHit();

        //If hit (always lol)
        if(Physics.Raycast (mouseRay, out mouseHit))
        {
            GameObject hittedObject = mouseHit.collider.gameObject;

            //If player has empty hands and can carry a seedling
            if (hittedObject.tag == "Seedling" && !isCarryingSeedling)
            {
                GameObject Seedling = mouseHit.collider.gameObject;

                //If player wants to move a seedling that is arleady planted
                if (Seedling.GetComponent<Seedling>().isPlanted != true)
                {
                    carriedSeedling = Seedling.GetComponent<Seedling>();
                    inventory.Add(Seedling);
                    carriedSeedling.IGotPickedUp();
                    isCarryingSeedling = true;

                    Debug.Log("Picked up: " + Seedling.name);
                }
                //If player clicks on a seedling with water can
                else if (Seedling.GetComponent<Seedling>().isPlanted == true && isCarryingWaterCan == true)
                {
                    Seedling.GetComponent<Seedling>().IGotWateredDown();

                    Debug.Log("You watered down: " + Seedling.gameObject.name);
                }
                else
                {
                    Debug.Log("This seedling has been arleady planted");
                }
            }
            //If player hit pot and carries a seedling
            else if(hittedObject.tag == "Pot" && isCarryingSeedling)
            {
                GameObject Pot = mouseHit.collider.gameObject;

                //If players wants to plant a seedling on occupied pot
                if(Pot.GetComponent<Pot>().isOccupied != true)
                {
                    carriedSeedling.GetComponent<Seedling>().IGotPlanted();
                    Pot.GetComponent<Pot>().PlantASeedling(carriedSeedling.gameObject);

                    Debug.Log("Planting " + carriedSeedling.gameObject.name);
                    carriedSeedling = null;
                    isCarryingSeedling = false;
                }
                else
                {
                    Debug.Log("This pot arleady has seedling in it");
                }
            }
            //If player arleady carries a seedling
            else if(isCarryingSeedling)
            {
                Debug.Log("You're arleady carrying a seedling");
            }
            else if(hittedObject.tag == "WaterCan")
            {
                isCarryingWaterCan = true;
                Debug.Log("Picked up: " + hittedObject.name);
            }
            //If player clicks elswere to defocus
            else
            {
                Defocus();
            }
        }
    }

    private void Defocus()
    {
        isFocused = false;
    }

    public void PlantSeed()
    {
        //stopped carrying a seedling, planted it 
        carriedSeedling = null;

        //how mant plants has been planted
    }

    public void PlantGrewUp()
    {
        carriedSeedling = null;
        plantedSeeds++;

        if (plantedSeeds == 3)
        {
            //victory!
            Debug.Log("You won!");
            Collider PlayerColider = GetComponent<Collider>();
            PlayerColider.enabled = false;
        }
    }
}
