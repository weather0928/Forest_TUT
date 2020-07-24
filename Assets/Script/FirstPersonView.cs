using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonView : MonoBehaviour
{
    [SerializeField] float walkSpeed = 1.0f;
    [SerializeField] float rotateSpeed = 90f;
    //Cameraが回転するスピード
    [SerializeField] float rotate_speed = 3;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject createItemUI;
    [System.NonSerialized] public static bool moveFlag;
    [SerializeField] AudioSource walkAudioSoure;

    //X軸の角度を制限するための変数
    [SerializeField] private float angleUp = 30f;
    [SerializeField] private float angleDown = -30f;


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

                if (Input.GetKey(KeyCode.W))
                {
                    key_W = true;
                    if (walkAudioSoure.isPlaying == false)
                    {
                        walkAudioSoure.Play();
                        //playerAni.SetBool("Run", true);
                    }
                }
                else
                {
                    key_W = false;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    key_S = true;
                    if (walkAudioSoure.isPlaying == false)
                    {
                        walkAudioSoure.Play();
                    }
                }
                else
                {
                    key_S = false;

                }

                if (Input.GetKey(KeyCode.D))
                {
                    if (camera2Flag == true)
                    {
                        transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
                    }
                    else
                    {
                        key_D = true;
                        if (walkAudioSoure.isPlaying == false)
                        {
                            walkAudioSoure.Play();
                        }
                    }
                }
                else
                {
                    if (camera2Flag == false)
                    {
                        key_D = false;
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
                        key_A = true;
                        if (walkAudioSoure.isPlaying == false)
                        {
                            walkAudioSoure.Play();
                        }
                    }
                }
                else
                {
                    if (camera2Flag == false)
                    {
                        key_A = false;
                    }
                }

                if (key_W == false && key_A == false && key_S == false && key_D == false)
                {
                    walkAudioSoure.Stop();
                }

                if (camera2Flag == false)
                {
                    transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * rotate_speed, 0);
                    //Cameraの角度にマウスからとった値を入れる
                    transform.eulerAngles -= new Vector3(Input.GetAxis("Mouse Y") * rotate_speed, 0, 0);

                    //X軸の角度
                    float angleX = transform.eulerAngles.x;
                    //X軸の値を180度超えたら360引くことで制限しやすくする
                    if (angleX >= 180)
                    {
                        angleX = angleX - 360;
                    }
                    //Mathf.Clamp(値、最小値、最大値）でX軸の値を制限する
                    transform.eulerAngles = new Vector3(
                        Mathf.Clamp(angleX, angleDown, angleUp),
                        transform.eulerAngles.y,
                        transform.eulerAngles.z
                    );
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && CreateItem.craftFlag == false)
            {
                gameUI.SetActive(!gameUI.activeSelf);
                createItemUI.SetActive(!createItemUI.activeSelf);
                moveFlag = !moveFlag;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3();

        if (key_W == true || key_S == true)
        {
            if (key_W == true)
            {
                if (key_A == true || key_D == true)
                {
                    if (key_A == true)
                    {
                        direction += transform.forward * walkSpeed;
                        direction += -transform.right * walkSpeed;
                    }
                    if (key_D == true)
                    {
                        direction += transform.forward * walkSpeed;
                        direction += transform.right * walkSpeed;
                    }
                    direction = direction / Mathf.Sqrt(2.0f);
                }
                else if (key_A == false && key_D == false)
                {
                    direction += transform.forward * walkSpeed;
                }
            }
            if (key_S == true)
            {
                if (key_A == true || key_D == true)
                {
                    if (key_A == true)
                    {
                        direction += -transform.forward * walkSpeed;
                        direction += -transform.right * walkSpeed;
                    }
                    if (key_D == true)
                    {
                        direction += -transform.forward * walkSpeed;
                        direction += transform.right * walkSpeed;
                    }
                    direction = direction / Mathf.Sqrt(2.0f);
                }
                else if (key_A == false && key_D == false)
                {
                    direction += -transform.forward * walkSpeed;
                }
            }
        }
        else if (key_W == false && key_S == false)
        {
            if (key_A == true)
            {
                direction += -transform.right * walkSpeed;
            }
            if (key_D == true)
            {
                direction += transform.right * walkSpeed;
            }
        }


        direction.y = Physics.gravity.y;
        this.GetComponent<Rigidbody>().velocity = direction;
    }
}
