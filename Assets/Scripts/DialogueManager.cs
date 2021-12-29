using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject panel = null;
    [SerializeField] private GameObject dialogue = null;
    [SerializeField] private Text dialogueText = null;
    [SerializeField] private DialogueSet dialogueSet = null;

    private GameObject scanObject = null;
    private int dialogueIndex = 0;
    private string dialogueData = null;
    private bool isAction = false;
    private bool isTypingCheck = false;
    private bool isSkipCheck = false;

    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ObjectData objectData = scanObject.GetComponent<ObjectData>();
        panel.SetActive(isAction);
        SetDialogue(objectData.id);
    }

    private void SetDialogue(int id)
    {
        string dialogueData = dialogueSet.GetDialogue(id, dialogueIndex);

        if (dialogueData == null)
        {
            dialogueIndex = 0;
            isAction = false;
            return;
        }

        StartCoroutine(Typing(dialogueData));

        dialogueIndex++;
    }

    public void ShowDialogue()
    {
        Debug.Log("쇼다이얼로그");
        if (isTypingCheck || isSkipCheck) return;
        ObjectData objectData = scanObject.GetComponent<ObjectData>();
        SetDialogue(objectData.id);
        panel.SetActive(isAction);
    }

    public void SkipCheck()
    {
        Debug.Log("스킵체크");
        if (isTypingCheck)
            isSkipCheck = true;
    }

    public IEnumerator Typing(string targetText)
    {
        dialogueText.text = "";
        for (int i = 0; i <= targetText.Length; i++)
        {
            isTypingCheck = true;
            dialogueText.text = targetText.Substring(0, i);
            yield return new WaitForSeconds(.15f);
            if (isSkipCheck)
            {
                Debug.Log("타이핑 스킵 체크");
                dialogueText.text = targetText;
                isTypingCheck = false;
                isSkipCheck = false;
                break;
            }

            isTypingCheck = false;
            isSkipCheck = false;
        }
    }
}
