using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public int requiredLvl;

    public Player player;

    public void AcceptQuest()
    {
        quest.isActive = true;
        player.quests.Add(quest);
    }

    public void DeclineQuest()
    {
        quest.isActive = false;
        player.quests.Remove(quest);
    }

}
