using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSet : MonoBehaviour
{
    Dictionary<int, string[]> dialogueData;
    //public SetData setData;

    private void Awake()
    {
        dialogueData = new Dictionary<int, string[]>();
        GenerationData();
    }

    // ����: ��ũ���ͺ� ������Ʈ�� �ִ� ������ �Ἥ Dictionary�� �־��
    private void GenerationData()
    {
        dialogueData.Add(10, new string[] { "�ȳȳȳȳȳȳȳȳȳȳȳȳȳȳ�" });
        dialogueData.Add(20, new string[] { "�̰�...", "����..?" });
    }
    
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length)
            return null;
        else
            return dialogueData[id][dialogueIndex];
    }

}
