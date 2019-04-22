using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GateManager : MonoBehaviour
{
    public GameObject Panel;
    public float rotateSpeed = 100f;
    private void Update()
    {
        this.transform.Rotate(Vector3.forward* rotateSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Panel.SetActive(true);
        }
    }

    public void Stage1()
    {
        PlayerPrefs.SetInt("Stage1", 2);
        DontDestroyOnLoad(GameObject.Find("player"));
        SceneManager.LoadScene("Main");
      
    }

    public void Stage2()
    {
        PlayerPrefs.SetInt("Stage2", 2);
        DontDestroyOnLoad(GameObject.Find("player"));
        SceneManager.LoadScene("Main");
    }
    public void Stage3()
    {
        PlayerPrefs.SetInt("Stage3", 2);
        DontDestroyOnLoad(GameObject.Find("player"));
        SceneManager.LoadScene("Boss");
    }
}
