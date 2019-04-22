using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{

    bool change = false;
    bool isTracing = false;
    GameObject tracetarget;
    public float moveSpeed = 3f;
    public Vector3 direction;
    Vector3 movement;
    
    int movementflag = 0; //0 = idle, 1 = Left, 2 = right

    private void Start()
    {
        StartCoroutine("Change");
    }

    private void Update()
    {
        // update tracing
        if (isTracing)
        {
            float delta = Mathf.Sign(tracetarget.transform.position.x - transform.position.x);
            direction = new Vector3(delta, 0, 0);
        }

        Move();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            StopAllCoroutines();
            isTracing = true;
            tracetarget = other.gameObject;

            float delta = Mathf.Sign(tracetarget.transform.position.x - transform.position.x);
            direction = new Vector3(delta, 0, 0);
            //this.transform.Translate(new Vector3(delta * moveSpeed, 0, 0));
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isTracing = false;
            StartCoroutine("Change");
            StartCoroutine("stop");
        }
    }

    private void Move()
    {
        this.transform.Translate(direction * moveSpeed * Time.deltaTime);
        StartCoroutine("stop");
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Change()
    {
        movementflag = Random.Range(0, 3);
        
            moveSpeed = 3f;
            if (change == true)
            {
            change = false;
                direction = Vector3.left;
            }
            else
            {
            direction = Vector3.right;
            change = true;
            }
        yield return new WaitForSeconds(3f);
        StartCoroutine("Change");
    }
          
}

