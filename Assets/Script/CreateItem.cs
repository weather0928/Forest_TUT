using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateItem : MonoBehaviour
{
    [System.NonSerialized] public static Item craftItemDate;
    [SerializeField] private ItemManeger itemManeger;
    [SerializeField] private float stopTime;
    [SerializeField] private Color origColor;
    [SerializeField] private GameObject player;
    private float seconds;
    [System.NonSerialized] public static bool craftFlag;

    private void Update()
    {
        if(craftFlag == true)
        {
            SoundJudge.soundFlag = true;
            SoundJudge.soundPoint = player.transform.position;
            seconds += Time.deltaTime;
            player.GetComponent<Renderer>().material.color = new Color(255f / 255f, 65f / 255f, 26f / 255f, 255f / 255f);
            Debug.Log(seconds);
            if (seconds >= stopTime)
            {
                itemManeger.numOfItem[craftItemDate] += 1;
                craftFlag = false;
                SoundJudge.soundFlag = false;
                seconds = 0.0f;
                //PlayerMove.moveFlag = true;
                Debug.Log(itemManeger.numOfItem[craftItemDate]);
                player.GetComponent<Renderer>().material.color = origColor;
            }
        }
        
    }
 }

