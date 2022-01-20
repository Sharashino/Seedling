using Seedling.SO;
using System;
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


        }
    }
}
