using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputWoman : MonoBehaviour 
{
    public GameObject gostopMeter;

    private bool inputCheck = false;
    private float touchStartPos;
    private float touchEndPos;
    private readonly float movePoint = 0.04f;
    private readonly float leftMovePoint = 50f;
    private readonly float rightMovePoint = 30f;
    private readonly float needOmazinai = 0.000001f;

	void Start () 
    {	
        this.gostopMeter = GameObject.Find("GoStopMeter");
        StartCoroutine("StopCheckWoman");
	}
    private IEnumerator StopCheckWoman()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(this.needOmazinai);
            //if（ 自販機が停止しているか && 入力をしていないか ）
            if (this.gostopMeter.transform.position.x > 0 && this.inputCheck == false)
            {
                //ドラッグ処理（押し込み）
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    this.touchStartPos = Input.mousePosition.x;
                }
                //ドラッグ処理（離した時）
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    this.touchEndPos = Input.mousePosition.x;
                    //if (押し込み > 離した時)（左へスワイプ）
                    if (this.touchStartPos > this.touchEndPos)
                    {
                        this.inputCheck = true;
                        StartCoroutine(MoveWoman(-this.movePoint , this.leftMovePoint));

                    }
                    //if (押し込み < 離した時)（右へスワイプ）
                    else if (this.touchStartPos < this.touchEndPos)
                    {
                        this.inputCheck = true;
                        StartCoroutine(MoveWoman(this.movePoint , this.rightMovePoint));
                    }
                }
            }
            //( 男にバレなかったか && 入力をしたか )
            if (this.gostopMeter.transform.position.z > 1 && this.inputCheck == true)
            {
                this.inputCheck = false;
                Vector3 woman = this.gameObject.transform.position;
                if (woman.x < 1.7f)
                {
                    StartCoroutine(MoveWoman(this.movePoint, this.leftMovePoint));
                }else{
                    StartCoroutine(MoveWoman(-this.movePoint, this.rightMovePoint));
                }
                yield return new WaitForSeconds(0.3f);
                //レイヤーを自販機より手前にする
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sortingLayerName = "woman";
            }
        }

    }
    private IEnumerator MoveWoman(float move,float backmove)
    {
        //レイヤーを自販機より奥にする
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Default";

        for (int i = 0; i < backmove; i++)
        {
            transform.Translate(move, 0, 0);
            yield return new WaitForSeconds(0.00001f);
        }
    }
}
