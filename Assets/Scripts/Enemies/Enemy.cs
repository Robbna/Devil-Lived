using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    //Variables expuestas en el editor
    [SerializeField] private float currentHealth;
    //Variables necesarias para Enemy
    private Animator enemyAnimation;
    private SpriteRenderer spr;
    public static bool isAlive;
    public static bool isAttacking;

    private void Start()
    {
        isAttacking = false;
        enemyAnimation = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        //Inicializamos isAlive a true, para que por cada instancia el personaje sea "Hitteable" (golpeable)
        isAlive = true;
    }

    private void Update()
    {


        if (EnemyDetection_zone.isPlayerOnTheLeft)
        {
            spr.flipX = true;

        }
        else
        {
            spr.flipX = false;
        }
        if (Player.isAlive)
        {
            if (EnemyDetection_zone.isNear)
            {
                enemyAnimation.SetBool("isRunning", true);
            }
            else
            {
                enemyAnimation.SetBool("isRunning", false);
            }
        }
        else
        {
            enemyAnimation.SetBool("isRunning", false);
        }



        //Si la vida es MENOR o IGUAL a 0
        if (currentHealth <= 0.0f)
        {
            //Inicia una corrutina que ejecuta Death() al tiempo que especifiquemos
            StartCoroutine(Death(2f));
        }
    }

    //***Método Hitted
    public void Hitted(float damageTaken)
    {
        if (isAlive)
        {
            enemyAnimation.SetTrigger("Hitted");
            currentHealth -= damageTaken;
        }
    }
    //***Corrutina para evento "Muerte", con parámetro de tiempo (float)
    IEnumerator Death(float time)
    {
        isAlive = false;
        enemyAnimation.SetBool("isDeath", true);
        yield return new WaitForSeconds(time);

    }
}
