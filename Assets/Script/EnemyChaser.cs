using System.Collections;
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
    [System.NonSerialized]public static bool chaseFlag;
    [SerializeField] float chaspeed = 0.05f;
    [System.NonSerialized]public static bool chaseSwitchFlag;
    [SerializeField]private float chaseStopTime;
    private float chaseSecond = 0f;
    private bool inPursuitFlag;

    bool obstacleJudgFlag = false;

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
    private bool staleFlag;

    [SerializeField] AudioSource walkAudioSourece;
    [SerializeField] AudioSource enemySeAudioSource;

    [SerializeField] LayerMask objectLayer;
    [SerializeField] Transform enemyCamera;

    //ゲームオーバー画面に行くためのもの
    private bool gameOverFlag;

    void Start()
    {
        chaseFlag = false;
        chaseSwitchFlag = false;
        staleFlag = false;
        soundHeardFlag = false;
        inPursuitFlag = false;
        gameOverFlag = false;
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

            if (chaseFlag == false && SoundJudge.soundJudge == true) //商人の範囲内で音がなった時
            {
                agent.destination = SoundJudge.soundPoint;
                GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 0f / 255f, 255f / 255f);
                if (soundHeardFlag == true)
                {
                    enemySeAudioSource.PlayOneShot(soundHeardVoice);
                    soundHeardFlag = false;
                }

                if (SoundJudge.soundFlag == false)
                {
                    soundSecond += Time.deltaTime;
                    if (soundSecond >= soundStopTime)
                    {
                        SoundJudge.soundJudge = false;
                        soundSecond = 0f;
                        enemySeAudioSource.PlayOneShot(blameVoice);
                        GotoNextPoint();
                    }
                }
            }
            if (chaseFlag == true && chaseSwitchFlag == false) //プレイヤーが商人に見つかった時
            {
                obstacleJudgFlag = ObstacleJudg();
                Debug.DrawLine(enemyCamera.position,target.transform.position + (Vector3.up * 0.1f));
                if (obstacleJudgFlag == false && inPursuitFlag == false)
                {
                    enemySeAudioSource.PlayOneShot(foundPlayerVoice);
                    EneChasing();
                    inPursuitFlag = true;
                }
                else if (obstacleJudgFlag == false && inPursuitFlag == true)
                {
                    EneChasing();
                }
                else if (obstacleJudgFlag == true)
                {
                    chaseSecond += Time.deltaTime;
                    inPursuitFlag = false;
                    if (chaseSecond >= chaseStopTime)
                    {
                        chaseSwitchFlag = true;
                        chaseSecond = 0f;
                    }
                }
            }
            else if (chaseFlag == true && chaseSwitchFlag == true)
            {
                chaseFlag = false;
                GotoNextPoint();
                chaseSwitchFlag = false;
            }
            if (staleFlag == true)
            {
                staleSecond += Time.deltaTime;
                if(staleSecond >= staleStopTime)
                {
                    agent.isStopped = false;
                    staleFlag = false;
                }
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
            GotoNextPoint();
        }
        if(other.gameObject.tag == "StaleItem")
        {
            agent.isStopped = true; 
            staleStopTime = other.gameObject.GetComponent<EnemyStaleItem>().staleTime();
            staleSecond = 0f;
            staleFlag = true;
            Destroy(other.gameObject);
        }
    }

    void GotoNextPoint() //通常時に移動する場所を決める処理
    {
        if (points.Length == 0)
            return;
        walkAudioSourece.pitch = 1;
        walkAudioSourece.Play();
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    public void EneChasing() //ターゲット（プレイヤー）を追う処理
    {
        agent.destination = target.transform.position;
        transform.position += transform.forward * chaspeed;
        walkAudioSourece.pitch = 1.5f;
        chaseSecond = 0f;
    }

    bool ObstacleJudg()
    {
        bool flg;
        flg = Physics.Linecast(enemyCamera.position, target.transform.position + (Vector3.up * 0.1f), objectLayer);
        Debug.Log(flg);
        return flg;
    }
}