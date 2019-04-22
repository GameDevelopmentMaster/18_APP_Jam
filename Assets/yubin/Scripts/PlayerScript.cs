using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // 플레이어 변수
    public bool shield;
    public int mana = 100;
    public int money = 0;

    public Camera cam; // 카메라
    public bool drawLine; // (스킬) 선 그리기

    public ParticleSystem particleMana;
    public ParticleSystem particleHp;
    public GameObject Skil;   // 스킬 오브젝트
    public GameObject Float; // 텍스트 효과 프리팹

    enum SKILL
    {
        none = -1,
        pyung,
        fire,
        water,
        electric
    }
    private SKILL skillIdx = SKILL.none; // 스킬 (-1 : 없다)

    // 스킬 값들
    enum STAT_INDEX
    {
        damage = 0,
        cost,
        cooldown, // 쿨다운
        canFire // 사용 가능?
    }
    public int pyungLevel;
    public int fireballLevel;
    public float[] pyungStat; // 평타 스탯 => pyungStat[STAT_INDEX enum]
    public float[] fireballStat; // 스킬 스탯 => fireballStat[STAT_INDEX enum]

    // public int fireballCost = 10; // 화염구 마나 가격
    public int manaPotionLeft = 5; // 마나 포션 수

    public float moveVel = 3; // 이동속도
    public float friction = 0.65f; // 마찰력 - 높으면 속도 그대로, 낮으면 더 빨리 멈춤
    public bool onGround = false; // 땅에 닿았는지 체크
    public bool canJump = false; // 점프 가능?
    public bool isKnockBack = false; // 넉백중?

    // 레이캐스트로 땅에 닿는지 체크할 때 최대 거리
    public float groundCheckDist = 0.1f;

    private Rigidbody2D rb;
    private BoxCollider2D bb;
    private LineRenderer line;
    private float timeing;
    public void ResetAll()
    {
        pyungStat = new float[] { 10, 0, 0.5f, 0 };
        fireballStat = new float[] { 20, 10, 3f, 0 };

        pyungLevel = 0;
        fireballLevel = 0;


        shield = false;
        mana = 100;
        money = 0;
        manaPotionLeft = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        bb = GetComponent<BoxCollider2D>();
        line = GetComponent<LineRenderer>();
        StartCoroutine(CoolDown(pyungStat, 0));
        StartCoroutine(CoolDown(fireballStat, 0));
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("MainMenu") != null)
        {
            return;
        }
        else
        {
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
        // camera
        cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, transform.position.x, 0.1f),
                                            transform.position.y, -10);
    }

    // 글자를 위로 두둥실
    void ShowText (string showtext)
    {
        GameObject go = Instantiate(Float, transform.position, Quaternion.identity);
        TextMesh text = go.GetComponent<TextMesh>();
        text.text = showtext; // WTF LOL
    }

    // 마법 발사아아
    void FireMagic()
    {
        float magicCost = 0, magicDamage = 10, magicCoolDown = 0;
        float magicRange = 5f;
        float canFire;
        PlayerSkilScript.GRAPHIC graphicIndex = PlayerSkilScript.GRAPHIC.light;
        float[] stat = null;

        // 변수 설정
        switch (skillIdx)
        {
            case SKILL.pyung: // 평타
                stat = pyungStat;
                graphicIndex = PlayerSkilScript.GRAPHIC.light;
                break;

            case SKILL.fire: // 불 알
                stat = fireballStat;

                // TODO : FIRE TEXTURE
                graphicIndex = PlayerSkilScript.GRAPHIC.fire;
                break;

            default:
                return;
        }
        magicCost = stat[(int)STAT_INDEX.cost];
        magicDamage = stat[(int)STAT_INDEX.damage];
        magicCoolDown = stat[(int)STAT_INDEX.cooldown];
        
        canFire = stat[(int)STAT_INDEX.canFire];

        if (canFire != 0)
        {
            if (mana >= magicCost)
            {
                // 빵야
                // PLAY TEAM FORTRESS 2!!!!!
                // GOD GAME!!
                GameObject go = Instantiate(Skil, transform.position, Quaternion.identity);
                PlayerSkilScript ps = go.GetComponent<PlayerSkilScript>();

                Vector3 mp = Input.mousePosition;
                mp.z = 10;

                Vector3 delta = Camera.main.ScreenToWorldPoint(mp) - transform.position;
                ps.dir = delta.normalized;
                ps.pos = transform.position;
                ps.damage = magicDamage;
                ps.dist = magicRange;
                ps.type = graphicIndex;

                if (skillIdx == SKILL.fire)
                    go.transform.Translate(new Vector2(0.9f, -1.5f));

                // 쿨다운
                mana -= (int)magicCost;
                StartCoroutine(CoolDown(stat, magicCoolDown));
            }
            else
            {
                ShowText("마나가 바닥났습니다;");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // LINE~~~~~~!~!~!~!~!~
        if (drawLine)
        {
            line.positionCount = 2; // 선 보이기

            Vector3 mp = Input.mousePosition;
            mp.z = 10;
            Vector3 delta = Camera.main.ScreenToWorldPoint(mp) - transform.position;

            Vector3 dir = delta.normalized; // 화살표 방향
            float distance = 5f; // 화살표 길이 
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + dir * distance);
        }
        else
            line.positionCount = 0; // 선 없애기

        // ground check
        RaycastHit2D hit = Physics2D.BoxCast(bb.bounds.center, bb.bounds.extents * 2, 0, new Vector2(0, -1), groundCheckDist, 1 << LayerMask.NameToLayer("Ground"));
        if (hit.transform != null)
            onGround = true;
        else
            onGround = false;
        // Debug.DrawLine(bb.bounds.center, bb.bounds.center + bb.bounds.extents + new Vector3(0, -1) * groundCheckDist);


        // 스킬!!!
        if (Input.GetKey(KeyCode.Q)) // 불 알
            skillIdx = SKILL.fire;
        else
            skillIdx = SKILL.pyung;

        // 포션!!!
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (manaPotionLeft > 0)
            {
                manaPotionLeft--;
                mana = 100;

                ShowText("포션 들이킴! (" + manaPotionLeft + "개 남음)"); // WTF LOL

                particleMana.Play();
            }
            else
            {
                ShowText("포션이 바닥났습니다;");
            }
        }

        if (skillIdx != SKILL.none)
        {
            if (skillIdx != SKILL.pyung)
                drawLine = true;
            else
                drawLine = false;

            if (Input.GetMouseButtonDown(0))
                FireMagic();
        }
        else
            drawLine = false;

        // input
        int moveH = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        bool moveJump = Input.GetKey(KeyCode.Space);

        if (!isKnockBack)
        {
            if (moveH != 0)
            {
                if(moveH == 1)
                {

                }
                else if(moveH == -1)
                {

                }
                if (rb.velocity.x * moveH < moveVel)
                    rb.velocity += new Vector2(moveH, 0);
                else
                    rb.velocity = new Vector2(moveH * moveVel, rb.velocity.y);
            }
            else
                rb.velocity *= new Vector2(friction, 1);

            if (moveJump && onGround)
            {
                onGround = false;
                rb.velocity = new Vector2(rb.velocity.x, 10);
            }
        }
    }

    private IEnumerator CoolDown(float[] stat, float magicCoolDown)
    {
        stat[(int)STAT_INDEX.canFire] = 0;
        yield return new WaitForSeconds(magicCoolDown);
        stat[(int)STAT_INDEX.canFire] = 1;
    }

    private IEnumerator ShieldOff(float time)
    {
        yield return new WaitForSeconds(time);
        shield = false;
    }

    private IEnumerator KnockBack (Vector2 dir, float time)
    {
        rb.velocity = dir * -5f;
        isKnockBack = true;
        yield return new WaitForSeconds(time);
        isKnockBack = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (shield)
            {
                ShowText("쉴드 파괴!");
                Destroy(collision.gameObject);

                StartCoroutine(ShieldOff(0.5f));
            }
            else
            {
                ShowText("아앍;");
                StartCoroutine("Delay");

                Vector2 delta = (collision.transform.position - transform.position).normalized * 2f;
                delta.y = -5f;
                StartCoroutine(KnockBack(delta, 0.5f));
            }
        }
    }

    IEnumerator Delay()
    {
        particleHp.Play();
        yield return new WaitForSeconds(1f);
        GameObject A = Instantiate(this.gameObject, transform.position, Quaternion.identity);
        A = transform.gameObject;
        A.name = "player";
        Destroy(this.gameObject);
        if(SHADERAAAAAAAAA.intensity <= 100)
        {
            Application.Quit();
        }
        else
        {
            SHADERAAAAAAAAA.intensity -= 100;
        }
        
        DontDestroyOnLoad(A);
        SceneManager.LoadScene("Main");
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            Vector2 delta;
            if (shield)
            {
                ShowText("쉴드 망가짐!");

                // 쉴드
                StartCoroutine(ShieldOff(0.5f));
                delta = (collision.transform.position - transform.position).normalized * 0.5f;
            }
            else
            {
                StartCoroutine("Delay");
                delta = (collision.transform.position - transform.position).normalized * 2f;
                delta.y = -1f;
            }

            // 넉백
            StartCoroutine(KnockBack(delta, 0.5f));
        }

        if(collision.transform.tag == "Coin")
        {
            Destroy(collision.gameObject);
            money++;
        }
    }
}


