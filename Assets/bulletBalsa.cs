using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBalsa : MonoBehaviour
{
    public float MoveSpeed= 5f;
    public float Direction = 1f;

    void Update()
    {
        transform.Translate(Vector2.left * Direction * MoveSpeed * Time.deltaTime);
        
    }
}
