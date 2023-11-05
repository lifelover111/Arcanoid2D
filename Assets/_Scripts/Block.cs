using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public TMP_Text counter;

    public int hitsToDestroy;
    public int points;

    Player player;

    void Start()
    {
        if (counter != null)
        {
            counter.text = hitsToDestroy.ToString();
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        {
            hitsToDestroy--;
            if (hitsToDestroy == 0)
            {
                Destroy(gameObject);
                player.BlockDestroyed(points);
            }
            else if (counter != null)
                counter.text = hitsToDestroy.ToString();
        }
    }

}
