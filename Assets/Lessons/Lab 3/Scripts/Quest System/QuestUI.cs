using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questName;
    public TMP_Text goalName;
    public Slider questProgress;

    [ContextMenu("Init")]
    public void InitUI()
    {
        QuestManager.instance.onQuestUpdate += QuestUpdated;
    }

    public void QuestUpdated(QuestData data)
    {
        Debug.Log("test");
        questName.text = data.questName;
        questProgress.value = (float)data.completedGoals / (float)data.goals.Values.Count;
        foreach(GoalData goal in data.goals.Values)
        {
            if (goal.isActive == true)
            {
                goalName.text = goal.goalName;
            }
           
        }
    }
}
