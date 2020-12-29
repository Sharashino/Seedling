using UnityEngine;

public class Ground : MonoBehaviour
{
    public ParticleSystem plantParticles;
    public GameObject grownPlant;
    public GameObject potGround;
    public bool hasSeedling = false;
    GameObject newSeedling;
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
            
            Vector3 seedlingPosition = GetPotGroundPosition(seedlingTransform, potTransform);

            seedlingTransform.position = seedlingPosition;
            seedlingTransform.parent = potGround.transform;

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
            Vector3 seedlingPosition = GetPotGroundPosition(seedlingTransform, potTransform);
            
            seedlingTransform.position = seedlingPosition;
            seedlingTransform.parent = potGround.transform;

        }
    }

    public void RemoveSeedling()
    {
        Destroy(newSeedling);
    }

    public Vector3 GetPotGroundPosition(Transform seedlingTransform, Transform potTransform)
    {
        //Moving seedling to the centre of the pot
        Vector3 position = seedlingTransform.position;
        position.x = potTransform.position.x;
        position.y = potTransform.position.y + 0.13f;
        position.z = potTransform.position.z;


        return position;
    }
}
