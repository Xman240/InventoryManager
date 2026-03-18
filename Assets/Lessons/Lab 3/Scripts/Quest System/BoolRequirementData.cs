using UnityEngine;

public class BoolRequirementData : RequirementData
{
    private bool defaultValue;
    private bool value_;

    public bool value
    {
        get => value_;
        set
        {
            value_ = value;
            RaiseRequirementChanged();
        }
    }

    public BoolRequirementData(BoolRequirementSO Config_)
    {
        Config = Config_;
        value = Config_.defaultValue;
        defaultValue = Config_.defaultValue;
    }
    public override bool IsMet()
    {
        return value;
    }

    public override void Reset()
    {
        value = defaultValue;
    }
}
