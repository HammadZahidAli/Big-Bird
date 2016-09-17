using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
   
    void Start()
    {
        //SpawnObject = SpawnObjects[Random.Range(0, SpawnObjects.Length)];
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
            float y = Random.Range(0f, 2f);
            GameObject go = Instantiate(SpawnObject, this.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;
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
