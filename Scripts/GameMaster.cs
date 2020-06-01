using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameMaster : MonoBehaviour {

    public int roundNumber = 0;
    public Text roundNumberText;

    EnemyStateMachine enemeyGM;
    PlayerStateMachine playerGM;

    public enum turns {PlayerTurn, EnemeyTurn, GameOver};

    public GameObject attackButton;

    // Use this for initialization
    void Start () {
        SetText();
    }
	
	// Update is called once per frame
	void Update () {
        SetText();
    }

    public void SetText()
    {
        roundNumberText.text = roundNumber.ToString();
    }

}
