using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaser : MonoBehaviour
{
    //商人通常時移動系に使う変数
    [SerializeField]private Transform[] points;　//商人が通常時に目指す座標を入れる
    private int destPoint = 0;

    //AIで動かすための変数
    private NavMeshAgent agent;

    //ターゲット（プレイヤー）を追うために使う変数
    [SerializeField] GameObject target;
    [System.NonSerialized]public static bool inArea = false;
    [SerializeField] float chaspeed = 0.05f;
    [SerializeField] Color origColor;
    [System.NonSerialized]public static bool chaseSwitchFlag = false;
    [SerializeField]private float chaseStopTime;
    private float chaseSecond = 0f;

    //音が鳴らなくなった時に使う変数
    [SerializeField] float soundStopTime;
    private float soundSecond = 0f;

    //罠にかかった時に使う変数など
    private float staleStopTime;
    private float staleSecond = 0f;
    private bool staleFlag = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }

        if (target.activeInHierarchy == false) //ターゲットがいなくなったときの処理（制作が進んだらゲームオーバー時に代わる）
        {
            GetComponent<Renderer>().material.color = origColor;
        }

        if (inArea == false && SoundJudge.soundJudge == true) //商人の範囲内で音がなった時
        {
            agent.destination = SoundJudge.soundPoint;
            GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 0f / 255f, 255f / 255f);
            Debug.Log(inArea);

            if (SoundJudge.soundFlag == false)
            {
                soundSecond += Time.deltaTime;
                if (soundSecond >= soundStopTime)
                {
                    SoundJudge.soundJudge = false;
                    soundSecond = 0f;
                    GetComponent<Renderer>().material.color = origColor;
                    GotoNextPoint();
                }
            }
        }

        if (inArea == true && target.activeInHierarchy == true && chaseSwitchFlag == false)　//エリア内にいて、かつ「生存」状態の時
        {
            if(Physics.Linecast(transform.position + Vector3.up, target.transform.position + Vector3.up) == false)
            {
                agent.destination = target.transform.position;
                EneChasing();
                GetComponent<Renderer>().material.color = new Color(255f / 255f, 65f / 255f, 26f / 255f, 255f / 255f);
                chaseSecond = 0f;
            }
            else if(Physics.Linecast(transform.position + Vector3.up, target.transform.position + Vector3.up) == true)
            {
                chaseSecond += Time.deltaTime;
                GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 0f / 255f, 255f / 255f);
                if (chaseSecond >= chaseStopTime)
                {
                    chaseSwitchFlag = true;
                    chaseSecond = 0f;
                }
            }
        }
        else if(inArea == true && chaseSwitchFlag == true)
        {
            inArea = false;
            chaseSwitchFlag = false;
            GetComponent<Renderer>().material.color = origColor;
            GotoNextPoint();
            chaseSwitchFlag = false;
        }
    }

    private void OnCollisionEnter(Collision other) //プレイヤーやアイテムに触れたときの処理（後々はゲームオーバー処理などに代わる）
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
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