using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenController : MonoBehaviour
{
    public Canvas startCanvas;
    public GameObject player; // ���������� ��� ������ Player ���� � ����������.
    public GameData gameData;

    void Start()
    {
        if (!gameData.isGameContinue)
        {
            // �������� ��������� �����
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
        // ������ ��������� �����
        HideStartCanvas();

        // ����� �� ������ ��������� ������ ������ ����
        player.gameObject.SetActive(true); // �������� ����� � ����� ������� Player, ������� �������� ����.
    }

    public void ExitGame()
    {
        Debug.Log("gg");
        // ������ ������ �� ����������
        Application.Quit(); // ��������: ��� ����� �� �������� �� ���� �������
    }
}
