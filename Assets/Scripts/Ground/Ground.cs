using Seedling.Managers;
using Seedling.Seeds;
using UnityEngine;
using Seedling.SO;

namespace Seedling.Grounds
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private Seed currentSeed;
        [SerializeField] private ParticleSystem plantParticles;
        [SerializeField] private ParticleSystem growParticles;
        [SerializeField] private GameObject grownPlant;
        [SerializeField] private GameObject potGround;
        [SerializeField] private Transform seedSpawnPos;
        [SerializeField] private Transform seedHolder;
        private int growthTick = 0;
        public bool HasSeedling => currentSeed != null;

        private void Awake()
        {
            SeedManager.onFlowerHarvest += RemoveCurrentSeed;
        }

        private void OnMouseDown()
        {
            if(SeedManager.Instance.HasCurrentSeed)
            {
                PlantSeed(SeedManager.Instance.CurrentSeed);
            }
        }

        public void PlantSeed(SeedSO seed)
        {
            //if ground has no seedling plant a new one
            //but if it has, replace them
            if (HasSeedling) RemoveCurrentSeed();

            currentSeed = Instantiate(seed.seedObject, seedHolder);
            currentSeed.transform.position = seedSpawnPos.position;

            plantParticles.Play();

            growthTick = 0; // Resetting timer each seed plant;
            GameTimeManager.OnTick_1 += GrowSeed;
        }

        private void GrowSeed(GameTimeManager.OnTickEventArgs obj)
        {
            growthTick++;

            if (growthTick % 5 == 0) growParticles.Play();
            
            if(growthTick >= currentSeed.SeedData.growTime)
            {
                DoneGrowing(growthTick);
            }
        }

        private void DoneGrowing(int growTime)
        {
            GameTimeManager.OnTick_1 -= GrowSeed;


            SaveManager.Instance.SaveSeedData(currentSeed, growTime);

            currentSeed.GrowFlower();

            Debug.Log($"Your seed {currentSeed} is done growing!");
            RemoveCurrentSeed();
        }

        public void RemoveCurrentSeed()
        {
            Destroy(currentSeed);
        }
    }
}