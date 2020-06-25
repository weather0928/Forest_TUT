using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSearchArea : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SoundJudge.soundFlag = true;
            if(EnemyChaser.inArea == false)
            {
                SoundJudge.soundPoint = transform.position;
            }
            
        }
    }
    void OnTriggerExit(Collider other) //索敵範囲からターゲットが出たときにする処理
    {
        if (other.gameObject.tag == "Player")
        {
            SoundJudge.soundFlag = false;
        }
    }
}
