using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //When picking up ground
    public void IGotPickedUp()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    //When placking ground in pot
    public void IGotPlacedInPot()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
