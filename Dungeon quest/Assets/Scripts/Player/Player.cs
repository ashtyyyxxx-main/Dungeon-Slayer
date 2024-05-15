using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health, maxHealth;

    public int money;

    [SerializeField] private Slider healthbar;
    [SerializeField] private Text healthText;
    [SerializeField] private Text moneyText;

    private Action onHealthChanged;
    public Action onDeath;
    public Action onMoneyChanged;

    [Header("Quests")]
    public List<Quest> quests;

    private void Start()
    {
        health = maxHealth;
        healthbar.maxValue = maxHealth;
        UpdateHealthUI();
        onHealthChanged += UpdateHealthUI;
        onMoneyChanged += UpdateMoneyUI;

        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
    }

    private void Update()
    {
        UpdateMoneyUI();
    }

    private void UpdateHealthUI()
    {
        healthbar.value = health;
        healthText.text = "HEALTH: " + health + "/" + maxHealth;
    }
    private void UpdateMoneyUI()
    {
        moneyText.text = money + "$";
    }

    public void Damage(int damage)
    {
        health -= damage;
        onHealthChanged?.Invoke();
        if(health <= 0)
        {
            onDeath?.Invoke();
        }
    }
}