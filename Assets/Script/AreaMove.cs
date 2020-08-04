using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMove : MonoBehaviour
{

    [SerializeField] Transform newAreaPoint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject oldAreaEnemy;
    [SerializeField] GameObject newAreaEnemy;
    [SerializeField] bool tutorialArea;

    bool areaMoveFlag;
    bool enemyMoveFlag;
    float enemyMoveTime = 5.0f;
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
                newAreaEnemy.GetComponent<Transform>().position = newAreaPoint.position;
                newAreaEnemy.GetComponent<Transform>().rotation = newAreaPoint.rotation;
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
            player.transform.position = newAreaPoint.position;
            if(tutorialArea == false)
            {
                oldAreaEnemy.SetActive(false);
            }
            enemyMoveFlag = true;
            time = 0;
        }
    }
}
