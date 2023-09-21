using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthSystem : MonoBehaviour
{
    [Header("Settings")]
    public static HealthSystem instance;
    public Image Fill;
    public int level;
    [Header("Player")]
    public float maxHealth;
    public float currentHealth;
    [Header("Enemy")]
    public float enemyMaxHealth=100;
    public float enemyCurrentHealth=100;
    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
        enemyCurrentHealth = enemyMaxHealth;
    }
    public void Damage(float damage)
    {
        if (currentHealth>0)
        {
            currentHealth = currentHealth - damage;
            Debug.Log("can azaldý");
            Fill.fillAmount = currentHealth / maxHealth;
           
        }
        else
        {
            SceneManager.LoadScene("Level"+level);
        }
    }
    public void Health(float damage)
    {
        currentHealth = currentHealth + damage;
        Fill.fillAmount += currentHealth / maxHealth;

    }
    public void enemyDamage(float damage)
    {
        if (enemyCurrentHealth>0)
        {
            enemyCurrentHealth = enemyCurrentHealth-damage;
            Debug.Log("Dusman can azaldý");
        }
        else
        {
           
            Debug.Log("Dusman oldu");
           
        }
    }
}
