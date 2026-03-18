using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteract : MonoBehaviour
{
    public int dialogIndex;
    public List<int> dialogIndexes = new List<int>();
    private int currentIndex = 0;


    public void InitiateDialog()
    {
        DialogBox.Instance.DisplayDialog(dialogIndex);
    }

    public void UpdateDialogIndex()
    {
        currentIndex++;
        dialogIndex = dialogIndexes[currentIndex];
    }
}
