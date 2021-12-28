using UnityEngine;

[System.Serializable]
public class PuzzleScene
{
    public int chapter;
    public int sceneNumber;
    public GameObject scene;

    public void AcriveScene(bool isActive)
    {
        scene.SetActive(isActive);
    }
}
