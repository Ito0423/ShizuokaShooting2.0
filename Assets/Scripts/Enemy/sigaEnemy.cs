using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sigaEnemy : Enemy
{
    public float rotateTime = 4;
    // Start is called before the first frame update
    private void Update()
    {
        //オブジェクトをくるくる回す
        this.transform.Rotate(new Vector3(0,0,1), rotateTime);
    }

    IEnumerator Start()
    {
        //this.transform.DORotate(endValue: new Vector3(0f, 0f, 360f), duration: 2.0f, mode: RotateMode.FastBeyond360).SetLoops(-1);

        spaceship = GetComponent<Spaceship>();

        // ローカル座標のY軸のマイナス方向に移動する
        spaceship.Move(transform.right * +1);

        //ステージ数に応じて強化する
        /*if ((Emitter.stageCount - 1) / 3 >= 1)
        {
            hp += (hp * ((Emitter.stageCount - 1) / 3));
            maneyPoint += (maneyPoint * ((Emitter.stageCount - 1) / 3));
            spaceship.m_shotDelay -= spaceship.m_shotDelay / 5;
        }*/
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
