using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; // Prefab of the car to spawn
    public GameObject checkpointGeneratorPrefab; // Prefab of the checkpoint generator
    public GameObject Parent;
    private static int carNumber = 0; // Number to assign to the spawned car
    private static int generatorNumber = 0; // Number to assign to the spawned generator
    private bool spawnToLeft = true; // Flag to determine whether to spawn on the left or right side
    public static Vector3[] vectorSpawns = new Vector3[]
        {
            new Vector3(2.04155731f, -0.0971069336f, 66.6227722f),
            new Vector3(-40.1632538f, -0.0971069336f, 66.8717957f),
            new Vector3(-43.4529419f, -0.0971069336f, 29.6044922f),
            new Vector3(-21.4740753f, -0.0971069336f, -12.7940063f),
            new Vector3(17.1300049f, -0.0971069336f, -12.7940063f),
            new Vector3(45.0300026f, -0.0971069336f, 2.60998535f),
            new Vector3(44.7600021f, -0.0971069336f, 26.9199829f)
        };
    public static Vector3[] rotationArray = new Vector3[]
        {
            new Vector3(0f, 180f, 0f),
            new Vector3(0f, 225f, 0f),
            new Vector3(0f, 90f, 0f),
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, -90f, 0f),
            new Vector3(0f, -90f, 0f)
        };

    public void SpawnCarAndGenerator()
    {
        int spawnerID = Random.Range(0, vectorSpawns.Length);
        int rotationID = spawnerID;
        int destinationID = Random.Range(0, vectorSpawns.Length);
        while(spawnerID == destinationID)
        {
            destinationID = Random.Range(0, vectorSpawns.Length);
        }
        Debug.Log("Before: " + rotationArray[rotationID]);

        Vector3 spawnPosition = Parent.transform.position + vectorSpawns[spawnerID];
        Quaternion spawnRotationQ = Quaternion.Euler(rotationArray[rotationID].x, rotationArray[rotationID].y, rotationArray[rotationID].z);
        
        Debug.Log("After: " + spawnRotationQ.eulerAngles);

      
        GameObject car = Instantiate(carPrefab, spawnPosition, spawnRotationQ);
      
        car.name = "Car_" + carNumber;
        
        carNumber++;

       
        GameObject generator = Instantiate(checkpointGeneratorPrefab, spawnPosition+Vector3.one*2,spawnRotationQ);
        generator.GetComponent<CheckpointGenerator>().SetSpawnerID(spawnerID);
      
        generator.name = "Generator_" + generatorNumber;
        generatorNumber++;

        spawnToLeft = !spawnToLeft;
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCarAndGenerator();
        }
    }
    
}
