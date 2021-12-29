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

    // «“¿œ: Ω∫≈©∏≥≈Õ∫Ì ø¿∫Í¡ß∆Æø° ¿÷¥¬ µ•¿Ã≈Õ Ω·º≠ Dictionaryø° ≥÷æÓ∫∏±‚
    private void GenerationData()
    {
        dialogueData.Add(10, new string[] { "≥»≥»≥»≥»≥»≥»≥»≥»≥»≥»≥»≥»≥»≥»≥»" });
        dialogueData.Add(20, new string[] { "¿Ã∞«...", "ππ¡ˆ..?" });
    }
    
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length)
            return null;
        else
            return dialogueData[id][dialogueIndex];
    }

}
