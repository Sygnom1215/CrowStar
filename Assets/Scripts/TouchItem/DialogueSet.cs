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
        dialogueData.Add(30, new string[] { "����ִ� �� ����." });
        dialogueData.Add(40, new string[] { "����...? ��� ���� ����?" });
        dialogueData.Add(50, new string[] { "���ɰ��� �ֿ���!" });
        dialogueData.Add(60, new string[] { "�⸧�� ��� �絿�� ����." });
        dialogueData.Add(70, new string[] { "���� ���ڳ�." });
        dialogueData.Add(80, new string[] { "�ϴ��� ���ڳ�." });
        dialogueData.Add(90, new string[] { "��ħ��...?", "��� ���� �ɱ�?" });
        dialogueData.Add(100, new string[] { "�⸧�� ��� �絿�̴�." });
    }
    
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length)
            return null;
        else
            return dialogueData[id][dialogueIndex];
    }

}
