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
    public Transform background;

    void Start()
    {
        if (gameData.hasBeatenRecord)
        {
            gameData.hasBeatenRecord = false;
            recordText.SetActive(true);
        }

        background.GetComponent<SpriteRenderer>().sprite = Resources.Load(Random.Range(1, 31).ToString("d2"), typeof(Sprite)) as Sprite;
        SetBackgroundScale();
        SetMusic();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameData.music = !gameData.music;
            SetMusic();
        }
    }

    public void StartGame()
    {
        SavePlayerName();
        SceneManager.LoadScene("MainScene");
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


    private void OnApplicationQuit()
    {
        gameData.hasBeatenRecord = false;
    }

    void SetBackgroundScale()
    {
        float scale = Camera.main.orthographicSize * Camera.main.aspect > Camera.main.orthographicSize ?
            Camera.main.orthographicSize * Camera.main.aspect / 6.6f :
            Camera.main.orthographicSize / 5;
        background.localScale = new Vector3(scale * background.localScale.x, scale * background.localScale.y, 1);
    }

    void SetMusic()
    {
        if (gameData.music)
            Camera.main.gameObject.GetComponent<AudioSource>().Play();
        else
            Camera.main.gameObject.GetComponent<AudioSource>().Stop();
    }
}
