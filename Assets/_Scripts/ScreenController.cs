using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public  Canvas startCanvas;
    public  GameObject player; 
    public  GameData gameData;

    public GameObject PanelPause;

    void Start()
    {
        if (!gameData.isGameContinue)
        {
            // Показать начальную канву
            ShowStartCanvas();
        }
        else
        {   
            startCanvas.enabled = false;
            player.gameObject.SetActive(true);
        }
        

    }

    void ShowStartCanvas()
    {
        Debug.Log("eblan?");
        startCanvas.enabled = true;
    }


    void HideStartCanvas()
    {
        startCanvas.enabled = false;
    }

    public void StartGame()
    {
        // Скрыть начальную канву
        HideStartCanvas();

        // Здесь вы можете запустить логику начала игры
        player.gameObject.SetActive(true); // Вызовите метод в вашем скрипте Player, который начинает игру.
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        PanelPause.SetActive(false);
    }


    public void NewGame()
    {
        Time.timeScale = 1;
        PanelPause.SetActive(false);
        gameData.Reset();
        SceneManager.LoadScene("MainScene");
    }
}
