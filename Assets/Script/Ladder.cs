using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool ladderFlag;
    private bool upFlag;
    private bool downFlag;
    Rigidbody player;
    [SerializeField] float ladderSpeed = 0.1f;

    private void Start()
    {
        ladderFlag = false;
    }

    private void Update()
    {
        if(ladderFlag == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                upFlag = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                downFlag = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if(upFlag == true)
        {
            player.velocity = new Vector3(0, ladderSpeed, 0);
            upFlag = false;
        }
        if(downFlag == true)
        {
            player.velocity = new Vector3(0, -ladderSpeed, 0);
            downFlag = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" && ladderFlag == false)
        {
            PlayerMove.moveFlag = false;
            ladderFlag = true;
            player = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player" && ladderFlag == true)
        {
            PlayerMove.moveFlag = true;
            player = null;
            upFlag = false;
            downFlag = false;
            ladderFlag = false;
        }
    }
}
