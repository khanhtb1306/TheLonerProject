using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Buff> buffPrefab;
    Vector3 endPoint;
    // Start is called before the first frame update
    public void BuffSpawn(Transform tf)
    {
       
        int a = Random.Range(0, 10);
        Debug.Log(a);
        if(a <= 2) {
            Instantiate(buffPrefab[Random.Range(0, 2)],tf);
        }else if ( a <= 3)
        {
            Instantiate(buffPrefab[Random.Range(3, 5)],tf);
        }
    }
    void Start()
    {
        InvokeRepeating("BuffSpawn", 0f, 3f);
       
    }
    void Update()
    {
        
    }

    
}
