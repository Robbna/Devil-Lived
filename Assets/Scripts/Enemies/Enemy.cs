using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    //Variables expuestas en el editor
    [SerializeField] private float currentHealth;
    //Variables necesarias para Enemy
    private Animator goblinAnimation;
    private SpriteRenderer spr;
    private bool isAlive;

    private void Start()
    {
        goblinAnimation = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        //Inicializamos isAlive a true, para que por cada instancia el personaje sea "Hitteable" (golpeable)
        isAlive = true;
    }

    private void Update()
    {

        if (isAlive)
        {
            if (EnemyDetection_zone.isPlayerOnTheLeft)
            {
                spr.flipX = true;
            }
            else
            {
                spr.flipX = false;
            }
            if (EnemyDetection_zone.isNear)
            {
                goblinAnimation.SetBool("isRunning", true);
                if (EnemyAttack_zone.isNearToAttack)
                {
                    goblinAnimation.SetBool("isNear", true);
                    goblinAnimation.SetTrigger("Attack");
                }
                else
                {
                    goblinAnimation.SetBool("isNear", false);
                }
            }
            else
            {
                goblinAnimation.SetBool("isRunning", false);
            }

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
            goblinAnimation.SetTrigger("Hitted");
            currentHealth -= damageTaken;
        }
    }
    //***Corrutina para evento "Muerte", con parámetro de tiempo (float)
    IEnumerator Death(float time)
    {
        isAlive = false;
        goblinAnimation.SetBool("isDeath", true);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
