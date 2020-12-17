using System;
using UnityEngine;

public class SeedlingManager : MonoBehaviour
{
    [SerializeField] private Seed currentSeedling;
    [SerializeField] private Ground seedlingGround;
    [SerializeField] private NotificationDisplayer notificationDisplayer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit mouseHit;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(mouseRay, out mouseHit, 100))
            {
                GameObject flowerToHarvest = mouseHit.transform.gameObject;

                if (flowerToHarvest.tag == "Flower")
                {
                    HarvestFlower(flowerToHarvest);
                }
            }
        }
    }

    public void GrowFlower(Seed seedlingToGrow)
    {
        currentSeedling.itemObject.GetComponent<Seedling>().GrowFlower(currentSeedling.itemObject, seedlingGround.gameObject);
        notificationDisplayer.GrowSeedling(seedlingToGrow);
    }

    public void HarvestFlower(GameObject flowerToHarvest)
    {
        flowerToHarvest.GetComponent<Flower>().HarvestFlower(flowerToHarvest);
        notificationDisplayer.HarvestFlower(flowerToHarvest.GetComponent<Flower>());

        SetCurrentSeedling(null);
    }

    public Seed GetCurrentSeedling()
    {
        return currentSeedling;
    }

    public Seed SetCurrentSeedling(Seed seedlingToAssing)
    {
        return currentSeedling = seedlingToAssing;
    }
}
