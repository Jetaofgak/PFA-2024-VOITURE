/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnrate;
    public GameObject checkpointGeneratorPrefab; // Prefab of the checkpoint generator
    public GameObject carPrefab;
    int spawnID;
    int destinationID;
    static int genCount = 0;
    public static Vector3[] vectorSpawns = new Vector3[]
    {
            new Vector3(2.04155731f, -0.0971069336f, 66.6227722f),
            new Vector3(-38.1632538f, -0.0971069336f, 66.8717957f),
            new Vector3(-39.4529419f, -0.0971069336f, 29.6044922f),
            new Vector3(-21.4740753f, -0.0971069336f, -12.7940063f),
            new Vector3(17.1300049f, -0.0971069336f, -12.7940063f),
            new Vector3(44.0300026f, -0.0971069336f, 2.60998535f),
            new Vector3(43.7600021f, -0.0971069336f, 26.9199829f)
    };
    public static Vector3[] rotationArray = new Vector3[]
        {
            new Vector3(0f, 180f, 0f),
            new Vector3(0f, 120f, 0f),
            new Vector3(0f, 90f, 0f),
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, -90f, 0f),
            new Vector3(0f, -90f, 0f)
        };


    public void SpawnGenerator()
    {
        spawnID = Random.Range(0,vectorSpawns.Length);
        destinationID = Random.Range(0,rotationArray.Length);
        while(spawnID == destinationID)
        {
            destinationID = Random.Range(0,rotationArray.Length);
        }

        

        Debug.Log("Spawn: " + vectorSpawns[spawnID] + "Dest: " + vectorSpawns[destinationID]);
        Quaternion rotationQ = Quaternion.Euler(rotationArray[spawnID].x, rotationArray[spawnID].y, rotationArray[spawnID].z);

        GameObject chkGen = Instantiate(checkpointGeneratorPrefab, transform.localPosition + vectorSpawns[spawnID], rotationQ);
        chkGen.name = "Gen_"+genCount;
       // chkGen.GetComponent<CheckpointGenerator>().SetTrueParent(this.gameObject);
        chkGen.GetComponent<CheckpointGenerator>().MoveToNextSpawn(transform.localPosition+vectorSpawns[destinationID]);
        chkGen.GetComponent<CheckpointGenerator>().GetAngle(rotationQ);
        chkGen.GetComponent<CheckpointGenerator>().GetOrgPos(transform.localPosition + vectorSpawns[spawnID]);
        genCount++; 





    }


    private void Start()
    {
        // Start the coroutine to spawn generator every 10 seconds
        StartCoroutine(SpawnGeneratorRepeatedly());
    }

    private IEnumerator SpawnGeneratorRepeatedly()
    {
       
        while (true)
        {
            // Wait for 10 seconds
            SpawnGenerator();
            yield return new WaitForSeconds(spawnrate);

            // Call the method to spawn generator
        }
    }

  

}
*/