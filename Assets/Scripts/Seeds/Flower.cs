using UnityEngine;
using Seedling.SO;
using Seedling.Enums;
using Seedling.Grounds;

namespace Seedling.Seeds
{
    public class Flower : MonoBehaviour
    {
        [SerializeField] private FlowerType flowerType;
        [SerializeField] private string flowerName;
        [SerializeField] private GameObject flowerObject;
        [SerializeField] private Seed flowerSeedling;

        public void HarvestFlower(GameObject flowerToHarvest)
        {
            flowerToHarvest.GetComponentInParent<Ground>().RemoveSeedling();
            Destroy(flowerToHarvest);
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

        public Seed FlowerSeedling
        {
            get
            {
                return flowerSeedling;
            }
        }
    }
}
