using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemie : MonoBehaviour
{
    [SerializeField] private Animator goblinAnimation;
    [SerializeField] private float currentHealth;

    private void Start()
    {
        goblinAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentHealth <= 0.0f)
        {
            StartCoroutine(Death(2f));
        }
    }

    public void Hitted(float damageTaken)
    {
        goblinAnimation.SetTrigger("Hitted");
        currentHealth -= damageTaken;
    }

    IEnumerator Death(float time)
    {
        goblinAnimation.SetBool("isDeath", true);
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
