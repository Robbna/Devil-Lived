using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mCheckGround : MonoBehaviour
{
    public static bool isGrounded;
    [SerializeField] private float rayDistance;

    RaycastHit2D hit;

    private void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance);
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}