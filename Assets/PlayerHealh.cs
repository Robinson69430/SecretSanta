using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.UI;


public class PlayerHealh : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;

    public Volume volume;
    public Vignette vignette;
    
    public GameManager gm;
    

    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealh(maxHealth);
        
        volume.profile.TryGet(out vignette);


        vignette.color.value = Color.black;
        vignette.intensity.value = 0.5f;
    }

    private void Update()
    {
        
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
        

    }

    public void TakeDamage(int damage)
    {
            currentHealth -= damage;
            healthBar.SetHealh(currentHealth);
            StartCoroutine(RedBorder());
    }
    public void TakeHeal(int heal)
    {
        if (currentHealth < maxHealth)
        {
            if (currentHealth > maxHealth - heal)
            {
                currentHealth += heal-(currentHealth-(maxHealth - heal));
                Debug.Log(currentHealth);
            }
            else
            {
                currentHealth += heal;
                healthBar.SetHealh(currentHealth);
                Debug.Log(currentHealth);
            }

            gm.coins -= 100;

        }
        else
        {
            Debug.Log("Votre vie est pleine");
        }
        
    }
    
    


        IEnumerator RedBorder()
        {
            vignette.color.value = Color.red;

            yield return new WaitForSeconds(1.35f);

            vignette.color.value = Color.black;
        
    }
}
