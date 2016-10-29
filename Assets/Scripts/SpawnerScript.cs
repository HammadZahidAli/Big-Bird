using UnityEngine;
using System.Collections;
using Keyur.Components.ObjectPooling;


public class SpawnerScript : MonoBehaviour
{
    GameObject go;
    ObjectPoolerSimple objectPool;
    void Start()
    {
      //  objectPool = GetComponent<ObjectPoolerSimple>();
        objectPool = GetComponent<ObjectPoolerSimple>();
        hurdleIndex = 0;
        SpawnObject = SpawnObjects[hurdleIndex];
        Spawn();
      
    }
    public float p;
    void Spawn()
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            //random y position
            float y = Random.Range(0f, 3.3f);
            //GameObject go = Instantiate(SpawnObject, this.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
            go = objectPool.GetPooledObject();
            go.SetActiveRecursively(true);
            go.transform.position = new Vector3( transform.position.x, y, transform.position.z);
            go.SetActive(true);

        }
 
        
        Invoke("Spawn", p);
        hurdleIndex++;
        hurdleIndex = hurdleIndex % SpawnObjects.Length;
        SpawnObject = SpawnObjects[hurdleIndex];
    }

    private GameObject SpawnObject;
    public GameObject[] SpawnObjects;

    public float timeMin = 0.7f;
    public float timeMax = 2f;
    public static int hurdleIndex = 0;
}
