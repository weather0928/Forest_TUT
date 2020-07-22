﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl2 : MonoBehaviour
{
    //X軸の角度を制限するための変数
    [SerializeField]float angleUp = 60f;
    [SerializeField]float angleDown = -60f;

    [SerializeField] GameObject normalCamera;
    //Main CameraをInspectorで入れる
    [SerializeField] Camera cam;

    //Cameraが回転するスピード
    [SerializeField] float rotate_speed = 3;
    //Axisの位置を指定する変数
    [SerializeField] Vector3 axisPos;

    void Start()
    {
        //CameraのAxisに相対的な位置をlocalPositionで指定
        //cam.transform.localPosition = new Vector3(0, 0, -3);
        //CameraとAxisの向きを最初だけそろえる
        cam.transform.localRotation = transform.rotation;
    }

    void Update()
    {

        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        transform.position = normalCamera.transform.position;
        if(CreateItem.createStartFlag == true)
        {
            transform.rotation = normalCamera.transform.rotation;
        }

        //Cameraの角度にマウスからとった値を入れる
        transform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse Y") * rotate_speed,
            Input.GetAxis("Mouse X") * rotate_speed
            , 0);

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
