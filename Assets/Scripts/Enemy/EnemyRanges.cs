using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyRanges
{
    [Header("Basic melee enemy")]
    public static float meleeSight = 1000f;
    public static float meleeAttack = 2f;
    
    [Header("Basic range enemy")]
    public static float rangeAttack = 20f;
    public static float sight = 1000f;


    [Header("Boss melee enemy")]
    public static float bossMeleeAttack = 5f;
}
