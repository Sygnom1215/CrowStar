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

    private DialogueManager dialogueManager = null;

    private GameObject scanObject = null;
    private int dialogueIndex = 0;
    private string dialogueData = null;
    private bool isAction = false;
    public bool isTypingCheck = false;
    public bool isSkipCheck = false;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ItemObject itemObject = scanObj.GetComponent<ItemObject>();
        //ItemType itemType = scanObj.GetComponent<ItemType>();
        panel.SetActive(isAction);
        SetDialogue(itemObject.itemData.id);
    }

    private void SetDialogue(int id)
    {
        string dialogueData = dialogueSet.GetDialogue(id, dialogueIndex);
        Debug.Log(id);

        if (dialogueData == null)
        {
            dialogueIndex = 0;
            isAction = false;
            return;
        }

        StartCoroutine(Typing(dialogueData, dialogueText));

        dialogueIndex++;
    }

    public void ShowDialogue()
    {
        if (isTypingCheck || isSkipCheck) return;
        ItemObject itemObject = scanObject.GetComponent<ItemObject>();
        SetDialogue(itemObject.itemData.id);
        if(isAction==false)
        {
            itemObject.DestroyObject();
        }
        panel.SetActive(isAction);
    }

    public void SkipCheck()
    {
        if (isTypingCheck)
            isSkipCheck = true;
    }

    public IEnumerator Typing(string targetText, Text dialogueText)
    {
        Debug.Log("≈∏¿Ã«Œ");
        dialogueText.text = "";
        for (int i = 0; i <= targetText.Length; i++)
        {
            isTypingCheck = true;
            dialogueText.text = targetText.Substring(0, i);
            yield return new WaitForSeconds(.05f);
            if (dialogueManager.isSkipCheck)
            {
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
