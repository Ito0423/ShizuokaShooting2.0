using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Spaceshipコンポーネント
    Spaceship spaceship;
    //弾を出す間隔
    static float shotDelay;
    //回収するManeyのスピード
    public float maneySpeed = 15.0f;
    //Maneyを回収した時の音
    public AudioClip getManeySound;
    //被弾時の音
    public AudioClip getDamageSound;
    //弾発射時の音
    public AudioClip playerBulletSe;
    //オーディオコンポーネント
    private AudioSource audioSource;

    public float playerSpeed = 200.0f;
    //アニメーターコンポーネント
    private Animator animator;

    private Rigidbody2D rigidbody2d; 

    IEnumerator Start()
    {
        //オーディオコンポーネントを取得して格納
        audioSource = GetComponent<AudioSource>();
        //スペースシップscriptコンポーネントを取得して格納
        spaceship = GetComponent<Spaceship>();
        //rigidbody2dコンポーネントを取得して格納
        rigidbody2d = GetComponent<Rigidbody2D>();
        

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
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        rigidbody2d.velocity = direction * playerSpeed;

        //プレイヤーの移動を制限
        Clamp();
        //金を回収
        getManey();
        //死亡時の処理
        if (PlayerHp.playerHp <= 0)
        {
            spaceship = GetComponent<Spaceship>();

            Debug.Log("GAMEOVER");
            // Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
            FindObjectOfType<StageManager>().GameOver();

            // 爆発する
            spaceship.Explosion();

            // プレイヤーを削除
            Destroy(gameObject);
            //shotDelay += 10f;
        }

    }
    //金を回収する処理
    void getManey()
    {
        //回収するスピード
        float step = maneySpeed * Time.deltaTime;
        //1enタグが付いたオブジェクトをoneYen配列に格納
        GameObject[] oneYens = GameObject.FindGameObjectsWithTag("1en");
        //全てのoneYensの要素をYensとして検索
        foreach (GameObject Yens in oneYens)
        {
            Yens.transform.position =
                      Vector3.MoveTowards(Yens.transform.position, this.transform.position, step);

            if (Yens.transform.position == this.transform.position)
            {
                audioSource.PlayOneShot(getManeySound);
                Destroy(Yens);

            }
        }
    }

    //ぶつかった瞬間に呼び出される
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
            PlayerHp.playerHp -= 1;

            audioSource.PlayOneShot(getDamageSound);

            spaceship.GetAnimator().SetTrigger("Damage");

        }
    }
    void Clamp()
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
    //アニメーターコンポーネントの取得
    public Animator GetAnimator()
    {
        return animator;
    }
    
}


