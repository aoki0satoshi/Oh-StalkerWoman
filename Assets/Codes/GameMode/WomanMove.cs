using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanMove : MonoBehaviour 
{
    public GameObject gostopMeter;
    private readonly float checknumber = 1;
    private readonly float walktiming = 0.3f;
    private readonly float walkstates = 0.5f;

	void Start () 
    {

        this.gostopMeter = GameObject.Find("GoStopMeter");
        StartCoroutine("Move");
	}
	private IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            if (this.gostopMeter.transform.position.x < this.checknumber)
            {
                yield return new WaitForSeconds(this.walktiming);
                GetComponent<Rigidbody2D>().velocity = transform.up.normalized * this.walkstates;
            }
        }
    }
}
