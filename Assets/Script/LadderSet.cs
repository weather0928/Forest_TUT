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

    private void Update()
    {
        if(ladderCheck.GetComponent<LadderCheck>().ladderCheckFlag == true && itemManeger.numOfItem[ladderDate] >= 1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 setPosition = new Vector3(ladderCheck.transform.position.x, ladderCheck.transform.position.y + (ladderObject.transform.localScale.y / 2), ladderCheck.transform.position.z);
                GameObject createLadder = Instantiate(ladderObject, setPosition, transform.rotation);
                itemManeger.numOfItem[ladderDate] -= 1;
            }
        }
        else if(ladderCheck.GetComponent<LadderCheck>().ladderCheckFlag == false && itemManeger.numOfItem[ladderDate] >= 1)
        {

        }
    }
}
