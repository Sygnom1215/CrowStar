using UnityEngine.EventSystems;
using UnityEngine;

public class Box : ObjectBase, IPointerUpHandler
{
    private bool isOpen;
    [SerializeField] private GameObject inBoxObj;
    public override void OnClick()
    {
        if(isOpen)
        {
            Open();
            return;
        }

        if (GameManager.Instance.GetCurItem() == null || !CheckIsCorrect(GameManager.Instance.GetItemType()))
        {
            GameManager.Instance.DialogueManager.Action(gameObject);
        }

        else
        {
            Open();
            isOpen = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnClick();
    }

    private void Open()
    {
        base.RemoveItem();
        GameManager.Instance.UIManager.HideStageButton();
        GameManager.Instance.PuzzleManager.AddPuzzleScene(inBoxObj);
        inBoxObj.SetActive(true);
    }
}
