[System.Serializable]
public class QuestGoal
{

    public GoalType goalType;

    public string enemyToKillTag;
    public Item gatherItem;

    public int requiredAmount;
    public int currentAmount;

    public void EnemyKilled()
    {
        if (goalType == GoalType.killQuest)
            currentAmount++;
    }
    public void ItemCollected()
    {
        if (goalType == GoalType.Gathering)
            currentAmount++;
    }


    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
}

public enum GoalType
{
    killQuest,
    Gathering
}
