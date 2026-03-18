using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public static DialogBox Instance;

    [Header("UI References")]
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI speakerName;
    public Image portait;

    [Header("Data")]
    public DialogDatabaseSO dialogDatabase;
    private Dictionary<int, DialogSO> dialogDictionary;
    public float typingSpeed = 0.02f;

    [Header("Input")]
    public InputAction continueDialog;
    private bool inputRecieved = false;
    
    public UnityEvent OnMessageComplete;
    private void Awake()
    {
        Instance = this;
        continueDialog.Enable();
        continueDialog.performed += ContinueDialog;
    }

    private void Start()
    {
        dialogDatabase.InitializeDictionary();
        dialogDictionary = dialogDatabase.dialogDictionary;
    }

    public void ContinueDialog(InputAction.CallbackContext c)
    {
        inputRecieved = true;
    }

    public void DisplayDialog(int index)
    {
        DialogSO dialog = dialogDictionary[index];
        speakerName.text = dialog.speakerName;
        portait.sprite = dialog.portrait;
        StartCoroutine(DisplayMessagePaginated(index));
    }

    private IEnumerator DisplayMessagePaginated(int index)
    {
        dialogText.text = "";
        dialogText.pageToDisplay = 1;

        string currentMessage = dialogDictionary[index].dialogLine;

        for(int i =0; i < currentMessage.Length; i++)
        {
            dialogText.text += currentMessage[i];
            dialogText.ForceMeshUpdate();
            yield return new WaitForSeconds(typingSpeed);
        }

        inputRecieved = false;
        yield return new WaitUntil(() => inputRecieved);
        OnMessageComplete?.Invoke();
        yield return null;
    }
}
