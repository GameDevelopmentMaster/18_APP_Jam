using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopData : MonoBehaviour
{
    public GameObject BuyButton;
    public GameObject NoMoeny;
    public GameObject CheckButton;

    public GameObject MainMenu;
    public GameObject Shop;

    public GameObject[] Tap1Buttons;
    public GameObject[] Tap2Buttons;

    public GameObject[] Stages;

    public GameObject StageSelect;

    public Text Cointext;
    public int Coin;
    public GameObject Player;
    int ManaCoin;
    int glassCoin;
    int ShilledCoin;
    int SkilCoin;
    int BuyKey;
    
    public void ShopReset()
    {
        BuyKey = 0;
        ManaCoin = 2;
        glassCoin = 30;
        ShilledCoin = 10;
        SkilCoin = 10;

    }
    // Start is called before the first frame update
    void Start()
    {
        BuyKey = 0;
        ManaCoin = 2;
        glassCoin = 30;
        ShilledCoin = 10;
        SkilCoin = 10;
        Player = GameObject.Find("player").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        Coin = GameObject.Find("player").GetComponent<PlayerScript>().money;
        Cointext.text = "Coin : " + Coin.ToString();   
    }

    public void SkilUp()
    {
        BuyButton.gameObject.SetActive(true);
        BuyKey = 4;
    }

    public void ManaPotion()
    {
        BuyButton.gameObject.SetActive(true);
        BuyKey = 1;
    }

    public void glassUp()
    {
        BuyButton.gameObject.SetActive(true);
        BuyKey = 2;
    }

    public void Shilled()
    {
        BuyButton.gameObject.SetActive(true);
        BuyKey = 3;
    }

    public void BuyOkButton()
    {
        BuyButton.gameObject.SetActive(false);
        switch (BuyKey)
        {
            case 1:
                if(ManaCoin >= Coin)
                {
                    NoMoeny.gameObject.SetActive(true);
                }
                else if(ManaCoin < Coin)
                {
                   GameObject.Find("player").GetComponent<PlayerScript>().manaPotionLeft++;
                    CheckButton.SetActive(true);
                    GameObject.Find("player").GetComponent<PlayerScript>().money -= ManaCoin;
                }
                break;
            case 2:
                if (glassCoin >= Coin)
                {
                    NoMoeny.gameObject.SetActive(true);
                }
                else if (glassCoin < Coin)
                {
                    if(SHADERAAAAAAAAA.intensity >100 && SHADERAAAAAAAAA.intensity <500)
                    {
                        SHADERAAAAAAAAA.intensity += 100;
                    }
                    CheckButton.SetActive(true);
                    GameObject.Find("player").GetComponent<PlayerScript>().money -= glassCoin;
                }
                break;
            case 3:
                if (ShilledCoin >= Coin)
                {
                    NoMoeny.gameObject.SetActive(true);
                }
                else if (ShilledCoin < Coin)
                {
                    GameObject.Find("player").GetComponent<PlayerScript>().shield = true;
                    CheckButton.SetActive(true);
                    GameObject.Find("player").GetComponent<PlayerScript>().money -= ShilledCoin;
                }
                break;

            case 4:
                if (SkilCoin >= Coin)
                {
                    NoMoeny.gameObject.SetActive(true);
                }
                else if (SkilCoin <  Coin)
                {
                    //GameObject.Find("Player").GetComponent<ShopData>().Coin += 10;
                    CheckButton.SetActive(true);
                    GameObject.Find("player").GetComponent<PlayerScript>().money -= SkilCoin;
                    SkilCoin += 10;
                }
                break;
        }
        BuyKey = 0;
    }

    public void BuyNoButton()
    {
        BuyButton.gameObject.SetActive(false);
    }

    public void NoMoneyButton()
    {
        NoMoeny.gameObject.SetActive(false);
    }

    public void CheckOkButton()
    {
        CheckButton.gameObject.SetActive(false);
    }

    public void Tap1()
    {
        for(int i=0; i<Tap1Buttons.Length; i++)
        {
            Tap1Buttons[i].SetActive(true);
        }
        GameObject.Find("Button-Tap1").GetComponent<Image>().color = new Color(0.55f, 0.55f, 0.55f);
        for (int i=0; i<Tap2Buttons.Length; i++)
        {
            Tap2Buttons[i].SetActive(false);
        }
        GameObject.Find("Button-Tap2").GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    public void Tap2()
    {
        for (int i = 0; i < Tap1Buttons.Length; i++)
        {
            Tap1Buttons[i].SetActive(false);
            
        }
        GameObject.Find("Button-Tap1").GetComponent<Image>().color = new Color(255, 255, 255, 255);
        for (int i = 0; i < Tap2Buttons.Length; i++)
        {
            Tap2Buttons[i].SetActive(true);
        }
        GameObject.Find("Button-Tap2").GetComponent<Image>().color = new Color(0.55f, 0.55f, 0.55f);
    }

    public void MainUI()
    {
        Shop.SetActive(false);
        StageSelect.SetActive(true);
    }

    public void ShopUI()
    {
        Shop.SetActive(true);
        StageSelect.SetActive(false);
    }

    public void StartUI()
    {
        MainMenu.SetActive(false);
        StageSelect.SetActive(true);
    }

    public void MainReturn()
    {
        StageSelect.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Stage1()
    {
        Player.transform.position = new Vector3(-7, -2.5f, 0);
        DontDestroyOnLoad(Player);
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        Debug.Log(PlayerPrefs.GetInt("Stage1"));
        if(PlayerPrefs.GetInt("Stage1") == 2)
        {
            Player.transform.position = new Vector3(-10, -16.5f, 0);
            DontDestroyOnLoad(Player);
            SceneManager.LoadScene("Stage2");
        }
    }

    public void Stage3()
    {
        if(PlayerPrefs.GetInt("Stage2") == 2)
        {
            Player.transform.position = new Vector3(-41, -24f, 0);
            DontDestroyOnLoad(Player);
            SceneManager.LoadScene("Stage3");
        }
    }
}
