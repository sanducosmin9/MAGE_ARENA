using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] basicEnemies;
    public int enemiesDead;
    public GameObject boss;

    private void Start()
    {

    }
    void Update()
    {
        enemiesDead = 0;
        foreach (GameObject go in basicEnemies)
        {
            if(go == null)
                enemiesDead++;
        }
        if(enemiesDead == basicEnemies.Length)
            boss.SetActive(true);
    }
}
