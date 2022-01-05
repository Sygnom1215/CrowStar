using UnityEngine.EventSystems;
using UnityEngine;

public class Box : ObjectBase, IPointerUpHandler
{
    private bool isOpen;
    [SerializeField] private GameObject inBoxObj;

    private void Start()
    {
        isOpen = DataManager.Instance.CheckClear(5);
    }
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
            SoundManager.Instance.SetEffectSound(8);
            Open();
            base.RemoveItem();
            isOpen = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnClick();
    }

    private void Open()
    {
        GameManager.Instance.UIManager.HideStageButton();
        GameManager.Instance.PuzzleManager.AddPuzzleScene(inBoxObj);
        inBoxObj.SetActive(true);
        DataManager.Instance.SaveClears(5);
    }
}
