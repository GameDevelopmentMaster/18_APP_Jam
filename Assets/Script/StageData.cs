using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData : MonoBehaviour
{
    /*
     *  0 - 땅
     *  1 - 플레이어
     *  2 - 용가리
     * */
    public Sprite[] Gra1080;
    public Sprite[] Gra720;
    public Sprite[] Gra480;
    public Sprite[] Gra240;
    public Sprite[] Gra144;

    public void ChangeSprite (int change)
    {
        foreach (Transform child in transform)
        {
            SpriteRenderer spr = child.GetComponent<SpriteRenderer>();
            ObjectData data = child.GetComponent<ObjectData>();
            ObjectData.SPRITE type = data.type;

            //child is your child transform
            switch (change)
            {
                case 1: // 1080
                    spr.sprite = Gra1080[(int)type];
                    break;
                case 2: // 720
                    spr.sprite = Gra720[(int)type];
                    break;
                case 3: // 480
                    spr.sprite = Gra480[(int)type];
                    break;
                case 4: // 240
                    spr.sprite = Gra240[(int)type];
                    break;
                case 5: // 144
                    spr.sprite = Gra144[(int)type];
                    break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeSprite(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
