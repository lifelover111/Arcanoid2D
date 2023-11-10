using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBonus : BonusBase
{
    private void Awake()
    {
        backgroundColor = Color.Lerp(Color.red, Color.yellow, 0.5f);
        textColor = Color.black;
        bonusName = "Fire";
    }
    protected override void BonusActivate()
    {
        if (player == null)
            Debug.LogError("player is null");
        Ball[] balls = (Ball[])FindObjectsByType(typeof(Ball), FindObjectsSortMode.None);
        foreach (Ball ball in balls)
        {
            ball.SetColor(backgroundColor);
            ball.damage = 4;
        }
    }
}
