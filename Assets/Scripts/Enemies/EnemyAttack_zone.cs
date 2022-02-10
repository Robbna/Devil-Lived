using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack_zone : MonoBehaviour
{
    public static bool isNearToAttack;

    private void Start()
    {
        isNearToAttack = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            isNearToAttack = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearToAttack = false;
        }
    }
}
