using UnityEngine;
using Seedling.SO;
using Seedling.Enums;
using Seedling.Grounds;
using Seedling.Managers;

namespace Seedling.Seeds
{
    public class Flower : MonoBehaviour
    {
        [SerializeField] private FlowerType flowerType;
        [SerializeField] private string flowerName;
        [SerializeField] private GameObject flowerObject;
        [SerializeField] private SeedSO flowerSeed;

        public SeedSO FlowerSeed { get => flowerSeed; set => flowerSeed = value; }

        public void OnMouseDown()
        {
            HarvestFlower();
        }

        public void GrowFlower(Flower flower, Vector3 position)
        {
            Instantiate(flower, position, Quaternion.identity, transform.parent);
        }

        public void HarvestFlower()
        {
            SeedManager.onFlowerHarvest?.Invoke();
            Destroy(gameObject);
        }
    }
}
