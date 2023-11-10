using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusBase : MonoBehaviour
{
    SpriteRenderer sRend;
    TMP_Text text;
    protected string bonusName = "+100";
    protected Color textColor = Color.black;
    protected Color backgroundColor = Color.yellow;
    protected static Player player;
    public float speed = 1.5f;
    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TMP_Text>();
        sRend.color = backgroundColor;
        text.color = textColor;
        text.text = bonusName;
    }
    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Wall"))
                Destroy(gameObject);
            return;
        }
        if (player == null)
            player = collision.GetComponent<Player>();
        BonusActivate();
        Destroy(gameObject);
    }

    protected virtual void BonusActivate()
    {
        if (player == null)
            Debug.LogError("player is null");
        player.gameData.points += 100;
    }
}
