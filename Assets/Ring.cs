using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField] private Transform planet;
    private bool isReverse;
    private float speed = 50f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (isReverse)
        {
            transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(new Vector3(0f, 0f, -(speed * Time.deltaTime)));
        }
    }
    public void SetSize(float size)
    {
        rectTransform.sizeDelta = new Vector2(size, size);
        transform.Rotate(new Vector3(0f, 0f, Random.Range(0f, 360f)));
    }

    public void SetIsReverse()
    {
        isReverse = !isReverse;
    }


    public Vector2 GetCurrentPlanetPos()
    {
        return planet.position;
    }

    public bool CheckPosition(Vector2 one, Vector2 two)
    {
        return (Vector2.Distance(one, planet.transform.position) < 1.2f && Vector2.Distance(two, planet.transform.position) < 1.2f);
    }
}
