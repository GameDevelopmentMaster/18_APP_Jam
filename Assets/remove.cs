using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Debug.Log("Tag");
            Destroy(collision.gameObject);
        }
    }
}
