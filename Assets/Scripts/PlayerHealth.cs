using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth, maxHealth, damageAmount;
    public HealthBar healthBar;
    public GameObject damageEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage()
    {
        Instantiate(damageEffect, transform.position, Quaternion.identity);

        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
