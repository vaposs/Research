using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingPlayer
{
    [SerializeField] private static float TimeMining = 2;
    [SerializeField] private static int MaxItemInHand = 10;

    // МЕТОДЫ УВЕЛЕЧЕНИЯ СТАТОВ
    public static void AddMaxItemInHand(int addCount)
    {
        MaxItemInHand += addCount;
    }

    // МЕТОДЫ ПОЛУЧЕНИЯ ДАННЫХ

    public static WaitForSeconds TakeTimeMining()
    {
        return new WaitForSeconds(TimeMining);
    }

    public static int TakeMaxItem()
    {
        return MaxItemInHand;
    }
}
