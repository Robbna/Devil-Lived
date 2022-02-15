using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Variables expuestas en el editor
    [SerializeField] private Transform attackObj;
    [SerializeField] private float radiusAttack;
    [SerializeField] private float attackDamage;
    [SerializeField] private float forceScaleAttack;


    //***Método de ataque principal
    public void Attack()
    {
        if (Player.isAlive)
        {

            //Lista de colisiones con las que _colisionará_ el objeto "attackObj"
            Collider2D[] listColliders = Physics2D.OverlapCircleAll(attackObj.position, radiusAttack);

            //Recorremos la lista
            foreach (Collider2D collider in listColliders)
            {
                //Si el objeto colisionado tiene el tag "Enemy"
                if (collider.CompareTag("Enemy"))
                {
                    collider.gameObject.GetComponent<Enemy>().Hitted(attackDamage);
                    if(collider.transform.position.x > transform.position.x)
                    {
                        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceScaleAttack, ForceMode2D.Impulse);
                    }
                    if (collider.transform.position.x < transform.position.x)
                    {
                        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceScaleAttack, ForceMode2D.Impulse);
                    }

                }
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

