using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicManager : MonoBehaviour
{
    private int _StageCount = 1;
    public int StageCount
    {
        get { return _StageCount; }
        set { _StageCount = value; }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
   