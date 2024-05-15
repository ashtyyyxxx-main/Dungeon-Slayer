using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
    public int expReward;
    public int goldReward;

    public QuestGoal goal;

    public async void Complete()
    {
        await Task.Delay(100);
        goal.currentAmount = 0;
        isActive = false;
        Debug.Log(title + " was completed");
    }
}