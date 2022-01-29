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

            TimeManager.Instance.ShowTimerButtons();
            NotificationManager.Instance.DisplayNotification($"Pick a seed to grow first!");
        }

        public void PlantSeed(SeedSO seed)
        {
            if (HasSeedling) currentSeed.DestroySeed();
            NotificationManager.Instance.DisplayNotification($"You planted {seed.seedName}!");

            currentSeed = Instantiate(seed.seedObject, seedSpawnPos.position, Quaternion.identity, seedHolder);
            plantParticles.Play();

            growthTick = 0; 
            TimeManager.OnTick_1 += GrowSeed;
        }

        private void GrowSeed(TimeManager.OnTickEventArgs obj)
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
            TimeManager.OnTick_1 -= GrowSeed;
            SaveManager.Instance.SaveSeedData(currentSeed, growTime);

            currentSeed.GrowFlower();
            NotificationManager.Instance.DisplayNotification($"Your {currentSeed.SeedData.seedName} is done growing!");
        }
    }
}