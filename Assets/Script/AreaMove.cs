using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMove : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Transform newAreaPoint;

    private void OnCollisionEnter(Collision collision)
    {
        player.transform.position = newAreaPoint.position;
        StartManager.mainStartFlag = true;
        PlayerMove.moveFlag = false;
    }
}
