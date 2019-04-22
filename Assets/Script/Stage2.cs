using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    public GameObject End;
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
            End.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
