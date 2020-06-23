using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool ladderFlag;
    [SerializeField] Rigidbody player;
    [SerializeField] float ladderSpeed = 0.1f;

    private void Start()
    {
        ladderFlag = false;
    }

    private void FixedUpdate()
    {
        if (ladderFlag == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.velocity = new Vector3(0, ladderSpeed, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.velocity = new Vector3(0, -ladderSpeed, 0);
            }

            /*if (Input.GetKeyDown(KeyCode.E))
            {
                ladderFlag = false;
            }*/
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" || ladderFlag == false)
        {
            PlayerMove.moveFlag = false;
            ladderFlag = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player" || ladderFlag == true)
        {
            PlayerMove.moveFlag = true;
            ladderFlag = false;
        }
    }
}
