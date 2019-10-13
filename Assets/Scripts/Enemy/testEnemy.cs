using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class testEnemy : Enemy
{
    [SerializeField]
    RectTransform rectTran;
    float x;                       //三角関数の数値設定
    public float speedVerticalMove = 3f;              //スピードの数値設
    public float radius = 0.2f;
    public float WaitSecondsVertical = 0;
    private float sankakuTime;


    private void Update()
    {
        WaitSecondsVertical -= Time.deltaTime;
        //三角関数による縦移動
        if (WaitSecondsVertical <= 0)
        {
            sankakuTime += Time.deltaTime;
            x = radius * Mathf.Sin(sankakuTime * speedVerticalMove);  //三角関if数による動きの設定。                                       
            transform.position = new Vector3(transform.position.x, x + transform.position.y, transform.position.z);
        }
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(WaitForSecondsStart);

        spaceship = GetComponent<Spaceship>();
        //ステージ数に応じて敵を強化
        if ((Emitter.stageCount - 1) / 3 >= 1)
        {
            hp += (hp * ((Emitter.stageCount - 1) / 3));
            maneyPoint += (maneyPoint * ((Emitter.stageCount - 1) / 3));
            spaceship.m_shotDelay -= spaceship.m_shotDelay / 5;
        }

        // ローカル座標のY軸のマイナス方向に移動する
        spaceship.Move(transform.right * +1.0f);

        //弾を打てるかチェックする
        if (spaceship.m_canShot == false)
        {
            yield break;
        }
        //一発目に打つ玉にディレイをかける
        if (firstShotCheck == false)
        {
            yield return new WaitForSeconds(firstShotWaitSecond);
            firstShotCheck = true;
        }
        while (true)
        {
            // 子要素を全て取得する
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                spaceship.shotEnemy(shotPosition);
            }
            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.m_shotDelay);
        }
    }
}