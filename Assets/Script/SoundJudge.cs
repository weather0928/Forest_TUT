using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundJudge : MonoBehaviour
{

    [System.NonSerialized] public static bool soundFlag = false;
    [System.NonSerialized] public static bool soundJudge = false;
    [System.NonSerialized] public static Vector3 soundPoint = new Vector3();

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "SoundItem")
        {
            if (soundFlag == true && soundJudge == false)
            {
                soundJudge = true;
                EnemyChaser.soundHeardFlag = true;
            }
        }
    }
}
