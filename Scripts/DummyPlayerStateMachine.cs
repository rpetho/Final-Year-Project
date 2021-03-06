﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerStateMachine : MonoBehaviour
{

    public BasePlayerClass player;
    public GameObject attackButton;
    public EnemyStateMachine EnemeyTemp;


    // Use this for initialization
    void Start()
    {
        EnemeyTemp = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
    }

    public enum PlayerState { Turn, Wait };
    PlayerState PlayerCurState = PlayerState.Turn;

    // Update is called once per frame
    void Update()
    {
        player.SetText();
        EnemeyTemp = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
        PlayerStateFunc();
    }

    void PlayerStateFunc()
    {
        switch (PlayerCurState)
        {

            case PlayerState.Turn:
                {
                    player.stamnia = player.stamnia + 5;

                    PlayerAttack();


                    player.playerDefend = false;
                    if (player.playerTurn == true)
                    {
                        attackButton.SetActive(true);
                        Debug.Log("Dummy Player Turn");
                    }
                    else
                    {
                        PlayerCurState = PlayerState.Wait;
                    }
                    break;
                }
            case PlayerState.Wait:
                {
                    attackButton.SetActive(false);
                    Debug.Log("Dummy Player Wait");
                    if (player.playerTurn == true)
                    {
                        PlayerCurState = PlayerState.Turn;
                    }
                    break;
                }
        }
    }


    public void TakeDamage()
    {
        if (player.playerDefend == true)
        {

        }
        else
        {
            player.curHP--;
        }
    }

    public void PlayerAttack()
    {
        EnemeyTemp = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
        EnemeyTemp.enemy.curHP--;
        player.playerTurn = false;
    }

    public void PlayerDefend()
    {
        Debug.Log("Player Defend");
        player.playerDefend = true;
    }
}
