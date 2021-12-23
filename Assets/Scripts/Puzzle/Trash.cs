using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trash : MonoBehaviour
{
    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    private void OnMouseUp()
    {
        rigid.AddForce(transform.position * 0.5f, ForceMode2D.Impulse);
    }
}
