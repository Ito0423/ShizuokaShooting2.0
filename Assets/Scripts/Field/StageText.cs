using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour
{
    public static Text targetText;
    // Start is called before the first frame update
    public static void  showText ()
    {
        targetText.text = "aaa";
    }
}
