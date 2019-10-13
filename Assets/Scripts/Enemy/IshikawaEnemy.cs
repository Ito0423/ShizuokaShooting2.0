using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IshikawaEnemy : MonoBehaviour
{
    Spaceship spaceship;
    public float speed;
    public int hp = 1;
    public int scorePoint;
    public GameObject maney;
    GameObject createManey;

    // Start is called before the first frame update
    IEnumerator Start()
    {

        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        // GameObject player = GameObject.Find("Player(Clone)");

        this.transform.DORotate(
             new Vector3(0f, 0f, Random.Range(200f, 280f)), 4f);

        spaceship.Move(transform.right * +1);

        if (spaceship.m_canShot == false)
        {
            yield break;
        }

        while (true)
        {

            // 子要素を全て取得する
            for (int i = 0; i < transform.childCount; i++)
            {

                Transform shotPosition = transform.GetChild(i);
                Vector3 shotPositionRotation = new Vector3(0, 0, Random.Range(230f, 360f));
                
                // ShotPositionの位置/角度で弾を撃つ
                //TODOチュートリアルが引数１
                //spaceship.Shot(transform,shotPosition);
                spaceship.shotEnemy(shotPosition);
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.m_shotDelay);
        }
    }

    /*void Start()
    {



        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        // GameObject player = GameObject.Find("Player(Clone)");

        Vector3 reversePlayer = -new Vector3(this.transform.position.x, this.transform.position.y, 0);

        this.transform.DORotate(
    new Vector3(0f, 0f, 270f),    // 終了時点のRotation
    3f                        // アニメーション時間
);
        spaceship.Move(transform.right * +1);



    }*/

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
            FindObjectOfType<Score>().AddPoint(scorePoint);

            //爆発
            spaceship.Explosion();
            createManey = Instantiate(maney, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
