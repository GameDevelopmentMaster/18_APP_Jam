using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFloatScript : MonoBehaviour
{
    public TextMesh tm;
    public float time = 0.3f;
    public float vel = 0f;

    public void setText (string str)
    {
        tm.text = str;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(damnDie(time));
    }

    IEnumerator damnDie (float time)
    {
        time = 0.5f;
        vel = 1f;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, vel, 0));
        vel *= 0.5f;
    }
}
