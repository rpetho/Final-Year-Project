using UnityEngine;
using UnityEngine.UI;
using MLAgents;


public class EnemyStateMachine : MonoBehaviour
{
    public BaseEnemeyClass enemy;
    public Text enemeyHP;
    public PlayerStateMachine tempPlayer;
    public GameMaster tempGameMaster;
    Agent enemyAgent;

    // Use this for initialization
    void Start()
    {
        tempPlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
        tempGameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        enemyAgent = GameObject.Find("Enemy").GetComponent<EnemeyAgent>();

    }



    public enum EnemyState { Turn, Wait, Dead };
    EnemyState EnemeyCurState = EnemyState.Wait;

    // Update is called once per frame
    void Update()
    {
        enemy.SetText();
        tempPlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
        EnemeyStateFunc();

    }


    public void EnemeyStateFunc()
    {
        switch (EnemeyCurState)
        {
            case EnemyState.Wait:
                {
                    Debug.Log("Enemy Wait");

                    enemy.stamnia = 3;

                    if (tempPlayer.player.playerTurn == false)
                    {
                        EnemeyCurState = EnemyState.Turn;
                        enemy.enemyTurn = true;
                    }
                    if (enemy.curHP <= 0)
                    {
                        EnemeyCurState = EnemyState.Dead;
                    }


                    break;
                }
            case EnemyState.Turn:
                {
                    enemy.enemeyDefend = false;
                    Debug.Log("Enemy Turn");


                    if (enemy.curHP <= 0)
                    {
                        EnemeyCurState = EnemyState.Dead;
                    }

                    if (enemy.stamnia <= 0)
                    {
                        enemy.enemyTurn = false;
                        tempPlayer.player.playerTurn = true;
                    }


                    if (enemy.enemyTurn == false)
                    {
                        EnemeyCurState = EnemyState.Wait;
                        tempPlayer.player.playerTurn = true;
                        tempGameMaster.roundNumber++;
                    }

                    break;
                }
            case EnemyState.Dead:
                {
                    Debug.Log("Enemy Dead");
                    EnemeyCurState = EnemyState.Wait;
                    break;
                }
        }
    }

    public void TakeDamage()
    {
        enemy.curHP--;
    }

    public void BasicAttack()
    {
        tempPlayer.player.curHP--;
        enemy.stamnia--;
    }

    public void EnemyDefend()
    {
        enemy.enemeyDefend = true;
    }

    public void HeavyAttack()
    {
        tempPlayer.player.curHP = tempPlayer.player.curHP - 2;
        enemy.stamnia--;
    }
}
