using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour 
{
    private float positionStatus = 0.12f;
    private readonly float smallrate = 0.002f;
    private readonly float[] policeSponePosition = { -0.0325f, -0.04f };

	void Start () 
    {
        StartCoroutine("Move");
	}

    IEnumerator Move()
    {
        //出てくるまでのディレイ
        yield return new WaitForSeconds(0.01f);

        //斜めに女のいた場所へ移動させる
        for (int i = 0; i < 50; i++)
        {
            this.transform.localScale = new Vector3(this.positionStatus,this.positionStatus,this.positionStatus);
            this.positionStatus = this.positionStatus + this.smallrate;

            this.transform.position += new Vector3(policeSponePosition[0], policeSponePosition[1], 0);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
