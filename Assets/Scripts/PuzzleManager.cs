using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject trashObject;

    private void Start()
    {
        StartTrashPuzzle();
    }
    public void StartTrashPuzzle()
    {
        for(int i = 0; i<35 ; i++)
        {
            GameObject obj = Instantiate(trashObject, trashObject.transform.parent);
            obj.transform.position = new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 4f), 10f);
            obj.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));
        }
    }
}
