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
        [SerializeField] private SeedSO flowerSeedling;

        public void OnMouseDown()
        {
            HarvestFlower();
        }

        public void HarvestFlower()
        {
            SeedManager.onFlowerHarvest?.Invoke();
            Destroy(gameObject);
        }

        public string FlowerName
        {
            get
            {
                return flowerName;
            }
        }

        public FlowerType FlowerType
        {
            get
            {
                return flowerType;
            }
        }

        public SeedSO FlowerSeedling
        {
            get
            {
                return flowerSeedling;
            }
        }
    }
}
