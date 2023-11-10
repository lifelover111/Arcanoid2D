using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormBonus : BonusBase
{
    private void Awake()
    {
        backgroundColor = Color.white;
        textColor = Color.black;
        bonusName = "Norm";
    }
    protected override void BonusActivate()
    {
        if (player == null)
            Debug.LogError("player is null");
        Ball[] balls = (Ball[])FindObjectsByType(typeof(Ball), FindObjectsSortMode.None);
        foreach (Ball ball in balls)
        {
            ball.SetColor(backgroundColor);
            ball.damage = 1;
        }
    }
}
