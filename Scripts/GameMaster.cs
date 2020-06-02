using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameMaster : MonoBehaviour {

    // This script is used to control all features that aren't relevant to the Human player or the AI 

    // Numbers to hold current game and round Number
    public int roundNumber = 1;
    public int currentGame = 1;

    // Text variables to hold the values to be displayed onscreen
    public Text roundNumberText;
    public Text gameNumberText;

    public KeyCode KeyAtk;


    // Temp objects to be used exclusively in the GameMaster Class
    EnemyStateMachine EnemeyGM;
    PlayerStateMachine PlayerGM;

    // Enum to read the current round
    public enum Turn {PlayerTurn, EnemeyTurn, GameOver};


    // Use this for initialization
    void Start () {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        EnemeyGM = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
        PlayerGM = GameObject.Find("Player").GetComponent<PlayerStateMachine>();

        if (EnemeyGM.enemy.curHP <= 0 || PlayerGM.player.curHP <= 0)
        {
            Debug.Log("GameOver");
            ResetGame();
        }


    }

    public void SetText()   // Setting the current rounds text onscreen
    {
        roundNumberText.text = roundNumber.ToString();
        gameNumberText.text = currentGame.ToString();
    }

    public void ResetGame() //Function for resetting the game enviroment
    {
        roundNumber = 1;
        currentGame++;
        EnemeyGM.enemy.curHP = EnemeyGM.enemy.baseHP;
        PlayerGM.player.curHP = PlayerGM.player.baseHP;

    }
}
