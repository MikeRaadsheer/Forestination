using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    
    private static int MaxHP = 100;
    private static int HP;
    private static float MaxStamina = 25;
    private static float Stamina;
    public static float Noise = 0f;
    public static Action GameOver;
    public static bool isInsideTrailer = false;
    public static int UsabeAmountOfPoison = 12;

    public static float ElapsedTime;

    private void Start()
    {
        HP = MaxHP;
        Stamina = MaxStamina;
    }

    private void FixedUpdate()
    {
        ElapsedTime += Time.fixedDeltaTime;
    }

    public static void TakeDamage(int amount)
    {
        HP -= amount;

        if (HP < 0)
        {
            HP = 0;
        }
    }

    public static void Heal(int amount)
    {
        HP += amount;

        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }

    public static void DrainStamina(float amount)
    {
        Stamina -= amount;

        if (Stamina < 0)
        {
            Stamina = 0;
        }
    }

    public static void RestoreStamina(float amount)
    {
        Stamina += amount;

        if (Stamina > MaxStamina)
        {
            Stamina = MaxStamina;
        }
    }

    public static void AddNoise(float amount)
    {
        Noise += amount;
    }

    public static void RemoveNoise(float amount)
    {
        Noise -= amount;
    }

    public static bool UsePoison(AmountOfPoision _poison)
    {
        int amount = 0;

        switch (_poison)
        {
            case AmountOfPoision.NONE:
                Debug.Log("Didn't poison object.");
                break;
            case AmountOfPoision.LITTLE:
                amount = 1;
                break;
            case AmountOfPoision.NORMAL:
                amount = 2;
                break;
            case AmountOfPoision.LARGE:
                amount = 3;
                break;
            case AmountOfPoision.OVERKILL:
                amount = 4;
                break;
        }

        if((UsabeAmountOfPoison - amount) < 0)
        {
            Debug.Log("I don't have enough poison for that.");
            return false;
        }

        UsabeAmountOfPoison -= amount;
        Debug.Log("Used " + amount + " poison, I have " + UsabeAmountOfPoison + " left.");
        return true;
    }

    public static float GetNoise()
    {
        return Noise;
    }

    public static int GetHP()
    {
        return HP;
    }

    public static float GetStamina()
    {
        return Stamina;
    }

    public static bool GetIsInsideTrailer()
    {
        return isInsideTrailer;
    }

    public static void SetIsInsideTrailer(bool value)
    {
        isInsideTrailer = value;
    }

    public static void EndGame()
    {
        Debug.Log("Game Over");
        GameOver?.Invoke();
    }

}
