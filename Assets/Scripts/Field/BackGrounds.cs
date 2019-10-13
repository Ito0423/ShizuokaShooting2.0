using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounds : MonoBehaviour
{
    //ステージが移動するスピード
     public float speed = 0.1f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
        float x = Mathf.Repeat(Time.time * speed, 1);

        // Yの値がずれていくオフセットを作成S

        Vector2 offset = new Vector2(-x, 0);

        // マテリアルにオフセットを設定する
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
