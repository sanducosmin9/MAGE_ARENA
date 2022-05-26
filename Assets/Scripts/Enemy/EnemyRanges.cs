using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyRanges
{
    [Header("Basic melee enemy")]
    public static float meleeSight = 15f;
    public static float meleeAttack = 2f;
    
    [Header("Basic range enemy")]
    public static float rangeAttack = 10f;
    public static float sight = 30f;


    [Header("Boss melee enemy")]
    public static float bossMeleeAttack = 3f;
}
