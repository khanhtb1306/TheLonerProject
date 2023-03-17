using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSave : Singleton<GameSave>
{
    public bool isIntro;
    // Start is called before the first frame update
    void Start()
    {
        isIntro = true;
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("SampleSence");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
