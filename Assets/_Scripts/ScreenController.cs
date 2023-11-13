using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScreenController : MonoBehaviour
{
    public  Canvas startCanvas;
    public  GameObject player; 
    public  GameData gameData;
    public TMP_InputField nameInputField;
    public GameObject recordText;

    void Start()
    {
        if (!gameData.isGameContinue)
        {
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
        if(gameData.hasBeatenRecord)
        {
            gameData.hasBeatenRecord = false;
            recordText.SetActive(true);
        }
    }


    void HideStartCanvas()
    {
        startCanvas.enabled = false;
        if (gameData.hasBeatenRecord)
            recordText.SetActive(false);
    }

    public void StartGame()
    {

        HideStartCanvas();

        player.gameObject.SetActive(true); 
    }

    public void ExitGame()
    {
        gameData.isGameContinue = false;
        Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void SavePlayerName()
    {
        if (nameInputField != null)
        {
            gameData.currentPlayerName = nameInputField.text;
        }
        else
        {
            Debug.LogError("InputField не был назначен!");
        }
    }

}
