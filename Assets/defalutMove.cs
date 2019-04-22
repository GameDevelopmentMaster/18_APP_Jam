using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defalutMove : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * 10f * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * 10f * Time.deltaTime);
        }
    }
}
