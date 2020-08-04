using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MterialItem : MonoBehaviour
{
    [SerializeField] private Item itemDate;
    [SerializeField] private int getItemNumber = 1;
    [SerializeField] private ItemManeger itemManeger;
    //[SerializeField] private AudioClip itemGetSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            itemManeger.numOfItem[itemDate] += getItemNumber;
            //SoundManager.seAudioSource.PlayOneShot(itemGetSound);
            Destroy(this.gameObject);
        }
    }
}
