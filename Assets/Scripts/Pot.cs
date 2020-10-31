using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pot : MonoBehaviour
{
    public bool isOccupied = false;

    [SerializeField]
    private Material blinking1;
    [SerializeField]
    private Material blinking2;


    public void PlantASeedling(GameObject seedlingToPlant)
    {
        Seedling seedling = seedlingToPlant.GetComponent<Seedling>();
        Transform seedlingTransform = seedlingToPlant.GetComponent<Transform>();
        Transform potTransform = GetComponent<Transform>();

        //Moving seedle to the centre of the pot
        Vector3 position = seedlingTransform.position;
        position.x = potTransform.position.x;
        position.y = potTransform.position.y + 0.22f;
        position.z = potTransform.position.z;
        seedlingTransform.position = position;

        isOccupied = true;
    }
}
