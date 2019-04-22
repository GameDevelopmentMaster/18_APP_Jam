using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    /*
     *  0 - 땅
     *  1 - 플레이어
     *  2 - 용가리
     *  3 - 코인
     * */
    public enum SPRITE
    {
        GROUND = 0,
        PLAYER,
        MOB,
        COIN
    }
    public SPRITE type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
