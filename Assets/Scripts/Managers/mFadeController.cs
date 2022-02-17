using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mFadeController : MonoBehaviour
{
    private static Animator animator;
    private static Image blackPanel;

    private void Start()
    {
        animator = GetComponent<Animator>();
        blackPanel = GetComponent<Image>();
    }

    public static void FadeIn()
    {
        animator.Play("FadeIN");
    }

    public static void FadeOut()
    {
        animator.Play("FadeOUT");
    }
}
