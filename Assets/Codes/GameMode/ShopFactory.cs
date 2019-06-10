using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFactory : MonoBehaviour 
{
    public GameObject gostopMeter;
    public GameObject leftShopObj;
    public GameObject rightShopObj;

    private readonly float sponeLeftShopWait = 7;
    private readonly float sponeRightShopWait = 10;
    private readonly float[] sponeLeftPosition = {-8, -3 };
    private readonly float[] sponeRightPosition = { 8, -14 };

	void Start () 
    {
        this.gostopMeter = GameObject.Find("GoStopMeter");
        //左側のショップ
        StartCoroutine(Spone(this.sponeLeftPosition[0], this.sponeLeftPosition[1], this.sponeLeftShopWait, this.leftShopObj)); 
        //右側のショップ
        StartCoroutine(Spone(this.sponeRightPosition[0], this.sponeRightPosition[1], this.sponeRightShopWait, this.rightShopObj));
	}

    IEnumerator Spone(float x,float y,float time,GameObject shop)
    {
        while (true)
        {

            yield return null;

            if (this.gostopMeter.transform.position.x < 1)
            {
                Instantiate(shop, new Vector3(x, y, 0), Quaternion.identity);
                yield return new WaitForSeconds(time);
            }else{
                yield return new WaitForSeconds(time);
            }
        }
    }
}
