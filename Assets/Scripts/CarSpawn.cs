using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject Car;
    public GameObject CheckGen;
    public Transform[] SpawnPoints = { };
    public static int id;
    public static int id2;
    Vector3 forward = Vector3.forward*2;
    Vector3 back = Vector3.back*2;
    Vector3 left = Vector3.left*2;
    Vector3 right = Vector3.right*2;
    bool leftBool = true;
   
    int counter = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            id = Random.Range(0, 7);
            
            id2 = Random.Range(0, 7);

            Debug.Log(SpawnPoints[id]);
            Vector3 carspawnpos = Vector3.zero;
            if (leftBool)
            {
                switch (SpawnPoints[id].localEulerAngles.y)
                {
                    case 90: carspawnpos = SpawnPoints[id].localPosition + back + right; break;
                    case (-91): carspawnpos = SpawnPoints[id].localPosition + forward +right; break;
                    case (-181): carspawnpos = SpawnPoints[id].localPosition + back + right;break;
                    case 0: carspawnpos = SpawnPoints[id].localPosition +right  + forward; break;
                }
                
                leftBool = !leftBool;
            }
            else
            {
                switch (SpawnPoints[id].localEulerAngles.y)
                {
                    case 90: carspawnpos = carspawnpos = SpawnPoints[id].localPosition + back + left; break;
                    case (-91): carspawnpos = SpawnPoints[id].localPosition + forward + left; break;
                    case (-181): carspawnpos = SpawnPoints[id].localPosition + back + left; break;
                    case 0: carspawnpos = SpawnPoints[id].localPosition + right + back; break;
                }
                
                leftBool = !leftBool;
            }
            Debug.Log("TU DOIS SPAWN AVEC L'ID:" + id);
            Debug.Log("Tu dois allez dans l'id:" + id2);
            int angle = 0;
            while (id == id2)
            {
                id2 = Random.Range(0, 7);
            }
        
            switch (id)
            {
            
                case 1: 
                case 2: angle = -90; break;
                case 3: angle = -180; break;
                case 4: 
                case 5: angle = -90; break;
                case 6: 
                case 0: angle = 0; break;


            }
            
            GameObject carSpawned=Instantiate(Car, carspawnpos, Quaternion.Euler(0,angle,0));
            carSpawned.name = "Car " + counter;
            

            
            

            
            GameObject checkgenSpawned = Instantiate(CheckGen,carspawnpos,Quaternion.Euler(0,angle,0));
            checkgenSpawned.name = "Spawned " + counter;
           
           
            counter++;

        }
        
    }
}
