using UnityEngine;
[CreateAssetMenu(fileName = "RequirementSO", menuName = "Quest System/RequirementSO")]

public abstract class RequirementSO : ScriptableObject
{
    public string requirementName;
    public abstract RequirementData CreateRuntimeData();

}
