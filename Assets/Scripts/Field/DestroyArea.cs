using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D c)
    {
        //当たったオブジェクトを破壊する
        Destroy(c.gameObject);
    }
}