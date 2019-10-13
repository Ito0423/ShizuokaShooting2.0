using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    // Spaceshipコンポーネント
    protected Spaceship spaceship;
    //ヒットポイント
    public int hp;
    public int maneyPoint;
    public GameObject maney;
    GameObject playerPos;
    public bool firstShotCheck = false;
    public float firstShotWaitSecond = 0.5f;
    public float WaitForSecondsStart = 0;

    IEnumerator Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        // ローカル座標のY軸のマイナス方向に移動する
        spaceship.Move(transform.right * +1);//TODO 

        //現在のステージ数に応じてHPと落とす金と発射速度を増加させる
        if ((Emitter.stageCount - 1) / 3 >= 1)
        {
            hp += (hp * ((Emitter.stageCount - 1) / 3));
            maneyPoint += (maneyPoint * ((Emitter.stageCount - 1) / 3));
            spaceship.m_shotDelay -= spaceship.m_shotDelay/5;
        }
        //弾を打たない場合終了
        if (spaceship.m_canShot == false)
        {
            yield break;
        }
        //初めて打つ弾にディレイをかける
        if (firstShotCheck == false)
        {
            yield return new WaitForSeconds(firstShotWaitSecond);
            firstShotCheck = true;
        }
        //弾を打ち続ける
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

            //爆発
            spaceship.Explosion();

            GameObject createManey = Instantiate(maney, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            spaceship.GetAnimator().SetTrigger("Damage");
        }
    }
}

