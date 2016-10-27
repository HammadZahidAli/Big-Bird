using UnityEngine;
using System.Collections;

using Keyur.Components.ObjectPooling;

public class HouseSpawner : MonoBehaviour {

    ObjectPoolerSimple objectPool;
    void Start()
    {

        objectPool = GetComponent<ObjectPoolerSimple>();
        Spawn();
    }
    public float p;
    public void Spawn()
    {
       if (GameStateManager.GameState == GameState.Playing)
        {
            //Debug.Log("new");
            //random y position
            // float y = Random.Range(-0.5f, 1f);
            //SpawnObject = SpawnObjects[0];
            // GameObject go = Instantiate(SpawnObject, this.transform.position, Quaternion.identity) as GameObject;
            GameObject go = objectPool.GetPooledObject();
            go.transform.position = transform.position;
            go.SetActive(true);
        }


         Invoke("Spawn", p);
    }

    private GameObject SpawnObject;
    public GameObject[] SpawnObjects;

    public float timeMin = 0.7f;
    public float timeMax = 2f;
}
