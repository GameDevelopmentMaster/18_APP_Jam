using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMobAct : MonoBehaviour
{

    bool change = false;
    bool delay = false;
    bool isTracing = false;
    GameObject tracetarget;
    public GameObject bulletPre;
    public Transform bulletLocation;
    public float moveSpeed = 3f;
    public Vector3 direction;
    Vector3 movement;

    int movementflag = 0; //0 = idle, 1 = Left, 2 = right

    private void Start()
    {
        StartCoroutine("Delay");
        StartCoroutine("Change");
    }

    private void Update()
    {
        // update tracing
        // isTracing == true 이면 플레이어가 범위 안에 있다는 뜻
        if (isTracing)
        {
            if (delay && tracetarget != null)
            {
                StartCoroutine("Delay");
                GameObject go = Instantiate(bulletPre, bulletLocation.position, bulletLocation.rotation);
                bulletBalsa BUTTSEX = go.GetComponent<bulletBalsa>();
                BUTTSEX.Direction = -Mathf.Sign(tracetarget.transform.position.x - transform.position.x);
            }
        }

        Move();
    }

    // 트리거는 입장한 순간만 단 한번 실행됨
    // 매 프레임마다 실행되게 하려면 누,유너ㅗㅀㄴ올ㄴ아ㅣ란ㅇ모라너ㅣ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            moveSpeed = 0;

            isTracing = true;
            tracetarget = other.gameObject;
            StartCoroutine("Delay");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StopCoroutine("Delay");
            isTracing = false;
            tracetarget = null;
            StartCoroutine("Change");
            StartCoroutine("stop");
        }
    }
    IEnumerator Delay()
    {
        delay = false;
        yield return new WaitForSeconds(0.5f);
        delay = true;
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

