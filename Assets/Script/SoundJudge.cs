using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundJudge : MonoBehaviour
{

    [System.NonSerialized] public static bool soundFlag = false;
    [System.NonSerialized] public static bool soundJudge = false;
    [System.NonSerialized] public static Vector3 soundPoint = new Vector3();
    [SerializeField] float chaseTime;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (soundFlag == true)
            {
                soundJudge = true;
                //Debug.Log(soundPoint);
            }
        }
    }
}
