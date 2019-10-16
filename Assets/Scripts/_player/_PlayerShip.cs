using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの挙動を管理するクラス
public class _PlayerShip : _SpaceShip
{
    //コンポーネント
    private AudioSource _audioSource;
    private Animator _animator;

    //定数
    readonly string YEN_TAG = "1en";
    readonly string BULLET_ENEMY_LAYER_NAME = "Bullet(Enemy)";
    readonly string ENEMY_LAYER_NAME = "enemy";
    readonly string DAMAGE_ANIMATION_NAME = "Damage";

    //インスペクターで追加するオブジェクト
    [SerializeField] AudioClip _pickManeySound;
    [SerializeField] AudioClip _ShotBulletSound;
    [SerializeField] AudioClip _getDamageSound;

    //インスペクターで設定する変数
    [SerializeField] float _pickManeySpeed = 5;

    //TODO
    /*IEnumerator Start()
    {
        GetBasicSpaceShipComponent();

        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            _playerShot.ShotPlayerBullet(transform);
            yield return new WaitForSeconds(_delayShotSpeed);
        }
    }

    private void Update()
    {
        MovePlayer();
        GetManey();
    }*/

    //プレイヤーがオブジェクトに当たった時の挙動
    private void OnTriggerEnter2D(Collider2D c)
    {
        HitPlayerToObject(c);
    }

    //TODO
    /*private void MovePlayer()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        _rigidbody2d.velocity = direction * _moveSpeed;

        //プレイヤーの移動を制限
        ClampPlayerMove();
    }*/

    //プレイヤーの動きを制限するメソッド
    public void ClampPlayerMove()
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

    //プレイヤーが金を回収するメソッド
    public void GetManey()
    {

        //回収するスピード
        float pickManeySpeed = _pickManeySpeed * Time.deltaTime;

        //1enタグが付いたオブジェクトをoneYen配列に格納
        GameObject[] oneYens = GameObject.FindGameObjectsWithTag(YEN_TAG);

        //全てのoneYensの要素をYensとして検索
        foreach (GameObject oneYen in oneYens)
        {
            oneYen.transform.position =
                      Vector3.MoveTowards(oneYen.transform.position, this.transform.position, pickManeySpeed);

            if (oneYen.transform.position == this.transform.position)
            {
                _audioSource.PlayOneShot(_pickManeySound);
                Destroy(oneYen);
            }
        }
    }

    //プレイヤーがダメージを受けたときのメソッド
    public void HitPlayerToObject(Collider2D c)
    {

        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == BULLET_ENEMY_LAYER_NAME)
        {
            // 弾の削除
            Destroy(c.gameObject);
        }

        // レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
        if (layerName == BULLET_ENEMY_LAYER_NAME || layerName == ENEMY_LAYER_NAME)
        {
            GetDamagePlayer();
        }
    }

    private void GetDamagePlayer()
    {

        PlayerHp.playerHp--;

        _audioSource.PlayOneShot(_getDamageSound);

        _animator.SetTrigger(DAMAGE_ANIMATION_NAME);

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
    public void GetPlayerComponent()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }
}


