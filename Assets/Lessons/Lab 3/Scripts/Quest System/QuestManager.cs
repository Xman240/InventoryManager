using UnityEngine;
using System.Collections.Generic;
using System;
public class QuestManager : MonoBehaviour
{
    public List<QuestSO> quests;
    public Dictionary<QuestSO, QuestData> questLibrary = new();
    public static QuestManager instance;
    public event Action<QuestData> onQuestUpdate;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeQuestLibrary();

    }

    [ContextMenu("Activate Quest")]
    public void ActivateQuest()
    {
        ActivateQuest(quests[0]);

    }

    [ContextMenu ("Initialize Quests")]
    public void InitializeQuestLibrary()
    {
        foreach(QuestSO q in quests)
        {
            QuestData tmp = new QuestData(q);
            tmp.onQuestUpdated += UpdateQuest;
            tmp.onQuestCompleted += CompleteQuest;
            questLibrary.Add(q, tmp);

        }
    }

   

    public void UpdateQuest(QuestData questData)
    {
        questLibrary[questData.Config] = questData;
        onQuestUpdate?.Invoke(questData);
    }

    public void CompleteQuest(QuestData questData)
    {
        questLibrary[questData.Config].isComplete = true;
    }

    public void ActivateQuest(QuestSO quest)
    {
        questLibrary[quest].isActive = true;
        Debug.Log("Starting quest: " + quest.questName);
        GoalManager.instance.TrackQuest(questLibrary[quest]);
    }

}
