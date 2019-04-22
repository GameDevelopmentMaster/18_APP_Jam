using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text manaText;
    public Text shieldText;
    public Text goldText;
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            manaText.text = "마나 : " + player.mana;
            shieldText.text = player.shield ? "SHIELD OK" : "NO SHIELD";
            goldText.text = player.money + " $";
        }
    }
}
