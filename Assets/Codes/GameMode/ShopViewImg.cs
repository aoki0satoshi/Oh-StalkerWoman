using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopViewImg : MonoBehaviour 
{
    SpriteRenderer MainSpriteRenderer;
    public Sprite[] shopViewImg = {};
    private int[] randomImgMath = { 0, 7 };


	void Start () 
    {
        this.MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        this.MainSpriteRenderer.sprite = this.shopViewImg[Random.Range(this.randomImgMath[0], this.randomImgMath[1])];
	}
}
