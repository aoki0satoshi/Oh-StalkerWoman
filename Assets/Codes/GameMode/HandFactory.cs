using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFactory : MonoBehaviour 
{
    public GameObject gostopMeter;
    public GameObject handObj;

    public bool checkHandAdd = true;
    private readonly float[] sponePoint = { 1.65f, 4.5f };

	void Start () 
    {
        
        StartCoroutine("SponeLeftRight");
	}
    IEnumerator SponeLeftRight()
    {
        while (true)
        {
            yield return null;

            //if（ 自販機が停止しているか && 今、手は出ていないか ）
            if (this.gostopMeter.transform.position.z < 0 && this.checkHandAdd == true)
            {
                Instantiate(this.handObj, new Vector3(sponePoint[0], sponePoint[1], 0), Quaternion.identity);
                this.checkHandAdd = false;
            }else if (this.gostopMeter.transform.position.z > -1 && this.gostopMeter.transform.position.z < 1 && this.checkHandAdd == false)
            {
                this.checkHandAdd = true;
            }

        }

    }
}
