using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceTrigger : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Coin;
    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "PlayerBullet")
        {
            //Panel.SetActive(true);
            Destroy(collision.gameObject);
            Instantiate(Coin, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
    }
}
