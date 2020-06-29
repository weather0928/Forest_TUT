using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSearchArea : MonoBehaviour
{
    [SerializeField] float keepScreamTime = 0.0f;
    float second = 0.0f;

    bool playerExitFlag = false;
    [SerializeField] Color origColor;

    private void Update()
    {
        if(playerExitFlag == true)
        {
            second += Time.deltaTime;
            if (second >= keepScreamTime)
            {
                GetComponent<Renderer>().material.color = origColor;
                SoundJudge.soundFlag = false;
                second = 0f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SoundJudge.soundFlag = true;
            playerExitFlag = false;
            second = 0f;
            GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 0f / 255f, 255f / 255f);
            if (EnemyChaser.inArea == false)
            {
                SoundJudge.soundPoint = transform.position;
            }
            
        }
    }
    void OnTriggerExit(Collider other) //索敵範囲からターゲットが出たときにする処理
    {
        if (other.gameObject.tag == "Player")
        {
            playerExitFlag = true;
        }
    }
}
