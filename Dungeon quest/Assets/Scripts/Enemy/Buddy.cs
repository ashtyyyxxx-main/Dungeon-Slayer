using System;
using System.Threading.Tasks;
using UnityEngine;

public class Buddy : MonoBehaviour
{
    public float health, maxHealth;
    public int moneyReward;

    public Action onKilled;


    private void Start()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            onKilled?.Invoke();
            GameObject.FindAnyObjectByType<Player>().money += moneyReward;
            GameObject.FindAnyObjectByType<Player>().onMoneyChanged?.Invoke();
            Destroy(gameObject);
        }
    }

}
