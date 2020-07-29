using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchCamera : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    bool inArea = false;

    private void Update()
    {
        if(inArea == true)
        {
            bool obstacleJudgFlag = ObstacleJudg();
            if(obstacleJudgFlag == false)
            {
                EnemyChaser.chaseFlag = true;
            }
        }
        inArea = false;
    }

    void OnWillRenderObject()
    {
        if (Camera.current.name == "EnemyCamera")
        {
            inArea = true;
        }
    }

    bool ObstacleJudg()
    {
        bool flg;
        flg = Physics.Linecast(transform.position, enemy.transform.position + Vector3.up, 9);
        return flg;
    }
}
