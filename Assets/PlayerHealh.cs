using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerHealh : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public GameManager gm;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealh(maxHealth);
    }

    public void TakeDamage(int damage)
    {
            currentHealth -= damage;
            healthBar.SetHealh(currentHealth);
    }
}
