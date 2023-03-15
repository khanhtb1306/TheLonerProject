using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : Singleton<ButtonControl>
{
    public GameObject pauseMenuScreen;
    public GameObject gameOverScreen;
    public GameObject pauseButton;


    // Start is called before the first frame update


    public void HandlePlayButtonOnClickEvent()
    {
        StartCoroutine(WaitForStart());

    }

    IEnumerator WaitForStart()
    {

      

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 0;
       
        SoundController.instance.PlayGameStart();

       
        yield return new WaitForSecondsRealtime(SoundController.instance.GameStart.length);
        pauseButton.SetActive(true);

r
        Time.timeScale = 1;
    }
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
    public void ReplayLevel()
    {

        pauseMenuScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        HandlePlayButtonOnClickEvent();
       

    }
    public void HandlePauseButtonOnClickEvent()
    {
        pauseMenuScreen.SetActive(true);
        GameManager.instance.isGamePause = true;
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void HandleResumeButtonOnClickEvent()
    {
        
        if(GameManager.instance.showIntro == false)
        {
            Time.timeScale = 1;
        }
        GameManager.instance.isGamePause = false;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {

        pauseButton.SetActive(false);
        gameOverScreen.SetActive(false);
        pauseMenuScreen.SetActive(false);
        SceneManager.LoadScene("MenuScenes");

    }
    // Update is called once per frame
    void Update()
    {

    }
}
