using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateItem : MonoBehaviour
{
    [SerializeField] private Item itemDate;
    [SerializeField] private ItemManeger itemManeger;
    [SerializeField] private float stopTime;
    [SerializeField] private Color origColor;
    private float seconds;
    //アイテム作成の情報を入れる
    [System.Serializable]
    public struct Cost
    {
        public Item MaterialItem;
        public int amount;
    }
    [SerializeField] private List<Cost> craftCost = new List<Cost>();

    private bool[] conditionFlag;
    private bool craftFlag;


    private void Start()
    {
        conditionFlag = new bool[craftCost.Count];
        for(int i = 0;i < conditionFlag.Length;i++)
        {
            conditionFlag[i] = false;
        }
    }

    private void Update()
    {
        for (int i = 0; i < craftCost.Count; i++)
        {
            if (itemManeger.numOfItem[craftCost[i].MaterialItem] >= craftCost[i].amount)
            {
                conditionFlag[i] = true;
            }
        }

        if (Input.GetKey(KeyCode.Q) && conditionFlag.All(i => i == true) && PlayerMove.moveFlag == true)
        {
            craftFlag = true;
        }

        if(craftFlag == true)
        {
            SoundJudge.soundFlag = true;
            SoundJudge.soundPoint = this.gameObject.transform.position;
            PlayerMove.moveFlag = false;
            seconds += Time.deltaTime;
            GetComponent<Renderer>().material.color = new Color(255f / 255f, 65f / 255f, 26f / 255f, 255f / 255f);
            Debug.Log(seconds);
            if (seconds >= stopTime)
            {
                itemManeger.numOfItem[itemDate] += 1;
                for (int i = 0; i < craftCost.Count; i++)
                {
                    itemManeger.numOfItem[craftCost[i].MaterialItem] -= craftCost[i].amount;
                    conditionFlag[i] = false;
                }
                craftFlag = false;
                SoundJudge.soundFlag = false;
                seconds = 0.0f;
                PlayerMove.moveFlag = true;
                Debug.Log(itemManeger.numOfItem[itemDate]);
                GetComponent<Renderer>().material.color = origColor;
            }
        }
        
    }
 }

