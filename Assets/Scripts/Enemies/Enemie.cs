using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemie : MonoBehaviour
{
    //Variables expuestas en el editor
    [SerializeField] private Animator goblinAnimation;
    [SerializeField] private float currentHealth;
    //Variables necesarias para Enemie
    private bool isAlive;

    private void Start()
    {
        //Inicializamos isAlive a true, para que por cada instancia el personaje sea "Hitteable" (golpeable)
        isAlive = true;
        goblinAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
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
