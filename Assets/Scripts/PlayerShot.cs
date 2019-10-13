using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{

    [SerializeField] public NewBullet[] m_playerBullet;

    [SerializeField] static private int playerCanShotNum = 1;

    [System.NonSerialized] public bool[] m_playerShotFlag = new bool[playerCanShotNum];

    void Start()
    {
        for(int i=0; i< playerCanShotNum; i++)
        {
            m_playerShotFlag[i] = false;
        }        
    }

    public void playerShotBullet(Transform playerPos)
    {
        //TODO 変える
        m_playerShotFlag[0] = true;
        for (int i = 0; i < playerCanShotNum; i++)
        {
            if (m_playerShotFlag[i] == true)
            {
                var pos = playerPos.transform.position;
                var rot = m_playerBullet[i].transform.rotation;
                var shot = Instantiate(m_playerBullet[i], pos, rot);
                shot.SetBulletSpeed();
            }
         }
    }

}