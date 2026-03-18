using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public Dictionary<GoalSO, GoalData> goalLibrary = new();
    public static GoalManager instance;
    public event Action<GoalData> onGoalComplete;
    private void OnEnable()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetBoolRequirement(BoolRequirementSO requirement, bool newValue)
    {
        foreach(GoalData goalData in goalLibrary.Values)
        {
            if (goalData.isActive == false) continue;
            if(goalData.requirements.TryGetValue(requirement, out RequirementData
                baseData) && baseData is BoolRequirementData reqData)
            {
                reqData.value = newValue;
                //UpdateGoal(goalData);
                Debug.Log("Set value for req: " + reqData + " to " + reqData.value);
            }
        }
    }

    public void SetIntRequirement(IntRequirementSO requirement, int increment)
    {
        foreach (GoalData goalData in goalLibrary.Values)
        {
            if (goalData.isActive == false) continue;
            if (goalData.requirements.TryGetValue(requirement, out RequirementData
                baseData) && baseData is IntRequirementData reqData)
            {
                reqData.Increment(increment);
                //UpdateGoal(goalData);
            }
        }
    }

   

    public void ActivateGoal(int goalID)
    {
        foreach(GoalData goal in goalLibrary.Values)
        {
            goal.onGoalUpdated += UpdateGoal;
            if(goal.goalID == goalID)
            {
                Debug.Log("Activating goal: " + goal.goalID);
                goal.ActivateGoal();
                //RequirementManager.instance.TrackGoal(goal);
            }
        }
    }

    public void UpdateGoal(GoalData goalData)
    {
        if(goalData.isActive && goalData.isCompleted())
        {
            if(goalData.nextGoalID > -1)
            {
                ActivateGoal(goalData.nextGoalID);
            }

            goalData.isActive = false;
            onGoalComplete?.Invoke(goalData);
            Debug.Log("Goal Complete: " + goalData.goalID);
        }
    }

    public void TrackQuest(QuestData questData)
    {
        goalLibrary.AddRange(questData.goals);
        Debug.Log("Tracking Quest: " + questData.questName);
        ActivateGoal(questData.initialGoalID);
    }
}
