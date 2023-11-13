using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    public int level = 1;
    public int balls = 6;
    public int points = 0;
    public int pointsToBall = 0;
    public bool resetOnStart;
    public bool isGameContinue = false;
    public bool music = true;
    public bool sound = true;
    public RedBlockModifyScript redBlockScript;
    public BonusProbabilities bonusProbabilities;
    public PlayerScoreData[] top5Scores = new PlayerScoreData[5];
    public string currentPlayerName;
    public bool hasBeatenRecord = false;

    public void UpdateTop5Scores()
    {
        if (PlayerHasNewHighScore())
        {

            PlayerScoreData newScore = new PlayerScoreData
            {
                playerName = currentPlayerName, 
                playerScore = points     
            };

            AddScoreToTop5(newScore);

            SortTop5Scores();
            hasBeatenRecord = true;
        }
    }

    private bool PlayerHasNewHighScore()
    {
        int currentPlayerScore = points;
        
        if (top5Scores.Length > 0)
        {
            int maxScoreInTop5 = top5Scores.Min(score => score.playerScore);
            return currentPlayerScore > maxScoreInTop5;
        }
        else
        {
            return true;
        }
    }

    private void AddScoreToTop5(PlayerScoreData newScore)
    {
        top5Scores = top5Scores.Concat(new[] { newScore }).ToArray();
    }

    private void SortTop5Scores()
    {
        top5Scores = top5Scores.OrderByDescending(score => score.playerScore).ToArray();

        top5Scores = top5Scores.Take(5).ToArray();
    }

    public void Reset()
    {
        UpdateTop5Scores();
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;
        RedBlockModifyScript.allRedBlocks.Clear();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("balls", balls);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("pointsToBall", pointsToBall);
        PlayerPrefs.SetInt("music", music ? 1 : 0);
        PlayerPrefs.SetInt("sound", sound ? 1 : 0);
    }

    public void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
        balls = PlayerPrefs.GetInt("balls", 6);
        points = PlayerPrefs.GetInt("points", 0);
        pointsToBall = PlayerPrefs.GetInt("pointsToBall", 0);
        music = PlayerPrefs.GetInt("music", 1) == 1;
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
    }


}

[System.Serializable] public class BonusProbabilities
{
    [System.Serializable] public class BonusProbability {
        public string bonus;
        public float probability;
    }
    [SerializeField] BonusProbability[] probabilities;
    public void Normalize()
    {
        float sum = 0;
        foreach(var p in probabilities)
        {
            sum += p.probability;
        }
        foreach(var p in probabilities)
        {
            p.probability /= sum;
        }

        probabilities = probabilities.OrderBy(p => p.probability).ToArray();
    }

    public string GetBonus(float chance)
    {
        float P = 0;
        for(int i = 0; i < probabilities.Length; i++)
        {
            if(chance >= P && chance < P + probabilities[i].probability)
                return probabilities[i].bonus;
            P += probabilities[i].probability;
        }
        return "Default";
    }
}

[System.Serializable]
public class PlayerScoreData
{
    public string playerName;
    public int playerScore;
}
