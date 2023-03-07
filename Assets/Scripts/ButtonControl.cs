using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
