using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    public static bool isAlive;
    private Animator playerAnimation;

    private void Start()
    {
        playerAnimation = GetComponent<Animator>();
        isAlive = true;

    }

    private void Update()
    {
        print(currentHealth);
        if (currentHealth <= 0)
        {
            StartCoroutine(Death(2f));
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
    //***Corrutina para evento "Muerte", con parámetro de tiempo (float)
    IEnumerator Death(float time)
    {
        isAlive = false;
        playerAnimation.SetBool("isDeath", true);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
