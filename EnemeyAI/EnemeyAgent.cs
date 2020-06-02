using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;


public class EnemeyAgent : Agent
{

    public GameObject enemeyObj;
    public bool playerJustAttacked = false;
    public EnemyStateMachine tempEnemey;
    // public HeuristicBrain HeuristicBrain;
    // public HeuristicLogic HeuristicLogic;
    public PlayerStateMachine tempPlayer;
    public GameObject[] PlayingField;
    public GameObject Enemey;
    public Transform[] Tile;
    float distance;
    float tileDistance;
    float TileDistanceRadius = 7.5f;
    public Transform goToTile;


    public void InitialiseAgent()
    {
        PlayingField = GameObject.FindGameObjectsWithTag("Floor");
        goToTile = transform;

        tempEnemey = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
        tempPlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();

    }

    public override void AgentReset()
    {
        base.AgentReset();
    }



    public override void CollectObservations()
    {
        tempEnemey = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
        AddVectorObs(tempEnemey.enemy.curHP);
        AddVectorObs(tempPlayer.player.curHP);
        PlayingField = GameObject.FindGameObjectsWithTag("Floor");
        goToTile = transform;

    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        var response = (int)vectorAction[0];

        for (int i = 0; i < 1000; i++)
        { }

        if (brain.brainParameters.vectorActionSpaceType == SpaceType.continuous)
        {
            if (tempEnemey.enemy.inHittingRange == true)
            {
                if (tempEnemey.enemy.curHP >= tempPlayer.player.curHP && tempEnemey.enemy.enemyTurn == true)
                {
                    tempEnemey.BasicAttack();
                }
                else if (tempEnemey.enemy.curHP < tempPlayer.player.curHP && tempEnemey.enemy.enemyTurn == true)
                {
                    tempEnemey.HeavyAttack();
                }
            }
            else
            {
                //for (int i = 0; i < PlayingField.Length; i++)
                //{
                //    distance = Vector3.Distance(transform.position, tempPlayer.transform.position);
                //    tileDistance = Vector3.Distance(transform.position, PlayingField[i].transform.position);
                //    if (Vector3.Distance(PlayingField[i].transform.position, transform.position) < distance && tileDistance < TileDistanceRadius)
                //    {
                //        goToTile.position = PlayingField[i].transform.position;
                //        break;
                //    }
                //}
            }
        }
        base.AgentAction(vectorAction, textAction);
    }

    private void FixedUpdate()
    {
        PlayingField = GameObject.FindGameObjectsWithTag("Floor");
        goToTile = transform;

        tempEnemey = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
        tempPlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();

        if (tempEnemey.enemy.enemyTurn == true && tempEnemey.enemy.stamnia > 0)
        {
            for (int i = 0; i < 1000; i++)
            { }

            RequestDecision();
            distance = Vector3.Distance(Enemey.transform.position, tempPlayer.transform.position);

            if (distance < TileDistanceRadius)
            {
                tempEnemey.enemy.inHittingRange = true;
            }
            else
            {
                tempEnemey.enemy.inHittingRange = false;
            }

            float[] vectorAction = { 2 };
            if (tempEnemey.enemy.inHittingRange == true)
            {
                if (tempPlayer.player.curHP <= tempEnemey.enemy.curHP)
                {
                    tempEnemey.BasicAttack();
                    tempPlayer.player.playerTurn = true;
                    AddReward(1);
                }
                else if (tempPlayer.player.curHP > tempEnemey.enemy.curHP)
                {
                    tempEnemey.HeavyAttack();
                    tempPlayer.player.playerTurn = true;
                }
            }
            else 
            {
                for (int i = 0; i < PlayingField.Length; i++)
                {
                    distance = Vector3.Distance(transform.position, tempPlayer.transform.position);
                    tileDistance = Vector3.Distance(tempPlayer.transform.position, PlayingField[i].transform.position);
                    float enemeyDistance = Vector3.Distance(PlayingField[i].transform.position, transform.position);
                    float EtileDistance = Vector3.Distance(transform.position, PlayingField[i].transform.position);

                    if (enemeyDistance < distance && tileDistance < 7.5f)
                    {
                        goToTile.transform.position = PlayingField[i].transform.position;
                        Enemey.transform.position = new Vector3(PlayingField[i].transform.position.x, 2.0f, PlayingField[i].transform.position.z);
                        AddReward(1);
                    }

                    for (int j = 0; j < 10000; j++)
                    { }

                }

                //Enemey.transform.position = new Vector3(goToTile.transform.position.x, 2.0f, goToTile.transform.position.z);
                tempEnemey.enemy.stamnia--;

                 

            }

            if (tempEnemey.enemy.stamnia <= 0)
            {
                tempEnemey.enemy.enemyTurn = false;
                tempPlayer.player.playerTurn = true;
            }


        }
        Done();
        return;
    }
}