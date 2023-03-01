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
        endPoint = Gennerate();
        
    }

    public Vector3 Gennerate()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        // save screen edges in world coordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        float screenLeft = lowerLeftCornerWorld.x;
        float screenRight = upperRightCornerWorld.x;
        float screenTop = upperRightCornerWorld.y;
        float screenBottom = lowerLeftCornerWorld.y;
        return new Vector3(Random.Range(screenLeft, screenRight), Random.Range(screenBottom, screenTop), -Camera.main.transform.position.z);
    }
}
