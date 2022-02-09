using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mButtonManager : MonoBehaviour
{
    public static bool isHolding;
    public static string direction;
    private void Update()
    {
        if (isHolding)
        {
            isHolding = true;
        }
        else
        {
            isHolding = false;
        }
    }

}
