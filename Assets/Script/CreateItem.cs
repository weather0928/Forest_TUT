using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CreateItem : MonoBehaviour
{
    [System.NonSerialized] public static Item craftItemDate;
    [SerializeField] private ItemManeger itemManeger;
    [SerializeField] Item hammerItem;
    [SerializeField] int hammerUse;
    [SerializeField] private float stopTime;
    [SerializeField] private Color origColor;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject slider;
    private float seconds;
    int hammerRemainingUses;
    [System.NonSerialized] public static bool craftFlag;
    [System.NonSerialized] public static bool createStartFlag;

    GameObject soundManeger;

    private void Start()
    {
        createStartFlag = false;
        slider.SetActive(false);
        soundManeger = GameObject.Find("SoundManager");
    }

    private void Update()
    {
        if(craftFlag == true)
        {
            if(createStartFlag == true)
            {
                slider.SetActive(true);
                if(itemManeger.numOfItem[hammerItem] == 1)
                {
                    slider.GetComponent<Slider>().maxValue = stopTime / 2;
                }
                else
                {
                    slider.GetComponent<Slider>().maxValue = stopTime;
                }
                soundManeger.GetComponent<SoundManager>().PlaySeByName("3konngou");
                createStartFlag = false;
            }
            slider.GetComponent<Slider>().value = seconds;
            SoundJudge.soundFlag = true;
            SoundJudge.soundPoint = player.transform.position;
            seconds += Time.deltaTime;
            player.GetComponent<Renderer>().material.color = new Color(255f / 255f, 65f / 255f, 26f / 255f, 255f / 255f);
            Debug.Log(seconds);
            this.GetComponent<CanvasGroup>().alpha = 0;
            this.GetComponent<CanvasGroup>().interactable = false;
            if(itemManeger.numOfItem[hammerItem] == 1)
            {
                if (seconds >= stopTime / 2)
                {
                    CreateComplete();
                    hammerRemainingUses--;
                    if(hammerRemainingUses == 0)
                    {
                        itemManeger.numOfItem[hammerItem]--;
                    }
                }
            }
            else
            {
                if (seconds >= stopTime)
                {
                    CreateComplete();
                }
            }
        }
        
    }

    private void CreateComplete()
    {
        itemManeger.numOfItem[craftItemDate] += 1;
        if(craftItemDate == hammerItem)
        {
            hammerRemainingUses = hammerUse;
        }
        soundManeger.GetComponent<SoundManager>().StopSe();
        craftFlag = false;
        SoundJudge.soundFlag = false;
        seconds = 0.0f;
        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;
        Debug.Log(itemManeger.numOfItem[craftItemDate]);
        player.GetComponent<Renderer>().material.color = origColor;
        slider.SetActive(false);
    }
}

