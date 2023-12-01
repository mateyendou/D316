using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
    public void quit()
    {
        Application.Quit();
    }
}
