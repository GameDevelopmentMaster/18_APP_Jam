using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St3Manager : MonoBehaviour
{
    public GameObject StageClaer;

    // Update is called once per frame
    void Update()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemy.Length == 0)
        {
            StageClaer.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
