using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        SoundJudge.soundFlag = true;
        SoundJudge.soundPoint = transform.position;
    }
}
