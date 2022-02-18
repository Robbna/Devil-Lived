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
    public static int enemyDefeat;
    [SerializeField] private AudioSource deathSound;

    private void Start()
    {
        healthBar.SetMaxHealth(100);
        enemyDefeat = 0;
        playerAnimation = GetComponent<Animator>();
        isAlive = true;

    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            deathSound.Play();
            StartCoroutine(Death());

        }

        if (enemyDefeat >= 10)
        {
            mTeleport.isEnabled = true;
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
    IEnumerator Death()
    {
        isAlive = false;
        playerAnimation.SetBool("isDeath", true);
        yield return new WaitForSeconds(2f);
        mFadeController.FadeOut();
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
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
