//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class ClickToPlace : MonoBehaviour
//{
//    public Player player;
//    public Camera playerCamera;
//    public Seedling carriedSeedling;
//    public bool isCarryingSeedling;
//    public bool isCarryingWaterCan;
//    public bool isCarryingGround;
//    public bool isFocused;

//    [SerializeField]
//    private List<GameObject> inventory = new List<GameObject>();

//    void Start()
//    {
//        player = GetComponent<Player>();
//        playerCamera = Camera.main;
//    }

//    public void LeftClicked()
//    {

//        Getting mouse position from main camera
//        Ray mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
//        RaycastHit mouseHit = new RaycastHit();

//        If hit(always lol)
//        if (Physics.Raycast(mouseRay, out mouseHit))
//        {
//            GameObject clickedObject = mouseHit.collider.gameObject;

//            If player has empty hands and can carry a Seedling
//            if (clickedObject.tag == "Seedling" && !isCarryingSeedling)
//            {
//                GameObject SeedlingObject = mouseHit.collider.gameObject;
//                Seedling Seedling = SeedlingObject.GetComponent<Seedling>();
//                If player wants to move a seedling that is arleady planted
//                if (!Seedling.isPlanted)
//                {
//                    Player picks up seedling
//                    inventory.Add(SeedlingObject);
//                    Seedling.IGotPickedUp();
//                    isCarryingSeedling = true;
//                    carriedSeedling = Seedling;

//                    Debug.Log("Picked up: " + SeedlingObject.name);
//                }
//                If player clicks on a seedling with water can
//                else if (Seedling.isPlanted && isCarryingWaterCan)
//                {
//                    Player waters down seedling
//                    Seedling.IGotWateredDown();
//                    Debug.Log("You watered down: " + SeedlingObject.gameObject.name);
//                }
//                else
//                {
//                    Player tries to move planted seedling
//                    Debug.Log("This seedling has been arleady planted");
//                }
//            }
//            If player click on a Ground in Pot and carries a Seedling
//            else if (clickedObject.tag == "Ground" && isCarryingSeedling)
//            {
//                Getting Ground object player clicked on
//                GameObject GroundObject = mouseHit.collider.GetComponentInParent<Ground>().gameObject;

//                If Ground is in Pot
//                Ground Ground = mouseHit.collider.GetComponentInParent<Ground>();
//                if (Ground.isInPot)
//                {
//                    If Pot isn't occupied and has Ground
//                    GameObject PotObject = GroundObject.GetComponentInParent<Pot>().gameObject;
//                    Pot Pot = PotObject.GetComponent<Pot>();
//                    if (!Pot.isOccupied && Pot.hasGround)
//                    {
//                        If player wants to plant a seedling in pot with ground
//                        Passing Ground to the seedling
//                        carriedSeedling.GetComponent<Seedling>().IGotPlanted(GroundObject);
//                        Planting a seedling in pot
//                        Pot.PlantASeedling(carriedSeedling.gameObject);

//                        Debug.Log("Planting " + carriedSeedling.gameObject.name);
//                        carriedSeedling = null;
//                        isCarryingSeedling = false;
//                    }
//                }
//                else if (Ground.isInPot == false)
//                {
//                    Debug.Log("You can't plant a seedling just in ground! What a mess!");
//                }
//                else
//                {
//                    Debug.Log("This pot arleady has seedling in it!");
//                }
//            }
//            If player click on Pot and carries Ground
//            else if (clickedObject.tag == "Pot" && isCarryingGround)
//            {
//                GameObject Pot = mouseHit.collider.gameObject;

//                Debug.Log("Placed ground into the pot");
//                Pot.GetComponent<Pot>().PlaceGround(inventory.ElementAt(0));
//                inventory.ElementAt(0).GetComponent<Ground>().IGotPlacedInPot();
//            }
//            If player clicked on Pot with no Ground and carries a Seedling
//            else if (clickedObject.tag == "Pot" && isCarryingSeedling)
//            {
//                Debug.Log("This Pot requires Ground to plant a Seedling");
//            }
//            else if (clickedObject.tag == "WaterCan")
//            {
//                isCarryingWaterCan = true;
//                Debug.Log("Picked up: " + clickedObject.name);
//            }
//            else if (clickedObject.tag == "Flower")
//            {
//                GameObject Flower = mouseHit.collider.gameObject;
//                Flower.GetComponent<Flower>().HarvestFlower(Flower);
//            }
//            else if (clickedObject.tag == "Ground")
//            {
//                isCarryingGround = true;
//                GameObject Ground = clickedObject.gameObject;
//                Ground.GetComponent<Ground>().IGotPickedUp();
//                inventory.Add(Ground);
//                Debug.Log("Picked up ground!");
//            }
//            If player arleady carries a seedling
//            else if (isCarryingSeedling)
//            {
//                Debug.Log("You're arleady carrying a seedling!");
//            }
//            If player clicks elswere to defocus
//            else
//            {
//                Defocus();
//            }
//        }
//    }
//    public void RightClicked()
//    {
//        Defocus();
//    }
//    private void Defocus()
//    {
//        isFocused = false;
//    }

//}
