using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    public GameObject StageClaer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemy.Length == 0)
        {
            StageClaer.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
