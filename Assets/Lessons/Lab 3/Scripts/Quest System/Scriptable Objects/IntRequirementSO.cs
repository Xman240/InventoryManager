using UnityEngine;

[CreateAssetMenu(fileName = "IntRequirementSO", menuName = "Quest System/IntRequirementSO")]
public class IntRequirementSO : RequirementSO
{
    public int defaultValue;
    public int targetValue;

    public override RequirementData CreateRuntimeData()
    {
        return new IntRequirementData(this);
    }
}
