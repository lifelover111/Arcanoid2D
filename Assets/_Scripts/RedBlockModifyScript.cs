using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class RedBlockModifyScript : MonoBehaviour
{
    public TMP_Text labelText;

    public string initialLabel = "O";
    public string alternateLabel = "X";
    public int points;
    public static List<RedBlockModifyScript> allRedBlocks = new List<RedBlockModifyScript>();
    private string currentLabel;

    Player player;

    void Start()
    {
        currentLabel = initialLabel;
        if (labelText != null)
        {
            labelText.text = currentLabel;
        }
        allRedBlocks.Add(this);
        player = GameObject.FindGameObjectWithTag("Player")
 .GetComponent<Player>();

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        {

            currentLabel = (currentLabel == alternateLabel) ? initialLabel : alternateLabel;
            labelText.text = currentLabel;
            CheckForSimultaneousDestruction();
        }
    }

    private void CheckForSimultaneousDestruction()
    {

        bool allMatch = true;
        foreach (var block in allRedBlocks)
        {
            if (block.currentLabel != alternateLabel)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
        {
            foreach (var block in allRedBlocks)
            {
                Destroy(block.gameObject);
 
            }
            points = points * allRedBlocks.Count;
            player.BlockDestroyed(points);
            allRedBlocks.Clear();
        }
    }
}
