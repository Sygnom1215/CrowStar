using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private Collider2D col;
    private bool isCollide = true;
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnMouseUp()
    {
        if (!isCollide)
            Debug.Log("Å¬¸¯ÀÌ¿°");
        else
            Debug.Log("XX");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollide = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isCollide = true;
    }
}
