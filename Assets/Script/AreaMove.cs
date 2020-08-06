using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMove : MonoBehaviour
{

    [SerializeField] Transform newAreaPoint;
    [SerializeField] GameObject player;
    [SerializeField] Transform area1EnemyPoint;
    [SerializeField] GameObject oldAreaEnemy;
    [SerializeField] GameObject newAreaEnemy;
    [SerializeField] bool tutorialArea;
    [SerializeField] bool area1Flag;
    [SerializeField] bool itemConditionFlag;
    [SerializeField] Item moveConditionItemDate;
    [SerializeField] ItemManeger itemManeger;
    [SerializeField] GameObject nonHaveMoveItemUI;

    bool areaMoveFlag;
    bool enemyMoveFlag;
    float enemyMoveTime = 2.0f;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyMoveFlag == true)
        {
            time += Time.deltaTime;
            if (time >= enemyMoveTime)
            {
                if(area1Flag == true)
                {
                    newAreaEnemy.GetComponent<Transform>().position = area1EnemyPoint.position;
                    newAreaEnemy.GetComponent<Transform>().rotation = area1EnemyPoint.rotation;
                }
                else
                {
                    newAreaEnemy.GetComponent<Transform>().position = newAreaPoint.position;
                    newAreaEnemy.GetComponent<Transform>().rotation = newAreaPoint.rotation;
                }
                newAreaEnemy.SetActive(true);
                time = 0;
                enemyMoveFlag = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            if(itemConditionFlag == true)
            {
                if (itemManeger.numOfItem[moveConditionItemDate] >= 1)
                {
                    MoveArea();
                }
                else
                {
                    nonHaveMoveItemUI.SetActive(true);
                }
            }
            else
            {
                MoveArea();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(itemConditionFlag == true)
        {
            if (collision.gameObject == player && nonHaveMoveItemUI.activeSelf == true)
            {
                nonHaveMoveItemUI.SetActive(false);
            }
        }
    }

    void MoveArea()
    {
        player.transform.position = newAreaPoint.position;
        if (tutorialArea == false)
        {
            oldAreaEnemy.SetActive(false);
        }
        enemyMoveFlag = true;
        time = 0;
    }
}
