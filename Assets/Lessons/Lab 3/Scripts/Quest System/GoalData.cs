using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoalData
{
    public Dictionary<RequirementSO, RequirementData> requirements = new();
    public GoalSO config;
    public bool isActive;
    public bool isComplete;
    public int goalID;
    public string goalName;
    public int nextGoalID;

    public event Action<GoalData> onGoalComplete;
    public event Action<GoalData> onGoalUpdated;

    public GoalData(GoalSO config_)
    {
        config = config_;
        isActive = false;
        goalID = config.goalID;
        goalName = config.goalName;
        nextGoalID = config.nextGoalID;
        foreach(RequirementSO req in config.requirements)
        {
            RequirementData tmp = req.CreateRuntimeData();
            tmp.onRequirementUpdated += HandleRequirementChange;
            requirements.Add(req, tmp);
        }
    }

    public bool isCompleted()
    {
        isComplete = requirements.Values.All(r => r.IsMet());
        if (isComplete) onGoalComplete?.Invoke(this);
        return isComplete;
    }

    public void ActivateGoal()
    {
        isActive = true;
        onGoalUpdated?.Invoke(this);
    }

    private void HandleRequirementChange(RequirementData req)
    {
        requirements[req.Config] = req;
        onGoalUpdated?.Invoke(this); // handle ui/data refresh

        if(isActive && isCompleted())
        {
            onGoalComplete?.Invoke(this); // only on goal completion
        }
    }
}
