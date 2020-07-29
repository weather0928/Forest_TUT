using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    //X軸の角度を制限するための変数
    [SerializeField]private float angleUp = 30f;
    [SerializeField]private float angleDown = -30f;

    //Cameraが回転するスピード
    [SerializeField] float rotate_speed = 3;

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        else
        {
            if (PlayerMove.moveFlag == true && Input.GetMouseButton(1))
            {
                var angle = transform.eulerAngles;
                //Cameraの角度にマウスからとった値を入れる
                angle -= new Vector3(Input.GetAxis("Mouse Y") * rotate_speed, 0, 0);

                //X軸の角度
                float angleX = angle.x;
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
    }
}
