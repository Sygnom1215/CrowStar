using UnityEngine;

[System.Serializable]
public struct InData
{
    public int id;
    public string[] dialogue;
}

[CreateAssetMenu(fileName = "Create Data/SetDataObject")]
public class SetData : ScriptableObject
{
    public InData[] inDatas;
}