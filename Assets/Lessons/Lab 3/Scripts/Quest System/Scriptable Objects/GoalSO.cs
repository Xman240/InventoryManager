using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoalSO", menuName = "Quest System/GoalSO")]
public class GoalSO : ScriptableObject
{
    public List<RequirementSO> requirements;
    public string goalName;
    public int goalID;
    public int nextGoalID;
}
