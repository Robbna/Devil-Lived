using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    private bool isAlive;
    private Animator playerAnimation;

    private void Start()
    {
        playerAnimation = GetComponent<Animator>();

        isAlive = true;

    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Hitted(float damageTaken)
    {
        if (isAlive)
        {
            playerAnimation.SetTrigger("Hitted");
            currentHealth -= damageTaken;
        }
    }
}
