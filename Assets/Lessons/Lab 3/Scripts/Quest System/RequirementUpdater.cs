using System;
using UnityEngine;

public class RequirementUpdater : MonoBehaviour
{
    public enum UpdateType
    {
        SetBool,
        IncrementInt
    }

    [Serializable]
    public class RequirementUpdate
    {
        public RequirementSO requirementSO;
        public UpdateType updateType;
        public int increment = 1;
        public bool boolVal = true;
    }

    [SerializeField] private RequirementUpdate[] requirementUpdates;

    private void Start()
    {
        if(GoalManager.instance == null)
        {
            Debug.LogError("Goal Manager is not in scene");
            return;
        }
    }

    [ContextMenu("Update Requirement")]
    public void UpdateRequirement()
    {
        if (GoalManager.instance == null)
        {
            Debug.LogError("Goal Manager is not in scene");
            return;
        }

        foreach (var update in requirementUpdates)
        {
            switch (update.updateType)
            {
                case UpdateType.SetBool:
                    if(update.requirementSO is BoolRequirementSO boolReq)
                    {
                        GoalManager.instance.SetBoolRequirement(boolReq, update.boolVal);
                        
                    }
                    break;
                case UpdateType.IncrementInt:
                    if(update.requirementSO is IntRequirementSO intReq)
                    {
                        GoalManager.instance.SetIntRequirement(intReq, update.increment);
                    }
                    break;

            }

        }
    }
}
