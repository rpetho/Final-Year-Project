using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;


public class EnemeyAgent : Agent {

    public GameObject enemeyObj;
    private BasicAcademy academy;
    public bool playerJustAttacked = false;
    public EnemyStateMachine tempEnemey;
    public HeuristicBrain HeuristicBrain;
    public HeuristicLogic HeuristicLogic;

    public void InitialiseAgent()
    {
        tempEnemey = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
    }

    public override void CollectObservations()
    {
        tempEnemey = GameObject.Find("Enemy").GetComponent<EnemyStateMachine>();
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        var response = (int)vectorAction[0];

        switch (response)
        {
            case 1:
                tempEnemey.BasicAttack();
                break;
            case 2:
                tempEnemey.HeavyAttack();
                break;
        }
        base.AgentAction(vectorAction, textAction);
    }


}
