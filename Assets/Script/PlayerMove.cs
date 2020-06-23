using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float walkSpeed = 1.0f;
    [SerializeField] float rotateSpeed = 90f;
    //Cameraが回転するスピード
    [SerializeField] float rotate_speed = 3;
    [System.NonSerialized]public static bool moveFlag;

    public bool camera2Flag = false;

    // Start is called before the first frame update
    void Start()
    {
        moveFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveFlag == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * -walkSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                if(camera2Flag == true)
                {
                    transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (camera2Flag == true)
                {
                    transform.Rotate(new Vector3(0, -rotateSpeed, 0) * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
                }
            }

            if(camera2Flag == false)
            {
                transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * rotate_speed, 0);
            }
        }
    }
}
