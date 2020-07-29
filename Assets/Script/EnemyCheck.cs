using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCheck : MonoBehaviour
{
    [SerializeField] Image eyeUI;
    Color eyeColor;
    float speed = 1.0f;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eyeColor = eyeUI.color;
        if(EnemyChaser.chaseFlag == true && EnemyChaser.obstacleJudgFlag == false)
        {
            eyeColor.a = 1.0f;
            eyeUI.color = eyeColor;
        }
        else if(EnemyChaser.chaseFlag == true && EnemyChaser.obstacleJudgFlag == true)
        {
            time += Time.deltaTime * 5.0f * speed;
            eyeColor.a = Mathf.Sin(time) * 0.5f + 0.5f;
            eyeUI.color = eyeColor;
        }
        else
        {
            eyeColor.a = 0.0f;
            eyeUI.color = eyeColor;
        }
    }
}
