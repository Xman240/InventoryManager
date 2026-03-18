using UnityEngine;
using UnityEngine.Events;

public class GoalEventListener : MonoBehaviour
{
    public int targetGoal;
    public UnityEvent OnGoalComplete;

    private void Start()
    {
        GoalManager.instance.onGoalComplete += GoalComplete;
    }

    public void GoalComplete(GoalData goalData)
    {
        if(goalData.goalID != targetGoal)
        {
            return;
        }
        OnGoalComplete?.Invoke();
    }

}
