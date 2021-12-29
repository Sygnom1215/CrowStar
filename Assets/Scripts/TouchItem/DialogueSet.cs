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
        dialogueData.Add(10, new string[] { "냠냠냠냠냠" });
        dialogueData.Add(20, new string[] { "이건...aasdfasdfasdfasdf", "뭐지..?sadfdsfasfdsfsaf" });
    }
    
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length)
            return null;
        else
            return dialogueData[id][dialogueIndex];
    }

}
