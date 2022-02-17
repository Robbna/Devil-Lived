using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mLevel1Manager : MonoBehaviour
{
    private void Start()
    {
        mFadeController.FadeIn();
    }

    public void loadMainMenu()
    {
        //mFadeController.FadeOut();
        StartCoroutine(loadScene(1.5f));


    }

    IEnumerator loadScene(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(0);
    }
}
