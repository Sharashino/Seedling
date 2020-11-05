using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Pot : MonoBehaviour
{
    public GameObject potGround;
    public bool isOccupied = false;
    public bool hasGround = false;

    public void PlaceGround()
    {
        //Getting Ground and Pot Transforms
        potGround = Instantiate(potGround);
        Transform groundTransform = potGround.GetComponent<Transform>();
        Transform potTransform = GetComponent<Transform>();
        
        //Moving ground to the centre of the pot
        Vector3 position = groundTransform.position;
        position.x = potTransform.position.x;
        position.y = potTransform.position.y + 0.05f;
        position.z = potTransform.position.z;
        groundTransform.position = position;

        //Setting Ground Pot as parent
        potGround.transform.parent = gameObject.transform;

        //Filling Pot with Ground
        hasGround = true;
    }
}
