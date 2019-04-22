using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkilScript : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 dir;
    public float dist = 5f;
    public float damage = 10;

    public enum GRAPHIC
    {
        normal = 0,
        light,
        fire,
        explode,
        sz
    }
    public GRAPHIC type = GRAPHIC.normal;
    private Animator anim;

    public void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("fireballFly");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("type", (int)type);
        // PENIS SEX!!!!!!!!!!!!!!!!!!!
        // PLAY TEAM FORTRESS 2!!!!!
        // GOD GAME!!
        transform.position += dir * Time.deltaTime * 5f;

        Vector3 delta = pos - transform.position;

        if (delta.magnitude > dist)
        {
            type = GRAPHIC.explode;
            anim.SetInteger("type", (int)type);
        }
        /*
        if (Mouse.x < 960)
        {
            if(Mouse.y < 540)
            {
                Vector3 dir = Vector3.Normalize(Mouse - transform.position);
                transform.position -= dir * Time.deltaTime * 5f;
            }
            else if(Mouse.y > 540)
            {
                Vector3 dir = Vector3.Normalize(Mouse - transform.position);
                dir.x = -dir.x;
                transform.position += dir * Time.deltaTime * 5f;
            }
            else if(Mouse.y == 540)
            {
                Vector3 dir = Vector3.Normalize(Mouse - transform.position);
                transform.position -= transform.right * Time.deltaTime * 5f;
            }
            
            if (Pos.x - 5f > transform.position.x )
            {
                Destroy(this.gameObject);
            }
        }
        */
        //else if (Mouse.x > 960)
        //{
        //    if (Mouse.y < 540)
        //    {
        //        Vector3 dir = Vector3.Normalize(Mouse - transform.position);
        //        transform.position -= dir * Time.deltaTime;
        //    }
        //    else if (Mouse.y > 540)
        //    {
        //        Vector3 dir = Vector3.Normalize(Mouse - transform.position);
        //        transform.position += dir * Time.deltaTime;
        //    }
        //    else if(Mouse.y == 540)
        //    {
        //        Vector3 dir = Vector3.Normalize(Mouse - transform.position);
        //        transform.position -= dir * Time.deltaTime;
        //    }
        //    if (Pos.x + 5f < transform.position.x)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}

    }
}
