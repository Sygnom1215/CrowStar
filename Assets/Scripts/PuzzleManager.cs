using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject trashObject;
    [SerializeField] private GameObject rockObject;
    [SerializeField] private List<PuzzleScene> puzzleScenes;
    public List<GameObject> curPuzzles;

    private void Start()
    {
        StartTrashPuzzle(trashObject, 35);
        StartTrashPuzzle(rockObject, 50);
    }

    public void StartTrashPuzzle(GameObject template, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(template, template.transform.parent);
            obj.transform.position = new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 4f), 10f);
            obj.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));
        }
    }

    public void ActivePuzzleScene()
    {
        for (int i = 0; i < puzzleScenes.Count; i++)
        {
            puzzleScenes[i].AcriveScene(CheckIsCurrentPuzzle(puzzleScenes[i]));
        }
    }

    private bool CheckIsCurrentPuzzle(PuzzleScene puzzleScene)
    {
        return (puzzleScene.chapter == GameManager.Instance.GetCurrentStage() && puzzleScene.sceneNumber == GameManager.Instance.UIManager.GetSceneIndex());
    }

    public void SetActivePuzzleScene(bool isActive)
    {
        curPuzzles[curPuzzles.Count - 1].SetActive(isActive);
        curPuzzles.RemoveAt(curPuzzles.Count - 1);
        GameManager.Instance.UIManager.ActiveZoomOutButton(!(curPuzzles.Count == 0));
    }

    public void AddPuzzleScene(GameObject obj)
    {
        GameManager.Instance.UIManager.ActiveZoomOutButton(true);
        curPuzzles.Add(obj);
    }
}

