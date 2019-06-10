using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    public GameObject gostopMeter;

    private readonly float directionRightpone = 180.0f;
    private readonly float stopFirstTime = 0.2f;
    private readonly float moveDistance = 0.01f;
    private readonly float stayTimeHand = 0.01f;
    private readonly float[] checkMeterPositionStop = { 1, -1 };
    private readonly int checkMeterPositionLeftRight = 3;
    private readonly int backToMove = -1;

	void Start () 
    {
        this.gostopMeter = GameObject.Find("GoStopMeter");

        //if(右側の自販機で停止した場合)else(左側の自販機で停止した場合)
        if (this.gostopMeter.transform.position.y > this.checkMeterPositionLeftRight)
        {
            this.gameObject.transform.Rotate(0, this.directionRightpone, 0);
        }

        StartCoroutine("HandMoveSet",this.moveDistance);
	}

    void Update()
    {
        //if(動き出すときに削除する)
        if (this.gostopMeter.transform.position.x < this.checkMeterPositionStop[0] && this.gostopMeter.transform.position.x > this.checkMeterPositionStop[1])
        {
            Destroy(this.gameObject);
        }
	}

    private IEnumerator HandMoveSet(float move)
    {
        yield return new WaitForSeconds(this.stopFirstTime);

        //if(右側の自販機で停止した場合)else(左側の自販機で停止した場合)
        if (this.gostopMeter.transform.position.y < this.checkMeterPositionLeftRight)
        {
            move = move * this.backToMove;
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                this.transform.position += new Vector3(move, 0, 0);
                yield return new WaitForSeconds(this.stayTimeHand);
            }
            move = move * this.backToMove;
        }
    }
}
