using UnityEngine;
using UnityEngine.UI;


public class EnemyStateMachine : MonoBehaviour
{
    public BaseEnemeyClass enemy;
    public Text enemeyHP;
    public PlayerStateMachine tempPlayer;
    public GameMaster tempGameMaster;

    // Use this for initialization
    void Start()
    {
        tempPlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
        tempGameMaster = GameObject.Find("Plane").GetComponent<GameMaster>();
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

                    if (tempPlayer.player.playerTurn == false)
                    {
                        EnemeyCurState = EnemyState.Turn;
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
                    enemy.enemyTurn = true;
                    Debug.Log("Enemy Turn");

                    if (enemy.curHP <= 0)
                    {
                        EnemeyCurState = EnemyState.Dead;
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
        enemy.enemyTurn = false;
    }

    public void EnemyDefend()
    {
        enemy.enemeyDefend = true;
    }

    public void HeavyAttack()
    {
        tempPlayer.player.curHP--;
        tempPlayer.player.curHP--;
        enemy.enemyTurn = false;
    }
}
