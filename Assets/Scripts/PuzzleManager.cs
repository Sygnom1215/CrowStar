using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject trashObject;
    [SerializeField] private List<PuzzleScene> puzzleScenes;

    private void Start()
    {
        StartTrashPuzzle();
    }

    public void StartTrashPuzzle()
    {
        for (int i = 0; i < 35; i++)
        {
            GameObject obj = Instantiate(trashObject, trashObject.transform.parent);
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
}

