using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSet : MonoBehaviour
{
    [SerializeField] LadderCheck ladderCheck;
    [SerializeField] ItemManeger itemManeger;
    [SerializeField] Item ladderDate;
    [SerializeField] GameObject ladderObject;
    [SerializeField] GameObject player;
    [System.NonSerialized] public static Vector3 ladderPosition;
    [System.NonSerialized] public static Transform ladderSetObject;

    private void Update()
    {
        if(ladderCheck.ladderCheckFlag == true && itemManeger.numOfItem[ladderDate] >= 1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 setPosition = ladderPosition;
                //setPosition.y += (ladderObject.transform.localScale.y / 2.0f) - 0.2f;
                GameObject createLadder = Instantiate(ladderObject, ladderPosition,Quaternion.identity);
                createLadder.transform.LookAt(ladderSetObject);
                if(createLadder.transform.rotation.y >= 0 && createLadder.transform.rotation.y < 90)
                {
                    createLadder.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                else if (createLadder.transform.rotation.y >= 90 && createLadder.transform.rotation.y < 180)
                {
                    createLadder.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (createLadder.transform.rotation.y >= 180 && createLadder.transform.rotation.y < 270)
                {
                    createLadder.transform.rotation = Quaternion.Euler(0, 270, 0);
                }
                else if (createLadder.transform.rotation.y >= 270 && createLadder.transform.rotation.y < 360)
                {
                    createLadder.transform.rotation = Quaternion.Euler(0, 360, 0);
                }
                itemManeger.numOfItem[ladderDate] -= 1;
            }
        }
    }
}
