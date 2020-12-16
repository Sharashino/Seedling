using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private ParticleSystem plantParticles;
    [SerializeField] private GameObject potGround;
    private bool hasSeedling = false;
    private GameObject newSeedling;
    public void PlantASeedling(Seed seedlingToPlant)
    {
        //if ground has no seedling plant a new one
        //but if it has, replace them
        if(!hasSeedling)
        {
            hasSeedling = true;
            newSeedling = Instantiate(seedlingToPlant.itemObject);
            newSeedling.name = seedlingToPlant.name;

            //Getting Seedling and Pot Transforms
            Transform seedlingTransform = newSeedling.GetComponent<Transform>();
            Transform potTransform = potGround.GetComponent<Transform>();

            //Moving seedling to the centre of the pot
            Vector3 position = seedlingTransform.position;
            position.x = potTransform.position.x;
            position.y = potTransform.position.y + 0.13f;
            position.z = potTransform.position.z;
            
            seedlingTransform.position = position;
            seedlingTransform.parent = potGround.transform;

            CreatePlantParticles();
        }
        else
        {
            Destroy(newSeedling);
            newSeedling = Instantiate(seedlingToPlant.itemObject);
            newSeedling.name = seedlingToPlant.name;

            //Getting Seedling and Pot Transforms
            Transform seedlingTransform = newSeedling.GetComponent<Transform>();
            Transform potTransform = potGround.GetComponent<Transform>();

            //Moving seedling to the centre of the pot
            Vector3 position = seedlingTransform.position;
            position.x = potTransform.position.x;
            position.y = potTransform.position.y + 0.13f;
            position.z = potTransform.position.z;
            
            seedlingTransform.position = position;
            seedlingTransform.parent = potGround.transform;

            CreatePlantParticles();
        }
    }

    private void CreatePlantParticles()
    {
        plantParticles.Play();
    }
}
