using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject plantedSeedling;
    [SerializeField]
    Player player;


    private void Start()
    {
        player.LoadPlayer();
    }
}
