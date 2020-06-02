using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    Vector3 pos;
    Transform tr;
    public PlayerStateMachine tempPlayer;
    float distance;
    public float TileDistance;
    public Vector3 lastSpot;
    public GameObject[] PlayingField;
    public Transform[] Tile;
    public Transform goToTile;

    void Start()
    {
        // Build array of current tile set
        PlayingField = GameObject.FindGameObjectsWithTag("Floor");

        tempPlayer = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
        pos = transform.position;
        tempPlayer.player.playerTurn = true;
        tr = transform;
        goToTile = transform;
        lastSpot.y = 2.0f;
    }

    void Update()
    {

        if (tempPlayer.player.playerTurn == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                for (int i = 0; i < PlayingField.Length; i++)
                {
                    distance = Vector3.Distance(transform.position, PlayingField[i].transform.position);

                    if (distance < TileDistance && transform.position.x > PlayingField[i].transform.position.x 
                        && transform.position.z == PlayingField[i].transform.position.z
                        && transform.position != PlayingField[i].transform.position)
                    {
                        goToTile.position = PlayingField[i].transform.position;
                        break;
                    }

                }
                transform.position = new Vector3(goToTile.position.x, 2.0f, goToTile.position.z);
                tempPlayer.player.stamnia--;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                for (int i = 0; i < PlayingField.Length; i++)
                {
                    distance = Vector3.Distance(transform.position, PlayingField[i].transform.position);

                    if (distance < TileDistance && transform.position.x < PlayingField[i].transform.position.x && transform.position.z == PlayingField[i].transform.position.z
                        && transform.position != PlayingField[i].transform.position)
                    {
                        goToTile.position = PlayingField[i].transform.position;


                        break;
                    }

                }
                transform.position = new Vector3(goToTile.position.x, 2.0f, goToTile.position.z);
                tempPlayer.player.stamnia--;

            }
            else if (Input.GetKey(KeyCode.W))
            {
                for (int i = 0; i < PlayingField.Length; i++)
                {
                    distance = Vector3.Distance(transform.position, PlayingField[i].transform.position);

                    if (distance < TileDistance && transform.position.z > PlayingField[i].transform.position.z 
                        && transform.position.x == PlayingField[i].transform.position.x
                        && transform.position != PlayingField[i].transform.position)
                    {
                        goToTile.position = PlayingField[i].transform.position;


                        break;
                    }

                }
                transform.position = new Vector3(goToTile.position.x, 2.0f, goToTile.position.z);
                tempPlayer.player.stamnia--;
                //tempPlayer.player.playerTurn = false;

            }
            else if (Input.GetKey(KeyCode.S))
            {

                for (int i = 0; i < PlayingField.Length; i++)
                {
                    distance = Vector3.Distance(transform.position, PlayingField[i].transform.position);

                    if (distance < TileDistance && transform.position.z < PlayingField[i].transform.position.z 
                        && transform.position.x == PlayingField[i].transform.position.x
                        && transform.position != PlayingField[i].transform.position)

                    {
                        goToTile.position = PlayingField[i].transform.position;

                        break;
                    }

                }
                transform.position = new Vector3(goToTile.position.x, 2.0f, goToTile.position.z);
                //transform.position.Set(goToTile.position.x, 2.0f, goToTile.position.z);
                tempPlayer.player.stamnia--;
                //tempPlayer.player.playerTurn = false;
            }
        }

        //if (tempPlayer.player.playerTurn == false)
        //{
        //    transform.position.Set(goToTile.position.x, lastSpot.y, goToTile.position.z);
        //    tempPlayer.player.stamnia--;
        //    //transform.Translate(goToTile.position * Time.deltaTime);
        //}


    }
}
