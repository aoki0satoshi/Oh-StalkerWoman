using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMove : MonoBehaviour 
{
    public GameObject gostopMeter;

    private readonly float[] checkShopPosition = { 3.1f, 3.2f };
    private int layerOrder = 100000;
    private int randomMath;


    private readonly float moveLeftSpeedX = 0.018f;
    private readonly float minMoveLeftSpeedX = 0.000004f;
    private readonly float moveLeftSpeedY = 0.015f;
    private readonly float minMoveLeftSpeedY = -0.000004f;
    private readonly float leftSmallRate = -0.0013f;
    private readonly float minLeftSmallRate = 0.0000019f;
    private readonly float leftPositionStatus = 1.0f;
    private readonly int stopLeftShopPosition = 2;
    private readonly int[] randomLeftShopCheckMath = { 0, 15 };


    private readonly float moveRightSpeedX = -0.015f;
    private readonly float minMoveRightSpeedX = 0.0000189f;
    private readonly float moveRightSpeedY = 0.06f;
    private readonly float minMoveRightSpeedY = 0.00009f;
    private readonly float rightSmallRate = -0.0056f;
    private readonly float minRightSmallRate = -0.0000078f;
    private readonly float rightPositionStatus = 2.0f;
    private readonly int stopRightShopPosition = 4;
    private readonly int[] randomRightShopCheckMath = { 0, 15 };



    void Start()
    {
        this.gostopMeter = GameObject.Find("GoStopMeter");
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = this.layerOrder;

        //if(左か)else(右か)
        if (this.gameObject.transform.position.x < 0)
        {
            StartCoroutine(ShopScrol(this.moveLeftSpeedX,
                                     this.minMoveLeftSpeedX,
                                     this.moveLeftSpeedY,
                                     this.minMoveLeftSpeedY,
                                     this.leftSmallRate,
                                     this.minLeftSmallRate,
                                     this.leftPositionStatus,
                                     this.randomLeftShopCheckMath[0],
                                     this.randomLeftShopCheckMath[1],
                                     this.stopLeftShopPosition
                                    ));
        }
        else
        {
            StartCoroutine(ShopScrol(this.moveRightSpeedX,
                                     this.minMoveRightSpeedX,
                                     this.moveRightSpeedY,
                                     this.minMoveRightSpeedY,
                                     this.rightSmallRate,
                                     this.minRightSmallRate,
                                     this.rightPositionStatus,
                                     this.randomRightShopCheckMath[0],
                                     this.randomRightShopCheckMath[1],
                                     this.stopRightShopPosition
                                    ));
        }


	}

    private IEnumerator ShopScrol(float X,
                          float minX,
                          float Y,
                          float minY,
                          float SR,
                          float minSR,
                          float PS,
                          int RM1,
                          int RM2,
                          int SP
                         )
    {
        while (true)
        {
            yield return null;

            if (this.gostopMeter.transform.position.x < 1)
            {
                X = X + minX;
                Y = Y - minY;
                SR = SR - minSR;

                this.layerOrder--;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = this.layerOrder;

                this.transform.position += new Vector3(X, Y, 0);
                this.transform.localScale = new Vector3(PS,PS,PS);
                PS = PS + SR;

                if (this.transform.position.y >= this.checkShopPosition[0] && this.transform.position.y <= this.checkShopPosition[1])
                {
                    this.randomMath = Random.Range(RM1, RM2);
                    if (randomMath == RM1)
                    {
                        this.gostopMeter.transform.position = new Vector3(1, SP, -1);
                    }
                }

                if (this.transform.localScale.x <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
