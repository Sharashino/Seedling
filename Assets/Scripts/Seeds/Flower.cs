using UnityEngine;
using UnityEngine.EventSystems;

public class Flower : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string flowerName;
    [SerializeField] private GameObject flowerObject;

    public void HarvestFlower(GameObject flowerToHarvest)
    {
        flowerToHarvest.GetComponentInParent<Ground>().RemoveSeedling();
        Destroy(flowerToHarvest);
    }

    public string GetFlowerName()
    {
        return flowerName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
    }
}
