using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPuzzle : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private GameObject ring = null;

    List<RectTransform> rings = new List<RectTransform>();

    private void Start()
    {
        InstantiateRings();
    }

    private void InstantiateRings()
    {
        for (int i = 0; i < index; i++)
        {
            GameObject obj = Instantiate(ring, ring.transform.parent);
            RectTransform rect = obj.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(350 + i * 100, 350 + i * 100);
            rings.Add(rect);
        }

        ring.SetActive(false);
    }
}
