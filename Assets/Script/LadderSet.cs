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
    [System.NonSerialized] public static Quaternion ladderRotetion;

    private void Update()
    {
        if(ladderCheck.ladderCheckFlag == true && itemManeger.numOfItem[ladderDate] >= 1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameObject createLadder = Instantiate(ladderObject, ladderPosition,ladderRotetion);
                Vector3 pos = createLadder.transform.position;
                pos.y += 0.16f;
                if ((int)createLadder.transform.localEulerAngles.y == 0)
                {
                    pos.z -= 0.016f;
                }
                else if((int)createLadder.transform.localEulerAngles.y == 90)
                {
                    pos.x -= 0.016f;
                }
                else if ((int)createLadder.transform.localEulerAngles.y == 180)
                {
                    pos.z += 0.016f;
                }
                else if ((int)createLadder.transform.localEulerAngles.y == 270)
                {
                    pos.x += 0.016f;
                }
                createLadder.transform.position = pos;
                itemManeger.numOfItem[ladderDate] -= 1;
            }
        }
    }
}
