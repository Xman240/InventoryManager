using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogDatabaseSO", menuName = "Scriptable Objects/DialogDatabaseSO")]
public class DialogDatabaseSO : ScriptableObject
{
    public List<DialogData> dialogLines;
    public Dictionary<int, DialogSO> dialogDictionary;

    public void InitializeDictionary()
    {
        dialogDictionary = new Dictionary<int, DialogSO>();
        foreach (DialogData data in dialogLines)
        {
            dialogDictionary.Add(data.id, data.config);
        }
    }
}

[Serializable]
public class DialogData
{
    public int id;
    public DialogSO config;
}
