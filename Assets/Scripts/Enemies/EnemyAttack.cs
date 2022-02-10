using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimation;
    //Variables expuestas en el editor
    [SerializeField] private Transform attackObj;
    [SerializeField] private float radiusAttack;
    [SerializeField] private float attackDamage;

    //***Método de ataque principal
    public void Attack()
    {
        //Lista de colisiones con las que _colisionará_ el objeto "attackObj"
        Collider2D[] listColliders = Physics2D.OverlapCircleAll(attackObj.position, radiusAttack);

        //Recorremos la lista
        foreach (Collider2D collider in listColliders)
        {
            //Si el objeto colisionado tiene el tag "Enemy"
            if (collider.CompareTag("Player"))
            {
                //collider.gameObject.GetComponent<Enemy>().Hitted(attackDamage);
                Destroy(collider.gameObject);
            }
        }
    }
    //*** Método !PROVISIONAL para ver el rando de ataque
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackObj.transform.position, radiusAttack);
    }
}