using UnityEngine;

public class Explosion : MonoBehaviour
{
    //消滅
    void OnAnimationFinish()
    {
        Destroy(gameObject);
    }
}