using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchArea : MonoBehaviour
{

    [SerializeField] GameObject Enemy;

    void OnTriggerStay(Collider other) //ターゲット（プレイヤー）索敵処理
    {
        if (other.gameObject.tag == "Player" 
            && Physics.Linecast(Enemy.transform.position + Vector3.up, other.transform.position + Vector3.up,2) == false)
        {
            EnemyChaser.chaseFlag = true;
        }
    }

    void OnTriggerExit(Collider other) //索敵範囲からターゲットが出たときにする処理
    {
        if (other.gameObject.tag == "Player")
        {
            EnemyChaser.chaseSwitchFlag = true;
        }
    }
}
