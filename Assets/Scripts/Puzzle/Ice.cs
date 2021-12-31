using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private int lampCount = 0;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lamp")
        {
            Debug.Log("램프감지");

            lampCount++;

            if (lampCount / 5 == 100)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
