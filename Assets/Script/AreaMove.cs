using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMove : MonoBehaviour
{

    [SerializeField] Transform newAreaPoint;
    [SerializeField] Transform oldAreaPoint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

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
            Debug.Log(time);
            if (time >= enemyMoveTime)
            {
                enemy.SetActive(true);
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
            enemyMoveFlag = true;
            time = 0;
        }
    }
}
