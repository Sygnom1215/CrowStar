using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPuzzle : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private GameObject ring = null;

    List<Ring> rings = new List<Ring>();

    private float sizeOffset = 350f;
    private float increment = 150f;
    private bool isGameOver;

    private void Start()
    {
        InstantiateRings();
    }

    public void CheckGameOver()
    {
        if (CheckPlanet())
            GameOver();
    }

    private bool CheckPlanet()
    {
        for (int i = 1; i < rings.Count - 1; i++)
        {
            if (!rings[i].CheckPosition(rings[i - 1].GetCurrentPlanetPos(), rings[i + 1].GetCurrentPlanetPos()))
                return false;
        }
        return true;
    }

    private void InstantiateRings()
    {
        for (int i = index - 1; i >= 0; i--)
        {
            GameObject obj = Instantiate(ring, ring.transform.parent);
            Ring currentRing = obj.GetComponent<Ring>();
            currentRing.SetSize(sizeOffset + increment * i);
            rings.Add(currentRing);
        }

        ring.SetActive(false);
    }

    private void GameOver()
    {
        isGameOver = true;

        for(int i = 0; i< rings.Count; i++)
        {
            rings[i].SetColor();
        }
    }
}
