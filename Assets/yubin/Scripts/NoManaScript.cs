using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoManaScript : MonoBehaviour
{
    public float life = 1.0f; // seconds

    IEnumerator fuckingdie (float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fuckingdie(life));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, 0.05f));
    }
}
