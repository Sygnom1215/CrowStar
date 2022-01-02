using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MoveUpDown : MonoBehaviour
{
    private Vector2 up;
    private Vector2 down;
    private float timer = 0f;
    private bool isUp;

    private void Start()
    {
        up = new Vector2(transform.position.x, transform.position.y + 0.3f);
        down = new Vector2(transform.position.x, transform.position.y - 0.3f);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            if (isUp)
                transform.DOMove(up, 1f);

            else
                transform.DOMove(down, 1f);

            isUp = !isUp;
            timer = 0f;
        }
    }
}
