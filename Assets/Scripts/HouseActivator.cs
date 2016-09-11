using UnityEngine;
using System.Collections;

public class HouseActivator : MonoBehaviour {

    public GameObject[] Houses;


    void Start()
    {
       //pawnObject = SpawnObjects[Random.Range(0, Houses.Length)];
        Spawn();
    }
    public float p;
    public void Spawn()
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            //random y position
            // float y = Random.Range(-0.5f, 1f);
            int i = Random.Range(0, Houses.Length);
            GameObject go = Houses[i];
            go.SetActive(true);
            go.transform.position = this.transform.position;
            //GameObject go = Instantiate(SpawnObject, this.transform.position, Quaternion.identity) as GameObject;



        }
      //  if (p == 0)
           // Invoke("Spawn", Random.Range(timeMin, timeMax));
      //  else
            Invoke("Spawn", p);
    }

    private GameObject SpawnObject;
    public GameObject[] SpawnObjects;

    public float timeMin = 0.7f;
    public float timeMax = 2f;
}
