using UnityEngine;

public class Seedling : MonoBehaviour
{
    [SerializeField] private string seedlingName;
    [SerializeField] private GameObject seedlingObject;
    [SerializeField] private GameObject seedlingFlower;
    private GameObject growFlower;

    public void GrowFlower(GameObject seedlingToGrowFrom, GameObject plantedOnGround)
    {
        growFlower = Instantiate(seedlingFlower, new Vector3(seedlingToGrowFrom.transform.position.x, seedlingToGrowFrom.transform.position.y + 0.20f, seedlingToGrowFrom.transform.position.z), seedlingToGrowFrom.transform.rotation);
        growFlower.name = seedlingFlower.name;

        //Setting up Ground as Flower parent
        growFlower.transform.parent = plantedOnGround.transform;
    }
}
