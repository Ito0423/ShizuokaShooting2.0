using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//enemyクラスを継承
public class Boss : Enemy
{
    //三角関数の数値設定
    float x;
    //スピードの数値設定
    public float speedVerticalMove = 3.0f;             
    //三角関数大きさ
    public float radius = 0.2f;
    //縦に動く時間
    public float WaitSecondsVertical = 0;
    //動作の時間
    private float sankakuTime;

    private void Update()
    {

        WaitSecondsVertical -= Time.deltaTime;
        //三角関数により上下に繰り返し運動させる
        if (WaitSecondsVertical <= 0)
        {
            sankakuTime += Time.deltaTime;
            x = radius * Mathf.Sin(sankakuTime * speedVerticalMove);  //三角関if数による動きの設定。                                       
            transform.position = new Vector3(transform.position.x, x + transform.position.y, transform.position.z);
        }
    }
    IEnumerator Start()
    {

        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        // ローカル座標のY軸のマイナス方向に移動する
        this.transform.DOMove(endValue: new Vector3(this.transform.position.x+5, -3, 0), duration: 2.0f);

        //ステージ数に応じて強化
        if ((Emitter.stageCount - 1) / 3 >= 1)
        {
            hp += (hp * ((Emitter.stageCount - 1) / 3));
            maneyPoint += (maneyPoint * ((Emitter.stageCount - 1) / 3));
            spaceship.m_shotDelay -= spaceship.m_shotDelay / 5;
        }
        //玉を打たない敵の場合終了
        if (spaceship.m_canShot == false)
        {
            yield break;
        }
        //敵が初めて弾を打つ際の待ち時間を設定
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
                //玉を打つ
                spaceship.shotEnemy(shotPosition);
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.m_shotDelay);
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet(Player)") return;

        // PlayerBulletのTransformを取得
        Transform playerBulletTransform = c.transform.parent;

        // Bulletコンポーネントを取得
        Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

        // ヒットポイントを減らす
        hp = hp - bullet.m_power;

        // 弾の削除
        Destroy(c.gameObject);

 
        // ヒットポイントが0以下であれば
        if (hp <= 0)
        {
            // スコアコンポーネントを取得してポイントを追加
            FindObjectOfType<Score>().AddPoint(maneyPoint);
            /*GameObject[] eachEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemys in eachEnemy)
            {}
                Destroy(enemys);*/
            
            //爆発
            spaceship.Explosion();
            GameObject createManey = Instantiate(maney, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        } else
        {
            spaceship.GetAnimator().SetTrigger("Damage");

        }
    }
}
