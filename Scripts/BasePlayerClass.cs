using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BasePlayerClass
{

    public float baseHP;
    public float curHP;
    public Text PlayerHP;
    public Text PlayerStamina;

    public bool playerTurn;
    public bool playerDefend;

    public float baseMP;
    public float curMP;

    public int stamnia;


    public void SetText()
    {
        PlayerHP.text = curHP.ToString();
        PlayerStamina.text = stamnia.ToString();
    }
}