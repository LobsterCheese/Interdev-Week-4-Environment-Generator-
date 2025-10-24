using UnityEngine;

public class GOD : MonoBehaviour
{

    private float GODSPEED = 2f;
    private Rigidbody2D RB2D;
    private bool RAPTURE = false;

    private SpriteRenderer SPRITER;
    public RuntimeAnimatorController GODDANCE;
    private bool DANCE = false;
    public RuntimeAnimatorController GODIDLE;

    private int DANCETIMER = 500;

    private Vector2 HEAVEN; 

    public Sprite HOLDING;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        SPRITER = GetComponent<SpriteRenderer>();

        HEAVEN = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(RAPTURE)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = GODDANCE as RuntimeAnimatorController;
            if(DANCETIMER > 0)
            {
                DANCE = true;
                RB2D.linearVelocity = new Vector2(0, 0);
            }
            else
            {
                DANCE = false;
            }
            DANCETIMER--;
        }
        Debug.Log(DANCE);
    }

    private void FixedUpdate()
    {
        if (!RAPTURE)
        {
            RB2D.AddForce(transform.right * -GODSPEED);
        }
        else
        {
            if (!DANCE)
            {
                RB2D.AddForce(transform.up * GODSPEED);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Flub")
        {
            RB2D.linearVelocity = new Vector2(0, 0);
            if (!RAPTURE)
            {
                Destroy(other.gameObject);
                RAPTURE = true;
            }
            SPRITER.sprite = HOLDING;
        }

        if (other.tag == "GODkiller")
        {
            Destroy(gameObject);
        }

        if (other.tag == "HEAVEN")
        {
            RB2D.linearVelocity = new Vector2(0, 0);
            transform.position = HEAVEN;
        }
    }
}
