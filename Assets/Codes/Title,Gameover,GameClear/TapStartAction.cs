using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapStartAction : MonoBehaviour 
{
    private readonly float interval = 0.5f;

    void Start()
    {
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        while (true)
        {
            var renderComponent = GetComponent<Renderer>();
            renderComponent.enabled = !renderComponent.enabled;
            yield return new WaitForSeconds(this.interval);
        }
    }
}
