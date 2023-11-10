using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public TMP_Text counter;

    public int hitsToDestroy;
    public int points;

    public bool dropBonus = false;
    [SerializeField] GameObject bonusPrefab;

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
            hitsToDestroy -= collision.gameObject.GetComponent<Ball>().damage;
            if (hitsToDestroy <= 0)
            {
                DestroyBlock();
            }
            else if (counter != null)
                counter.text = hitsToDestroy.ToString();
        }
    }

    void DestroyBlock()
    {
        if(dropBonus)
        {
            DropBonus();
        }
        Destroy(gameObject);
        player.BlockDestroyed(points);
    }

    void DropBonus()
    {
        GameObject go = Instantiate(bonusPrefab);
        string bonus = player.gameData.bonusProbabilities.GetBonus(Random.value);
        switch (bonus)
        {
            case "Fire":
                go.AddComponent<FireBonus>();
                break;
            case "Steel":
                go.AddComponent<SteelBonus>(); 
                break;
            case "Norm":
                go.AddComponent<NormBonus>();
                break;
            default:
                go.AddComponent<BonusBase>();
                break;
        }
        go.transform.position = transform.position;
    }
}
