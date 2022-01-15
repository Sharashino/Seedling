using UnityEngine;
using Seedling.SO;
using Seedling.Managers;
using System;

namespace Seedling.Grounds
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private ParticleSystem plantParticles;
        [SerializeField] private GameObject grownPlant;
        [SerializeField] private GameObject potGround;
        [SerializeField] private Seed currentSeed;
        [SerializeField] private Transform seedSpawnPos;
        private int growthTick;
        public bool HasSeedling => currentSeed != null;

        private void OnMouseDown()
        {
            if(SeedManager.Instance.HasCurrentSeed)
            {
                PlantSeed(SeedManager.Instance.CurrentSeed);
            }
        }


        public void PlantSeed(Seed seed)
        {
            //if ground has no seedling plant a new one
            //but if it has, replace them
            if (!HasSeedling)
            {
                GameTimeManager.OnTick_1 += GrowSeed;
                
                currentSeed = seed;
                var newSeed = Instantiate(seed.seedObject);
                newSeed.transform.position = seedSpawnPos.position;


                //Getting Seedling and Pot Transforms
                /*Transform seedlingTransform = currentSeed.GetComponent<Transform>();
                Transform potTransform = potGround.GetComponent<Transform>();

                Vector3 seedlingPosition = GetPotGroundPosition(seedlingTransform, potTransform);

                seedlingTransform.position = seedlingPosition;
                seedlingTransform.parent = potGround.transform;*/
            }
            else
            {
               /* Destroy(currentSeed);
                currentSeed = Instantiate(seed.seedObject);
                currentSeed.name = seed.name;

                //Getting Seedling and Pot Transforms
                Transform seedlingTransform = currentSeed.GetComponent<Transform>();
                Transform potTransform = potGround.GetComponent<Transform>();

                //Moving seedling to the centre of the pot
                Vector3 seedlingPosition = GetPotGroundPosition(seedlingTransform, potTransform);

                seedlingTransform.position = seedlingPosition;
                seedlingTransform.parent = potGround.transform;*/
            }
        }

        private void GrowSeed(GameTimeManager.OnTickEventArgs obj)
        {
            growthTick++;

            if(growthTick >= currentSeed.growTime)
            {
                DoneGrowing();
            }
        }

        private void DoneGrowing()
        {
            GameTimeManager.OnTick_1 -= GrowSeed;


        }

        public Vector3 GetPotGroundPosition(Transform seedlingTransform, Transform potTransform)
        {
            //Moving seedling to the centre of the pot
            Vector3 position = seedlingTransform.position;
            position.x = potTransform.position.x;
            position.y = potTransform.position.y + 0.13f;

            return position;
        }

        public void RemoveSeedling()
        {
            Destroy(currentSeed);
        }
    }
}