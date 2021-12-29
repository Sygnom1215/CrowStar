using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomObject : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] GameObject puzzleField = null;

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance.UIManager.ActiveZoomOutButton(true);
        GameManager.Instance.UIManager.HideStageButton();
        GameManager.Instance.PuzzleManager.puzzleScene = puzzleField;
        puzzleField.SetActive(true);
    }
}
