using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth >= 0)
        {
            //stop spel to be added
        }
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }
}
