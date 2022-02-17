using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mOptions : MonoBehaviour
{
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject optionButton;

    private void Start()
    {
        optionsPanel.SetActive(false);
    }

    public void LoadOptions()
    {
        Time.timeScale = 0f;
        playerHUD.SetActive(false);
        optionButton.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void BackGame()
    {
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
        playerHUD.SetActive(true);
        optionButton.SetActive(true);


    }

}
