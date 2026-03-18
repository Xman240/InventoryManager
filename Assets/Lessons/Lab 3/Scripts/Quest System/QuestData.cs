using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string questName;
    public bool isComplete = false;
    public bool isActive = false;
    public QuestSO Config;
    public int initialGoalID = 0;
    public int completedGoals;

    public Dictionary<GoalSO, GoalData> goals = new();

    public event Action<QuestData> onQuestUpdated;
    public event Action<QuestData> onQuestCompleted;

    public QuestData(QuestSO Config_)
    {
        Config = Config_;
        completedGoals = 0;
        initialGoalID = Config.initialGoalID;
        questName = Config.questName;

        foreach(GoalSO goalConfig in Config.goals)
        {
            GoalData tmp = new GoalData(goalConfig);
            goals.Add(goalConfig, tmp);
            tmp.onGoalUpdated += GoalUpdated;
            tmp.onGoalComplete += GoalComplete;
        }
    }

    public GoalData GetActiveGoal()
    {
        foreach(GoalData goal in goals.Values)
        {
            if (goal.isActive)
            {
                return goal;
            }
        }
        return null;
    }

    public void GoalComplete(GoalData goal)
    {
        completedGoals++;
        if(completedGoals >= goals.Values.Count)
        {
            onQuestCompleted?.Invoke(this);
        }
    }

    public void GoalUpdated(GoalData goal)
    {
        goals[goal.config] = goal;
        onQuestUpdated?.Invoke(this);

    }

    public void ActivateQuest()
    {
        isActive = true;
        onQuestUpdated?.Invoke(this);
    }

    public void ActivateGoal(GoalSO goal)
    {
        goals[goal].ActivateGoal();
    }
}
