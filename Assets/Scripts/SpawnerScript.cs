using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
   
    void Start()
    {
        SpawnObject = SpawnObjects[Random.Range(0, SpawnObjects.Length)];
        Spawn();
    }
    public float p;
    void Spawn()
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            //random y position
            SpawnObject = SpawnObjects[Random.Range(0, SpawnObjects.Length)];
            float y = Random.Range(-0.5f, 1f);
                GameObject go = Instantiate(SpawnObject, this.transform.position + new Vector3(0, y, 0), Quaternion.identity) as GameObject;

        }
        if(p==0)
            Invoke("Spawn", Random.Range(timeMin, timeMax));
        else
            Invoke("Spawn", p);
    }

    private GameObject SpawnObject;
    public GameObject[] SpawnObjects;

    public float timeMin = 0.7f;
    public float timeMax = 2f;
}
