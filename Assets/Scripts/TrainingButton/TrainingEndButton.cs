using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingEndButton : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip developEndSound;
    public int maxStageCount;
    static public int stageCount = 1;
    private bool firstClick = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (firstClick == false)
        {
            StartCoroutine("DevelopEnd");
            firstClick = true;
        }
    }
    IEnumerator DevelopEnd()
    {
        /*if (maxStageCount-1 == stageCount)
        {
            stageCount = 0;
        }*/
        stageCount++;
        audioSource.PlayOneShot(developEndSound);
            yield return new WaitForSeconds(1);
        Debug.Log("max" + maxStageCount + "kaunnto" + stageCount);
            SceneManager.LoadScene("Stage" + stageCount);
        if (maxStageCount == stageCount)
        {
            stageCount = 0;
        }
    }
}
