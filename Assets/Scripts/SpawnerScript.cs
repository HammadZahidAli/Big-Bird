using UnityEngine;
using System.Collections;
using Keyur.Components.ObjectPooling;


public class SpawnerScript : MonoBehaviour
{
    GameObject go;
    VersatileObjectPooler objectPool;


    void Start()
    {

        //objectPool = GetComponent<ObjectPoolerSimple>();
        objectPool = GetComponent<VersatileObjectPooler>();
        Spawn();
      
    }
    public float p;
    string nextHurdle= "PipeStraight";
    void Spawn()
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            //random y position
            float y = Random.Range(0f, 3.3f);
            //GameObject go = Instantiate(SpawnObject, this.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
            //go = objectPool.GetPooledObject();
            go = VersatileObjectPooler.instance.GetObjectForType(nextHurdle, true, new Vector3(transform.position.x, y, transform.position.z));
            go.SetActiveRecursively(true);
            go.transform.position = new Vector3( transform.position.x, y, transform.position.z);
            go.SetActive(true);

        }
 
        
        Invoke("Spawn", p);
        if (ScoreManagerScript.Score == 2)
        {
            nextHurdle = "PipeStraightDownMoving";
        }
        else if (ScoreManagerScript.Score == 4)
        {
            nextHurdle = "PipeStraightUpMoving";
        }
        else if (ScoreManagerScript.Score == 6)
        {
            nextHurdle = "PipeStraightMoving";
        }
        else if (ScoreManagerScript.Score == 8)
        {
            nextHurdle = "PipeStraightMovingBoth";
        }
        else if (ScoreManagerScript.Score > 12)
        {
            if (ScoreManagerScript.Score % 5 == 0)
                nextHurdle = "PipeStraightMoving";
            else if (ScoreManagerScript.Score % 10 == 0)
            {
                nextHurdle = "PipeStraightUpMoving";
            }
            else
            {
                nextHurdle = "PipeStraightMovingBoth";
            }

        }

    }

    private GameObject SpawnObject;
    public GameObject[] SpawnObjects;

    public float timeMin = 0.7f;
    public float timeMax = 2f;
    public static int hurdleIndex = 0;
}
