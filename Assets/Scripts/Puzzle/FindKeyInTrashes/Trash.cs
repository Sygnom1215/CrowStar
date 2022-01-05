using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trash : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField] private bool isTrash;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDrag()
    {
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position =
            new Vector3(Mathf.Clamp(targetPos.x, ConstantManager.MIN_POSITION.x, ConstantManager.MAX_POSITION.x),
            Mathf.Clamp(targetPos.y, ConstantManager.MIN_POSITION.y, ConstantManager.MAX_POSITION.y), 0f);
    }

    private void OnMouseDown()
    {
        if(isTrash) { 
           SoundManager.Instance.SetEffectSound(10);
        }
        else
        {
            SoundManager.Instance.SetEffectSound(12);
        }
    }

    private void OnMouseUp()
    {
        rigid.AddForce(transform.position * 0.5f, ForceMode2D.Impulse);
    }
}
