using System.Collections.Generic;
using UnityEngine;

public class RequirementManager : MonoBehaviour
{
    public Dictionary<RequirementSO, RequirementData> requirements;
    public static RequirementManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void TrackGoal(GoalData goal)
    {
        requirements = goal.requirements;
        foreach(RequirementData req in requirements.Values)
        {
            req.onRequirementUpdated += RequirementUpdated;
        }
    }

    public void RequirementUpdated(RequirementData req)
    {
        Debug.Log("Requirement " + req + " updated");
        requirements[req.Config] = req;
    }
}
