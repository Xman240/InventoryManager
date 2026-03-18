using UnityEngine;

[CreateAssetMenu(fileName = "BoolRequirementSO", menuName = "Quest System/BoolRequirementSO")]
public class BoolRequirementSO : RequirementSO
{
    public bool defaultValue;

    public override RequirementData CreateRuntimeData()
    {
        return new BoolRequirementData(this);
    }
}
