using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UseItemUI : MonoBehaviour
{

    [SerializeField] ItemManeger itemManeger;

    //アイテムが何もないときに表記するものを入れる
    [SerializeField] GameObject nonItemUI;

    [SerializeField] GameObject ladderUI;
    [SerializeField] Item ladderDate;
    [SerializeField] GameObject bellUI;
    [SerializeField] Item bellDate;
    [SerializeField] GameObject trapUI;
    [SerializeField] Item trapDate;
    private bool[] itemFlag;
    private int itemNumber;
    private bool switchFlag;
    private bool switchConpleateFlag;
    private LadderSet ladderSet;
    private ThrowItem throwItem;
    private StaleItemSet staleItemSet;

    private void Start()
    {
        ladderSet = ladderUI.GetComponent<LadderSet>();
        throwItem = bellUI.GetComponent<ThrowItem>();
        staleItemSet = trapUI.GetComponent<StaleItemSet>();
        ladderUI.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        bellUI.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        trapUI.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        
        if(itemManeger.numOfItem[ladderDate] >= 1 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ImageAlpha(ladderUI, bellUI, trapUI);
            ladderSet.enabled = true;
            throwItem.enabled = false;
            staleItemSet.enabled = false;
        }
        else if(itemManeger.numOfItem[bellDate] >= 1 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            ImageAlpha(bellUI,ladderUI, trapUI);
            ladderSet.enabled = false;
            throwItem.enabled = true;
            staleItemSet.enabled = false;
        }
        else if(itemManeger.numOfItem[trapDate] >= 1 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            ImageAlpha(trapUI,ladderUI,bellUI);
            ladderSet.enabled = false;
            throwItem.enabled = false;
            staleItemSet.enabled = true;
        }
        
    }

    private void ImageAlpha(GameObject useItem,GameObject nonUseItem1,GameObject nonUseItem2)
    {
        useItem.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        nonUseItem1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        nonUseItem2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }
}
