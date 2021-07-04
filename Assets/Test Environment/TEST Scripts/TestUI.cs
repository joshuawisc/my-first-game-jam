using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    Text statDisplay;
    PlayableCharacter player;
    // Start is called before the first frame update
    void Start()
    {
        statDisplay = GetComponent<Text>();
        player = FindObjectOfType<PlayableCharacter>();

        //Change Player's hp to test potions
        //TODO: Remove this
        player.MaximumHealth = 1000;
        player.Health = 1;

    }

    // Update is called once per frame
    void Update()
    {
        statDisplay.text = GenerateStatText(player);
    }

    //Returns a string containing player's current stat
    private string GenerateStatText(PlayableCharacter player)
    {
        string statText = "Temp UI, Test Only\n";
        statText += $"HP: {player.Health}/{player.MaximumHealth}\n";
        statText += $"Gold: {player.Gold}\n";
        statText += $"Key: {player.Key}\n";
        return statText;
    }
}
