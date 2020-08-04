using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CreateCameraChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(CreateItem.craftFlag == true)
       {
            this.gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 100;
       }
       else
       {
            this.gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 0;
       }
    }
}
