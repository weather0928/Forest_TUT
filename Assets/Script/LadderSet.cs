using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSet : MonoBehaviour
{
    [SerializeField] GameObject ladderCheck;
    [SerializeField] ItemManeger itemManeger;
    [SerializeField] Item ladderDate;
    [SerializeField] GameObject ladderObject;
    [SerializeField] GameObject player;
    [System.NonSerialized] public static Vector3 ladderPosition;

    private void Update()
    {
        if(ladderCheck.GetComponent<LadderCheck>().ladderCheckFlag == true && itemManeger.numOfItem[ladderDate] >= 1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 setPosition = ladderPosition;
                setPosition.y += (ladderObject.transform.localScale.y / 2.0f) - 0.5f;
                GameObject createLadder = Instantiate(ladderObject, setPosition, player.transform.rotation);
                itemManeger.numOfItem[ladderDate] -= 1;
            }
        }
        else if(ladderCheck.GetComponent<LadderCheck>().ladderCheckFlag == false && itemManeger.numOfItem[ladderDate] >= 1)
        {

        }
    }
}
