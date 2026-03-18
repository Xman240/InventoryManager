using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "Quest System/QuestSO")]
public class QuestSO : ScriptableObject
{
    public string questName;
    public List<GoalSO> goals;
    public int initialGoalID;
}
