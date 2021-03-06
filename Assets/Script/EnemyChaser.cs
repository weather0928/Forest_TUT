﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyChaser : MonoBehaviour
{
    //商人通常時移動系に使う変数
    [SerializeField]private Transform[] points;　//商人が通常時に目指す座標を入れる
    private int destPoint = 0;

    //AIで動かすための変数
    private NavMeshAgent agent;

    //商人がターゲットを見つけたときの音
    [SerializeField] AudioClip foundPlayerVoice;

    //ターゲット（プレイヤー）を追うために使う変数
    [SerializeField] GameObject target;
    [System.NonSerialized]public static bool inArea = false;
    [SerializeField] float chaspeed = 0.05f;
    [SerializeField] Color origColor;
    [System.NonSerialized]public static bool chaseSwitchFlag = false;
    [SerializeField]private float chaseStopTime;
    private float chaseSecond = 0f;
    private bool inPursuitFlag;

    //商人から音を出すために使うもの
    AudioSource audioSource;

    //音が鳴った時に使う変数
    [SerializeField]AudioClip soundHeardVoice;
    [System.NonSerialized] public static bool soundHeardFlag;

    //音が鳴らなくなった時に使う変数
    [SerializeField] float soundStopTime;
    private float soundSecond = 0f;

    //商人が気のせいだと感じたときに出す音
    [SerializeField] AudioClip blameVoice;

    //罠にかかった時に使う変数など
    private float staleStopTime;
    private float staleSecond = 0f;
    private bool staleFlag = false;

    //ゲームオーバー画面に行くためのもの
    private bool gameOverFlag;

    void Start()
    {
        soundHeardFlag = false;
        inPursuitFlag = false;
        gameOverFlag = false;
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        else
        {
            if (agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }

            if (gameOverFlag == true) //ゲームオーバー処理
            {
                SceneManager.LoadScene("GameOver");
            }

            if (inArea == false && SoundJudge.soundJudge == true) //商人の範囲内で音がなった時
            {
                agent.destination = SoundJudge.soundPoint;
                GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 0f / 255f, 255f / 255f);
                //Debug.Log(inArea);
                if (soundHeardFlag == true)
                {
                    audioSource.PlayOneShot(soundHeardVoice);
                    soundHeardFlag = false;
                }

                if (SoundJudge.soundFlag == false)
                {
                    soundSecond += Time.deltaTime;
                    if (soundSecond >= soundStopTime)
                    {
                        SoundJudge.soundJudge = false;
                        soundSecond = 0f;
                        GetComponent<Renderer>().material.color = origColor;
                        audioSource.PlayOneShot(blameVoice);
                        GotoNextPoint();
                    }
                }
            }

            if (inArea == true && target.activeInHierarchy == true && chaseSwitchFlag == false) //エリア内にいて、かつ「生存」状態の時
            {
                if (Physics.Linecast(transform.position + Vector3.up, target.transform.position + Vector3.up) == false && inPursuitFlag == false)
                {
                    agent.destination = target.transform.position;
                    audioSource.PlayOneShot(foundPlayerVoice);
                    EneChasing();
                    GetComponent<Renderer>().material.color = new Color(255f / 255f, 65f / 255f, 26f / 255f, 255f / 255f);
                    chaseSecond = 0f;
                    inPursuitFlag = true;
                }
                else if (Physics.Linecast(transform.position + Vector3.up, target.transform.position + Vector3.up) == false && inPursuitFlag == true)
                {
                    agent.destination = target.transform.position;
                    EneChasing();
                    GetComponent<Renderer>().material.color = new Color(255f / 255f, 65f / 255f, 26f / 255f, 255f / 255f);
                    chaseSecond = 0f;
                }
                else if (Physics.Linecast(transform.position + Vector3.up, target.transform.position + Vector3.up) == true)
                {
                    chaseSecond += Time.deltaTime;
                    GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 0f / 255f, 255f / 255f);
                    inPursuitFlag = false;
                    if (chaseSecond >= chaseStopTime)
                    {
                        chaseSwitchFlag = true;
                        chaseSecond = 0f;
                    }
                }
            }
            else if (inArea == true && chaseSwitchFlag == true)
            {
                inArea = false;
                GetComponent<Renderer>().material.color = origColor;
                GotoNextPoint();
                chaseSwitchFlag = false;
            }
        }
    }
        

    private void OnCollisionEnter(Collision other) //プレイヤーやアイテムに触れたときの処理（後々はゲームオーバー処理などに代わる）
    {
        if(other.gameObject.tag == "Player")
        {
            gameOverFlag = true;
        }
        if(other.gameObject.tag == "SoundItem")
        {
            Destroy(other.gameObject);
            SoundJudge.soundFlag = false;
            SoundJudge.soundJudge = false;
            GetComponent<Renderer>().material.color = origColor;
            GotoNextPoint();
        }
        if(other.gameObject.tag == "StaleItem")
        {
            GetComponent<NavMeshAgent>().isStopped = true; 
            staleStopTime = other.gameObject.GetComponent<EnemyStaleItem>().stopTime;
            staleFlag = true;
            Destroy(other.gameObject);
        }
    }

    void GotoNextPoint() //通常時に移動する場所を決める処理
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    public void EneChasing() //ターゲット（プレイヤー）を追う処理
    {
        transform.position += transform.forward * chaspeed;
    }
}