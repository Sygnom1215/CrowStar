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

    // 할일: 스크립터블 오브젝트에 있는 데이터 써서 Dictionary에 넣어보기
    private void GenerationData()
    {
        dialogueData.Add(10, new string[] { "냠냠냠냠냠냠냠냠냠냠냠냠냠냠냠" });
        dialogueData.Add(20, new string[] { "이건...", "뭐지..?" });
        dialogueData.Add(30, new string[] { "잠겨있는 것 같다." });
        dialogueData.Add(40, new string[] { "열쇠...? 어디에 쓰는 거지?" });
        dialogueData.Add(50, new string[] { "성냥갑을 주웠다!" });
        dialogueData.Add(60, new string[] { "기름이 담긴 양동이 같다." });
        dialogueData.Add(70, new string[] { "별이 예쁘네." });
    }
    
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length)
            return null;
        else
            return dialogueData[id][dialogueIndex];
    }

}
