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
            var newFlower = Instantiate(seed.flowerObject, transform.parent);
            newFlower.transform.position += new Vector3(0, 0.25f, 0);
            newFlower.FlowerSeed = seed;

            DestroySeed();
        }

        public void DestroySeed()
        {
            Destroy(gameObject);
        }
    }
}
