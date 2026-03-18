using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSO", menuName = "Dialog System/DialogSO")]
public class DialogSO : ScriptableObject
{
    //public int id;
    public string dialogLine;
    public string speakerName;
    public Sprite portrait;
    public List<DialogChoice> dialogChoices;
}

[Serializable]
public class DialogChoice
{
    public int index;
    public string dialogLine;
}
