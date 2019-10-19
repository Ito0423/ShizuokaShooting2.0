using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waves;
    // 現在の敵機のインデックス
    private int currentWave;

    //ゲームスタート時の処理（コルーチン）
    void Start()
    {
        GameObject one = Instantiate(waves[0],
    this.transform.position, this.transform.rotation);


    }

    }
