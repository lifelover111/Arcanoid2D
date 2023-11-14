using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameData gameData;

    public void ExitGame()
    {
        gameData.isGameContinue = false;
        gameData.Reset();
        Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        pauseCanvas.SetActive(false);
    }


    public void NewGame()
    {
        gameData.Reset();
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        gameData.Reset();
        SceneManager.LoadScene("MainMenu");
    }
}
