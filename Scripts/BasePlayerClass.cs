using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BasePlayerClass
{

    public float baseHP;    // Player Base Health
    public float curHP;     // Player Current Health
    public Text PlayerHP;   // Text Output of player Health
    public Text PlayerStamina;  // Text Output of Player Stamina

    public bool playerTurn;     // Boolean for if its players turn
    public bool playerDefend;   // Boolean for if the player is defending
    public bool inRange;        // Boolean for if the player is in range to attack

    public float baseMP;    // Base Magic power
    public float curMP;     // Current Magic power

    public int stamnia;     // Player Stamina


    public void SetText()   // Set Text Func
    {
        PlayerHP.text = curHP.ToString();
        PlayerStamina.text = stamnia.ToString();
    }
}