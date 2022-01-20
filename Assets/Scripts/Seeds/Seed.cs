using Seedling.Managers;
using Seedling.SO;
using UnityEngine;

namespace Seedling.Seeds
{
    public class Seed : MonoBehaviour
    {
        [SerializeField] private SeedSO seed;
        public SeedSO SeedData => seed;

        public void GrowFlower()
        {
            seed.flowerObject.GrowFlower(seed.flowerObject, new Vector3(0, 0.25f, 0));

            SeedManager.Instance.DoneGrowing();
            DestroySeed();
        }

        public void DestroySeed()
        {
            Destroy(gameObject);
        }
    }
}
