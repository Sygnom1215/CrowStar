using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPuzzle : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private GameObject ring = null;

    List<GameObject> rings = new List<GameObject>();

    private void Start()
    {
        
    }

    private void InstantiateRings()
    {
        for(int i = 0; i<index; i++)
        {
            GameObject obj = Instantiate(ring, ring.transform.parent);
            rings.Add(obj);
        }
    }
}
