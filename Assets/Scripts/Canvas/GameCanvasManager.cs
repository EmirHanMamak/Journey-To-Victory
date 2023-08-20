using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] AudioSource goSound, readySound;
    [SerializeField] GameObject fader, countdown3, countdown2, countdown1, countdowngo;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    //[SerializeField] Animation[] coutDownAnim;
    private void Start()
    {
        StartCoroutine(CountSequence());
    }
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.5f);
        countdown3.SetActive(true);
        readySound.Play();
        yield return new WaitForSeconds(0.5f);

        countdown2.SetActive(true);
        readySound.Play();
        yield return new WaitForSeconds(0.5f);

        countdown1.SetActive(true);
        readySound.Play();
        yield return new WaitForSeconds(0.5f);

        countdowngo.SetActive(true);
        GameConditions.gameStarted = true;
        goSound.Play();

        countdowngo.SetActive(false);
        countdown1.SetActive(false);
        countdown2.SetActive(false);
        countdown3.SetActive(false);

    }
    public void LoadScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        if (levelIndex == 0)
        {
            GameConditions.gameEnded = true;
        }
    }
    private void PauseMenu(bool isOpened)
    {
        pauseMenu.SetActive(isOpened);
    }
    public void PauseButton()
    {
        //|| GameConditions.isPlayerCrushed only for dev
        if (GameConditions.gameStarted == false) return;
        GameConditions.gameStarted = false;
        PauseMenu(true);
        Debug.Log("chanfgexc");
        Time.timeScale = 0f;
    }
    public void ContinueButton()
    {
        StartCoroutine(CountSequence());
        Time.timeScale = 1f;
        PauseMenu(false);
    }
    public void ReturnMainMenuButton()
    {
        GameConditions.gameStarted = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void RestartGameButton()
    {
        CollectableControl.coinCount = 0;
        gameOverMenu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        //CollectableControl.scoreCount = 0;
        /*CollectableControl.coinCount = 0;
        CollectableControl.distanceCount = 0;
        GameConditions.gameStarted = false;
        GameConditions.gameStarted = false;
        Mover.moverCurrentZPos = 0f;*/
    }
}