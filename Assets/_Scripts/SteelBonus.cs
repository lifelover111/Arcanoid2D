using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelBonus : BonusBase
{
    private void Awake()
    {
        backgroundColor = Color.Lerp(Color.black, Color.white, 0.5f);
        textColor = Color.black;
        bonusName = "Steel";
    }
    protected override void BonusActivate()
    {
        if (player == null)
            Debug.LogError("player is null");
        Ball[] balls = (Ball[])FindObjectsByType(typeof(Ball), FindObjectsSortMode.None);
        foreach (Ball ball in balls)
        {
            ball.SetColor(backgroundColor);
            ball.damage = 40;
        }
    }
}
