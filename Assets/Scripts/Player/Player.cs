using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    public static bool isAlive;
    private Animator playerAnimation;

    private void Start()
    {
        healthBar.SetMaxHealth(100);
        playerAnimation = GetComponent<Animator>();
        isAlive = true;

    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(Death(2f));
        }
    }

    public void Hitted(int damageTaken)
    {
        if (isAlive)
        {
            playerAnimation.SetTrigger("Hitted");
            currentHealth -= damageTaken;
            healthBar.SetHealth(currentHealth);

        }
    }
    //***Corrutina para evento "Muerte", con parámetro de tiempo (float)
    IEnumerator Death(float time)
    {
        isAlive = false;
        playerAnimation.SetBool("isDeath", true);
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

}
