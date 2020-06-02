using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour {

    public BasePlayerClass player;
    public GameObject attackButton;
    public GameObject HevAttButton;
    public PlayerGridMovement GridMovement;
    public EnemyStateMachine EnemeyTemp;
    public Transform TfEnemey;
    float distance;
    private EnemyStateMachine tempEnemey;
    public PlayerStateMachine tempPlayer;
    public GameObject Enemey;
    float TileDistanceRadius = 7.5f;

    public float maxAllowedDistance = 8.0f;

    bool DummyTrainerMode;
    bool DummyInRange;


    // Use this for initialization
    void Start() {
        player.inRange = false;
        GridMovement = GameObject.Find("Player").GetComponent<PlayerGridMovement>();

        EnemeyTemp = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
    }

    public enum PlayerState {Turn, Wait, Dead};
    PlayerState PlayerCurState = PlayerState.Turn;

    // Update is called once per frame
    void Update() {


        tempEnemey = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
        tempPlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();

        player.SetText();
        GridMovement = GameObject.Find("Player").GetComponent<PlayerGridMovement>();
        EnemeyTemp = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
        PlayerStateFunc();

        distance = Vector3.Distance(transform.position, TfEnemey.position);
        if (distance < maxAllowedDistance)
        {
            player.inRange = true;
        }
        else
        {
            player.inRange = false;
        }

    }



    void PlayerStateFunc()
    {
        switch (PlayerCurState)
        {
            // Players Turn State
            case PlayerState.Turn:
                {
                    player.playerDefend = false;        // Bool to read if player is defending
                    if (player.playerTurn == true)      // Check to see if it is really the players turn
                    {
                        if (player.inRange == true)     // Checks if player is in range to attack the Enemey
                        {
                            attackButton.SetActive(true);
                            if (player.stamnia > 2)
                            {
                                HevAttButton.SetActive(true);
                            }
                            else
                            {
                                HevAttButton.SetActive(false);
                            }
                        }
                        else
                        {
                            HevAttButton.SetActive(false);
                            attackButton.SetActive(false);
                        }


                        if (DummyTrainerMode == true)
                        {
                            distance = Vector3.Distance(Enemey.transform.position, tempPlayer.transform.position);
                            if (distance < TileDistanceRadius)
                            {
                                PlayerAttack();
                            }
                            
                        }

                        Debug.Log("Player Turn");

                        if (player.stamnia <= 0)
                        {
                            player.playerTurn = false;
                            EnemeyTemp.enemy.enemyTurn = true;

                        }

                    }
                    else if (player.playerTurn == false)
                    {
                        PlayerCurState = PlayerState.Wait;
                    }
                    break;
                }
            case PlayerState.Wait:
                {
                    player.stamnia = 3;

                    if (player.curHP <= 0)
                    {
                        PlayerCurState = PlayerState.Dead;
                    }
                    EnemeyTemp.enemy.enemyTurn = true;
                    attackButton.SetActive(false);
                    Debug.Log("Player Wait");
                    if (player.playerTurn == true)
                    {
                        PlayerCurState = PlayerState.Turn;
                    }
                    break;
                }
            case PlayerState.Dead:
                {
                    Debug.Log("Player Dead");
                    PlayerCurState = PlayerState.Turn;

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
        if (player.playerTurn == true)
        {
            EnemeyTemp.TakeDamage();
            player.stamnia--;
        }
    }

    public void PlayerDefend()
    {
        Debug.Log("Player Defend");
        player.playerDefend = true;
    }

    public void PlayerHeavyAttack()
    {
        if (player.playerTurn == true)
        {
            EnemeyTemp.TakeDamage();
            EnemeyTemp.TakeDamage();
            player.stamnia--;
            player.stamnia--;

        }
    }

}
