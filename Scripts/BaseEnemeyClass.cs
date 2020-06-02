using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BaseEnemeyClass {

    public float baseHP;
    public float curHP;
    public Text enemeyHP;
    public bool enemyTurn;
    public bool enemeyDefend;
    public bool inHittingRange;

    public float baseMP;
    public float curMP;

    public int stamnia;
    public Text enemeySta;


    public void SetText()
    {
        enemeyHP.text = curHP.ToString();
        enemeySta.text = stamnia.ToString();
    }

    public float getCurHP()
    {
        return curHP;
    }

    public void setCurHP(float tempHP)
    {
        curHP = tempHP;
    }

    public void takeDanage()
    {
        curHP--;
    }

}
