using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHpArea : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerExit2D(Collider2D c)
    {
        //衝突したおぶジェクトを破壊しプレイヤーのHPを１減らす
        PlayerHp.playerHp --;
        Destroy(c.gameObject);
    }
}
