using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManMove : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;

    public AudioSource ohPrettyWoman;
    public GameObject gostopMeter;
    public GameObject womanChecker;
    public GameObject policeObj;
    public Sprite mainImg;
    public Sprite backImg;

    private bool backNawPlay = false;
    private bool outCheck = true;
    private float audioTime = 3.0f;
    private readonly float walktiming = 0.8f;
    private readonly float walkstates = 0.8f;
    private readonly float[] startPosition = { 1, 2 };
    private readonly int backSpeed = 9;

    void Start()
    {
        //曲を流す
        this.ohPrettyWoman = this.GetComponent<AudioSource>();
        this.ohPrettyWoman.Play();

        this.MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        this.gostopMeter = GameObject.Find("GoStopMeter");

        StartCoroutine("Move");
        StartCoroutine("ClearCheck");

    }

    void Update()
    {
        //if(自販機が横にあるか && 今振り向いている最中ではないか)
        if (this.gostopMeter.transform.position.x > 0 && this.backNawPlay == false)
        {
            StartCoroutine("BackCheck");
            //曲の停止
            this.audioTime = this.ohPrettyWoman.time;
            this.ohPrettyWoman.Stop();

            this.backNawPlay = true;
        }
        //if(歩いている最中)
        if (this.gostopMeter.transform.position.x < 1)
        {
            this.backNawPlay = false;
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            //if(歩いている最中か)
            if (this.gostopMeter.transform.position.x < 1)
            {
                //歩く際の上下
                yield return new WaitForSeconds(this.walktiming);
                GetComponent<Rigidbody2D>().velocity = transform.up.normalized * this.walkstates;
            }
            else
            {
                //歩いていない時なので止める
                GetComponent<Rigidbody2D>().velocity = transform.up.normalized * 0;
            }
        }
    }

    IEnumerator BackCheck()
    {
        //隠れる時間
        yield return new WaitForSeconds(1.0f);

        yield return this.StartCoroutine(ForMove(90, this.backSpeed));

        //画像を後ろ姿に帰る
        this.MainSpriteRenderer.sprite = this.backImg;

        yield return this.StartCoroutine(ForMove(45, this.backSpeed));

        //隠れているかどうかの確認
        if (this.gostopMeter.transform.position.y > 3)
        {
            if (this.womanChecker.transform.position.x < 1.9)
            {
                Debug.Log("right");
                this.outCheck = false;
            }
        }
        else if (this.gostopMeter.transform.position.y > 0)
        {
            if (this.womanChecker.transform.position.x > 1.5)
            {
                Debug.Log("left");
                this.outCheck = false;
            }
        }

        yield return this.StartCoroutine(ForMove(45, this.backSpeed));

        yield return new WaitForSeconds(1f);

        //警察へ通報
        if (this.outCheck == false)
        {
            Instantiate(this.policeObj, new Vector3(3f, 5.6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("GameOver");
        }

        yield return this.StartCoroutine(ForMove(90, this.backSpeed));

        //画像を前画像に変える
        this.MainSpriteRenderer.sprite = this.mainImg;

        yield return this.StartCoroutine(ForMove(90, this.backSpeed));

        this.gostopMeter.transform.position = new Vector3(this.startPosition[0], 0, this.startPosition[1]);
        yield return new WaitForSeconds(1.3f);
        this.gostopMeter.transform.position = new Vector3(0, 0, 0);

        //曲を流す
        this.ohPrettyWoman = this.GetComponent<AudioSource>();
        this.ohPrettyWoman.time = this.audioTime;
        this.ohPrettyWoman.Play();
    }


    IEnumerator ClearCheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            //終了判定 if(クリアタイム && 振り向き中でない)
            if (this.ohPrettyWoman.time >= 57.0f && this.gostopMeter.transform.position.x < 1)
            {
                GetComponent<Rigidbody2D>().velocity = transform.up.normalized * 0;
                this.backNawPlay = true;
                this.gostopMeter.transform.position = new Vector3(1,0,2);

                //画面外へ移動
                for (int i = 0; i < 140; i++)
                {
                    this.transform.position += new Vector3(0.05f, 0, 0);
                    yield return new WaitForSeconds(0.01f);
                }

                SceneManager.LoadScene("GameClear");
            }
        }

    }


    //振り向きの角度調整
    private IEnumerator ForMove(int count,int BS)
    {
        for (int i = 0; i < count; i++)
        {
            transform.Rotate(new Vector3(0, 1, 0));
            if (i % BS == 0)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
