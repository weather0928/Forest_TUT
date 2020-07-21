using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [System.NonSerialized] public bool ladderFlag;
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
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        else
        {
            if (ladderFlag == true)
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
        if (other.gameObject.tag == "Player")
        {
            ladderFlag = true;
            player = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player" && ladderFlag == true)
        {
            player = null;
            upFlag = false;
            downFlag = false;
            ladderFlag = false;
        }
    }
}
