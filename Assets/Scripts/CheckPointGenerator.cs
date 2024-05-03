using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Sensors;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CheckpointGenerator : MonoBehaviour
{
    public GameObject checkpointPrefab; // Prefab of the checkpoint
    public GameObject emptyPrefab;
    public GameObject carPrefab;
    public GameObject parent;
    GameObject carTOManipualte;

    public NavMeshAgent agent;
    public float instantiationInterval = 0.01f;
    public float stopDistanceThreshold = 0.1f;
    Vector3 originalPos;
    Quaternion originalRot;
    int idDest;
    private bool reachedDestination = false;
    static int counter = 1;
    List<string> tag = new List<string>();
    void AddTag(string tagName)
    {
        // Add a new tag to the TagManager
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");
        tagsProp.InsertArrayElementAtIndex(tagsProp.arraySize);
        SerializedProperty newTag = tagsProp.GetArrayElementAtIndex(tagsProp.arraySize - 1);
        newTag.stringValue = tagName;
        tagManager.ApplyModifiedProperties();
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        parent = Instantiate(emptyPrefab);
        parent.name = "Trck " + counter;
        tag.Add("Numbe: "+counter);
        
        // Check if the tag already exists

        AddTag(tag[0]);
        
        parent.tag = tag[0];
        StartCoroutine(InstantiateObjects());
        counter++;

        
    }

    private IEnumerator InstantiateObjects()
    {
        yield return new WaitForSeconds(1f);
        int counter = 0;
        while (!reachedDestination)
        {
            
            GameObject c = Instantiate(checkpointPrefab, transform.position, transform.rotation);
            c.transform.SetParent(parent.transform);
            c.name = "checkpoint: "+counter;
            c.tag = parent.tag;
            
            counter++;  
            yield return new WaitForSeconds(instantiationInterval);
        }
    }

    public void MoveToNextSpawn(Vector3 DestPosition)
    {

        agent.SetDestination(DestPosition);

        
    }

    public void GetAngle(Quaternion angle)
    {
        originalRot = angle;
    }
    public void GetOrgPos(Vector3 org)
    {
        originalPos = org;
    }

    private void Update()
    {
        // Check if the agent has reached its destination
        if (!reachedDestination && agent.remainingDistance <= stopDistanceThreshold)
        {
            reachedDestination = true;
            StopCoroutine(InstantiateObjects());
            
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        parent.GetComponent<TrackChekcs>().RecordCheckpoints();
        carTOManipualte = Instantiate(carPrefab, originalPos, originalRot);
        carTOManipualte.GetComponent<PrometeoCarController>().ChangeTag(tag);
        parent.GetComponent<TrackChekcs>().getCar(carTOManipualte.GetComponent<PrometeoCarController>());
        carTOManipualte.GetComponent<PrometeoCarController>().SetTracker(parent.GetComponent<TrackChekcs>());


    }
}
