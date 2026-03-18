using TMPro;
using UnityEngine;
using System.Collections;

public class PickupMessage : MonoBehaviour
{
    public static PickupMessage instance;

    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float displayTime = 2f;

    private Coroutine currentRoutine;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }
        gameObject.SetActive(true);

        currentRoutine = StartCoroutine(ShowMessageRoutine(message));
    }

    private IEnumerator ShowMessageRoutine(string message)
    {
        messageText.text = message;
        gameObject.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        gameObject.SetActive(false);
    }
}