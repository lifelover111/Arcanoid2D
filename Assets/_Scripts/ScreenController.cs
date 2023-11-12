using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenController : MonoBehaviour
{
    public Canvas startCanvas;
    public GameObject player; // Перетащите ваш объект Player сюда в инспекторе.
    public GameData gameData;

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
        Debug.Log("gg");
        // Логика выхода из приложения
        Application.Quit(); // ВНИМАНИЕ: Это может не работать во всех случаях
    }
}
