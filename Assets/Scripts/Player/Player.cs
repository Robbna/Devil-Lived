using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    [Header("Tiempos de carga")]
    [SerializeField] private float timeDeath;
    [SerializeField] private float timeToRespawn;
    public static bool isAlive;
    private Animator playerAnimation;

    private void Start()
    {
        transform.position = new Vector3(-31.9f, 79.5f, 0f);
        healthBar.SetMaxHealth(100);
        playerAnimation = GetComponent<Animator>();
        isAlive = true;

    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(Death(timeDeath));
            StartCoroutine(Spawn(timeToRespawn));

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

    private IEnumerator Spawn(float time)
    {
        yield return new WaitForSeconds(time);
        mScenes.RestartLevel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fall"))
        {
            currentHealth = 0;
            healthBar.SetHealth(0);
        }
    }
}
