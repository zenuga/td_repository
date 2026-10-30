using UnityEngine;
using System;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using TMPro;

public class MoneyAndLifesManager : MonoBehaviour
{
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr window, string text, string caption, uint type);
#endif
    public static MoneyAndLifesManager Instance { get; private set; }
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text lifesText;
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
            return;
        }   

        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes <= 0)
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        MessageBox(IntPtr.Zero, "DIEEEEEEEEEEEEEEEEE", "you dead", 0x00000010);
#else
        Debug.LogError("Oh no you dead..");
#endif
        SceneManager.LoadScene(0);
        }
    }
    public void ChangeMoney(int amount)
    {
        money += amount;
        UpdateTexts();
    }
    public void ChangeLifes(int amount)
    {
        lifes += amount;
        UpdateTexts();
    }
    public void resetMoneyAndLifes()
    {
        money = 100;
        lifes = 250;
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        if (moneyText != null)
        {
            moneyText.text = money.ToString();
        }

        if (lifesText != null)
        {
            lifesText.text = lifes.ToString();
        }
    }
}
