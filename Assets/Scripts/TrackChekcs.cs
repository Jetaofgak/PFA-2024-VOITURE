// INUTILISABLE

/*using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackChekcs : MonoBehaviour
{
    Transform parent;
    
    List<Transform> checkTransforms = new List<Transform>();
    public PrometeoCarController oneCar;
    private void Start()
    {
        parent = transform;
    }
    public void getCar(PrometeoCarController c)
    {
        oneCar = c;
    }
    public void RecordCheckpoints()
    {


        for (int i = 0; i < parent.childCount; i++)
        {
            checkTransforms.Add(parent.GetChild(i));
        }
        foreach (Transform t in checkTransforms)
        {
            CheckpointOne checkSingle = t.GetComponent<CheckpointOne>();
            checkSingle.SetTrackCheckpoints(this);


        }



    }
    public void CarThroughCheckpoint(CheckpointOne one,PrometeoCarController car)
    {
        Debug.Log(oneCar == car);
            if(oneCar==car)
            {
            
                Debug.Log("Nice Check");
                oneCar.CheckTouchedGood();
            
                Destroy(one.gameObject);
                checkTransforms.Remove(one.transform);
                if(checkTransforms.Count == 0)
                {
                    
                }
            }
             
    }
    
}
*/