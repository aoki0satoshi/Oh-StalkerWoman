using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour 
{
    private Camera cam;

    // 画像のサイズ
    private float width = 640f;
    private float height = 960f;
    private float pixelPerUnit = 100f;

    void Awake()
    {
        float aspect = (float)Screen.height / (float)Screen.width;
        float bgAcpect = this.height / this.width;

        this.cam = GetComponent<Camera>();

        // カメラのorthographicSizeを設定
        this.cam.orthographicSize = (this.height / 2f / this.pixelPerUnit);


        if (bgAcpect > aspect)
        {
            // 倍率
            float bgScale = this.height / Screen.height;

            // viewport rectの幅
            float camWidth = this.width / (Screen.width * bgScale);

            // viewportRectを設定
            this.cam.rect = new Rect((1f - camWidth) / 2f, 0f, camWidth, 1f);

        }
        else
        {
            // 倍率
            float bgScale = this.width / Screen.width;

            // viewport rectの幅
            float camHeight = this.height / (Screen.height * bgScale);

            // viewportRectを設定
            this.cam.rect = new Rect(0f, (1f - camHeight) / 2f, 1f, camHeight);
        }
    }
}
