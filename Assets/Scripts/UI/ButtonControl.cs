using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : Singleton<ButtonControl>
{
    public GameObject pauseMenuScreen;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void HandlePlayButtonOnClickEvent()
    {
        StartCoroutine(WaitForStart());

    }

    IEnumerator WaitForStart()
    {

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 0;
        SoundController.instance.PlayGameStart();
        Debug.Log("123");

        yield return new WaitForSecondsRealtime(3);
        Debug.Log("abc");
        Time.timeScale = 1;

    }
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
    public void ReplayLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void HandlePauseButtonOnClickEvent()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScenes");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
