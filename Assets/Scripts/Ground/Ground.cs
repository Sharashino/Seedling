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
        [SerializeField] private GameObject potGround;
        [SerializeField] private Transform seedSpawnPos;
        [SerializeField] private Transform seedHolder;
        private int growthTick = 0;
        
        public bool HasSeedling => currentSeed != null;

        private void OnMouseDown()
        {
            if(SeedManager.Instance.HasCurrentSeed)
            {
                PlantSeed(SeedManager.Instance.CurrentSeed);
                return;
            }

            NotificationManager.Instance.DisplayNotification($"Pick a seed to grow first!");
        }

        public void PlantSeed(SeedSO seed)
        {
            if (HasSeedling) currentSeed.DestroySeed();
            NotificationManager.Instance.DisplayNotification($"You planted {seed.seedName}!");

            currentSeed = Instantiate(seed.seedObject, seedHolder, seedSpawnPos);
            plantParticles.Play();

            growthTick = 0; 
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
            NotificationManager.Instance.DisplayNotification($"Your {currentSeed.SeedData.seedName} is done growing!");
        }
    }
}