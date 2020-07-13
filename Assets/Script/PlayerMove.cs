using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float walkSpeed = 1.0f;
    [SerializeField] float rotateSpeed = 90f;
    //Cameraが回転するスピード
    [SerializeField] float rotate_speed = 3;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject createItemUI;
    [System.NonSerialized]public static bool moveFlag;

    private bool key_W;
    private bool key_A;
    private bool key_S;
    private bool key_D;

    /*float x;
    float z;*/

    public bool camera2Flag = false;

    GameObject soundManeger;

    // Start is called before the first frame update
    void Start()
    {
        key_W = false;
        key_A = false;
        key_S = false;
        key_D = false;
        moveFlag = true;
        createItemUI.SetActive(false);
        soundManeger = GameObject.Find("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        else
        {
            if (moveFlag == true)
            {
                /*
                if (Input.GetKeyDown(KeyCode.W))
                {
                    key_W = true;
                }
                else if(Input.GetKeyUp(KeyCode.W))
                {
                    key_W = false;
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    key_S = true;
                }
                else if(Input.GetKeyUp(KeyCode.S))
                {
                    key_S = false;
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (camera2Flag == true)
                    {
                        transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
                    }
                    else
                    {
                        key_D = true;
                    }
                }
                else if(Input.GetKeyDown(KeyCode.D))
                {
                    if(camera2Flag == false)
                    {
                        key_D = false;
                    }
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (camera2Flag == true)
                    {
                        transform.Rotate(new Vector3(0, -rotateSpeed, 0) * Time.deltaTime);
                    }
                    else
                    {
                        key_A = true;
                    }
                }
                else if (Input.GetKeyUp(KeyCode.A))
                {
                    if(camera2Flag == false)
                    {
                        key_A = false;
                    }
                }*/

                if (camera2Flag == false)
                {
                    transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * rotate_speed, 0);
                }
            }

            if (Input.GetKeyDown("r") && CreateItem.craftFlag == false)
            {
                gameUI.SetActive(!gameUI.activeSelf);
                createItemUI.SetActive(!createItemUI.activeSelf);
                moveFlag = !moveFlag;
            }
        }
        
    }

    private void FixedUpdate()
    {
        float z = Input.GetAxis("Vertical") * walkSpeed;
        float x = Input.GetAxis("Horizontal") * walkSpeed;

        this.GetComponent<Rigidbody>().AddForce(x, 0, z);
    }
}
