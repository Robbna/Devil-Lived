using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    //Variables expuestas en el editor
    [SerializeField] private float currentHealth;
    [SerializeField] private Transform playerTransform;
    //Componentes del enemigo
    private Animator enemyAnimation;
    private SpriteRenderer spr;
    //Variables necesarias para Enemy
    public bool isAlive;
    public bool isAttacking;
    public bool viewRigh, viewLeft;

    private void Start()
    {
        isAttacking = false;
        isAlive = true;
        enemyAnimation = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        //ROTACIÓN DEL ENEMIGO
        if (transform.position.x > playerTransform.position.x)
        {
            spr.flipX = true;

        }
        else
        {
            spr.flipX = false;
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
