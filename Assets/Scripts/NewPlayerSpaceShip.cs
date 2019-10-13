using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerSpaceShip : NewSpaceShip
{
    //TODO　変更テスト

    //金を回収した時の音
    public AudioClip m_pickManeySound;

    //金を回収するスピード
    [SerializeField] float m_pickManeySpeed;

    IEnumerator Start()
    {
        GetConponent();

        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            spaceship.Shot(transform);
            audioSource.PlayOneShot(playerBulletSe);
            // shotDelay秒待つ
            shotDelay = spaceship.m_shotDelay;
            yield return new WaitForSeconds(shotDelay);
        }

    }

    void Update()
    {
        //プレイヤーが動く
        PlayerSpaceShipMove();
        //金を回収
        getManey();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "Bullet(Enemy)")
        {
            // 弾の削除
            Destroy(c.gameObject);
        }

        // レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
        if (layerName == "Bullet(Enemy)" || layerName == "Enemy")
        {
            //HPを1下げる
            PlayerHp.playerHp -= 1;
            //音を出す
            m_audioSource.PlayOneShot(m_getDamageSound);
            //アニメーションを出す
            m_animator.SetTrigger("Damage");

            //死亡時の処理
            if (PlayerHp.playerHp <= 0)
            {
                // Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
                FindObjectOfType<Manager>().GameOver();

                // 爆発する
                Explosion();

                // プレイヤーを削除
                Destroy(gameObject);
            }
        }
    }

    private void PlayerSpaceShipMove()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        m_rigidbody2d.velocity = direction * m_moveSpeed;

        //プレイヤーの移動を制限
        Clamp();
    }

    //プレイヤーの動きを制限するメソッド
    private void Clamp()
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }

    private void getManey()
    {
        //回収するスピード
        float step = m_pickManeySpeed * Time.deltaTime;
        //1enタグが付いたオブジェクトをoneYen配列に格納
        GameObject[] oneYens = GameObject.FindGameObjectsWithTag("1en");
        //全てのoneYensの要素をYensとして検索
        foreach (GameObject Yens in oneYens)
        {
            Yens.transform.position =
                      Vector3.MoveTowards(Yens.transform.position, this.transform.position, step);

            if (Yens.transform.position == this.transform.position)
            {
                m_audioSource.PlayOneShot(m_pickManeySound);
                Destroy(Yens);
            }
        }
    }

    public void Explosion()
    {
        Instantiate(m_ExplosionPrefub, transform.position, transform.rotation);
    }

    public void PlayerShot(Transform origin)
    {
        var pos = origin.position;

        var rot = origin.rotation;

        var shot = Instantiate(m_bullet[0], pos, rot);
        shot.SetBulletSpeed(m_bulletSpeed);
    }

}
