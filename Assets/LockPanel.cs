using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LockPanel : MonoBehaviour
{
    Seeds seeds;
    [SerializeField]
    Player player;
    public bool isLocked;
    [SerializeField]
    GameObject buttonPanel;
    [SerializeField]
    GameObject lockPanel;
    [SerializeField]
    TMP_Text requiredCoins;

    private void Start()
    {
        seeds = buttonPanel.GetComponent<DefineSeedling>().seedling;
        requiredCoins.text = seeds.coinsToUnlock.ToString();
    }

    public void UnlockPanel()
    {
        if (player.playerCoins >= seeds.coinsToUnlock)
        {
            lockPanel.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You dont have enough coins");
        }
    }

    public void PanelLock()
    {
        if(isLocked)
        {
            lockPanel.gameObject.SetActive(true);
        }
        else
        {
            lockPanel.gameObject.SetActive(false);
        }
    }
}
