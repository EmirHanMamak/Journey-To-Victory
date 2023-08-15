using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject fader, countdown3, countdown2, countdown1, countdowngo;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Animation[] coutDownAnim;
    private void Start()
    {
        StartCoroutine(CountSequence());
    }
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.5f);
        countdown3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countdown2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countdown1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countdowngo.SetActive(true);
        GameConditions.gameStarted = true;
        countdowngo.SetActive(false);
        countdown1.SetActive(false);
        countdown2.SetActive(false);
        countdown3.SetActive(false);

    }
    public void LoadScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        if(levelIndex == 0)
        {
        GameConditions.gameEnded = true;
        }
    }
    public void PauseButton()
    {
        if (GameConditions.gameStarted == false) return;
        Time.timeScale = 0f;
        GameConditions.gameStarted = false;
        PauseMenu(true);

    }
    public void ContinueButton()
    {
        StartCoroutine(CountSequence());
        Time.timeScale = 1f;
        PauseMenu(false);
    }
    private void PauseMenu(bool isOpened)
    {
        pauseMenu.SetActive(isOpened);
    }
}