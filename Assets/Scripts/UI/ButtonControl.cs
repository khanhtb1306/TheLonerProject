using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : Singleton<ButtonControl>
{
    public bool isGameStart;
    public bool isGamePause;
    public bool isShowIntro;

    public GameObject startMenu;
    public GameObject pauseMenuScreen;
    public GameObject gameOverScreen;
    public GameObject pauseButton;


    // Start is called before the first frame update

    private void Awake()
    {
        isGameStart = false;
        isGamePause = true;
        isShowIntro = false;
        startMenu.SetActive(true);
        pauseMenuScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void Update()
    {
        if(isGamePause || isShowIntro)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
    public void StartGame()
    {
        StartCoroutine(ReadyToStartGame());
    }
    public IEnumerator ReadyToStartGame()
    {
        startMenu.SetActive(false);
        SoundController.instance.PlayGameStart();
        isGameStart = true;
        yield return new  WaitForSecondsRealtime(SoundController.instance.GameStart.length);
        pauseButton.SetActive(true);
        isGamePause = false;
    }
    public void PauseGame() {
        isGamePause = true;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        isGamePause = false;
        pauseMenuScreen.SetActive(false);
    }

    public void GameOver()
    {
        isGamePause = true;
        gameOverScreen.SetActive(true);
    }
}
