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
