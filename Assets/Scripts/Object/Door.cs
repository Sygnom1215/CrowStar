using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Door : ObjectBase, IPointerUpHandler
{
    [SerializeField] private Image lockObject;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image image;
    private bool isOpen;

    private void Start()
    {
        if (DataManager.Instance.CheckClear(0))
        {
            GameManager.Instance.SetCurrentStage(GameManager.Instance.GetCurrentStage() + 1);
        }
    }
    public override void OnClick()
    {
        if (isOpen) return;

        if (GameManager.Instance.GetCurItem() == null || !CheckIsCorrect(GameManager.Instance.GetItemType()))
        {
            GameManager.Instance.DialogueManager.Action(gameObject);
        }

        else
        {
            isOpen = true;
            DataManager.Instance.SaveClears(0);
            lockObject.transform.DOMoveY(-10f, 1f);
            SoundManager.Instance.SetEffectSound(2);
            Destroy(lockObject, 1f);
            RemoveItem();
            StartCoroutine(NextStage());

            //여기 문 여는 거


        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnClick();
    }

    private IEnumerator NextStage()
    {
        image.sprite = sprites[0];
        yield return new WaitForSeconds(1f);
        image.sprite = sprites[1];
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetCurrentStage(GameManager.Instance.GetCurrentStage() + 1);
    }
}
