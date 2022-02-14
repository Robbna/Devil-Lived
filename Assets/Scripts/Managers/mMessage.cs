using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mMessage : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text textBox;

    private void Start()
    {
        canvas.SetActive(false);
        textBox.text = text;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }

    }
}
