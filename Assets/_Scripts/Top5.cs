using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Top5 : MonoBehaviour
{

    public TextMeshProUGUI top5Text;
    public GameData gameData;

    void Start()
    {
        UpdateTop5Text();
    }


    void UpdateTop5Text()
    {
        if (top5Text != null && gameData != null)
        {
            top5Text.text = "Top 5:\n";
            if (gameData.top5Scores == null || gameData.top5Scores?.Length == 0)
                return;
            var sortedTop5 = gameData.top5Scores.OrderByDescending(score => score.playerScore).ToArray();

            for (int i = 0; i < Mathf.Min(sortedTop5.Length, 5); i++)
            {
                top5Text.text += $"{i + 1}. {sortedTop5[i].playerName} - {sortedTop5[i].playerScore} pts\n";
            }
        }
    }
}
