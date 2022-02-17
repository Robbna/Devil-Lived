using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mLevel2Manager : MonoBehaviour
{
    [SerializeField] public GameObject panelGanar;
    [SerializeField] public GameObject playerHUD;
    [SerializeField] public GameObject optionsHUD;

    private void Start()
    {
        panelGanar.SetActive(false);
        mFadeController.FadeIn();
    }

    private void Update()
    {
        if (Player.enemyDefeat >= 3)
        {
            Time.timeScale = 0;
            playerHUD.SetActive(false);
            optionsHUD.SetActive(false);
            panelGanar.SetActive(true);
        }
    }

    public void loadMainMenu()
    {
        mFadeController.FadeOut();
        StartCoroutine(loadScene(1.5f));


    }

    IEnumerator loadScene(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(0);
    }


}
