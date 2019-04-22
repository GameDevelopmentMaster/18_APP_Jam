using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : MonoBehaviour
{
    public GameObject Stage;
    //public GameObject Stage2;
    //public GameObject Stage3;
    //public GameObject Player;

    public int GraphicChage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StageData stg = Stage.GetComponent<StageData>();
        stg.ChangeSprite(GraphicChage);
    }
}
