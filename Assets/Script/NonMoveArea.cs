using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonMoveArea : MonoBehaviour
{
    [SerializeField] GameObject nonAreaMoveText;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            nonAreaMoveText.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            nonAreaMoveText.SetActive(false);
        }
    }
}
