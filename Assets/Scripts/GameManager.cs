using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Player player;
    
    [SerializeField]
    GameObject seedlingSelector;

    [SerializeField]
    TMP_Text seedlingTime;

    public Seed plantedSeed;

    private void Start()
    {
        player.LoadPlayer();
    }
}
