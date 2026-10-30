using UnityEngine;

public class MoneyAndLifesManager : MonoBehaviour
{
    public static MoneyAndLifesManager Instance { get; private set; }
    private int money = 100;
    public int Money => money;   
     private int lifes = 250;
    public int Lifes => lifes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeMoney(int amount)
    {
        money += amount;
    }
    public void ChangeLifes(int amount)
    {
        lifes += amount;
    }
    public void resetMoneyAndLifes()
    {
        money = 100;
        lifes = 250;
    }
}
