using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndonClick : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("Main");
    }
}
