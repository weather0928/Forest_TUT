using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundItem : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        audioSource.Play();
        SoundJudge.soundFlag = true;
        SoundJudge.soundPoint = transform.position;
    }
}
