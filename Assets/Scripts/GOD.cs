using UnityEngine;

public class GOD : MonoBehaviour
{

    private float GODSPEED = 2f;
    private Rigidbody2D RB2D;
    private bool RAPTURE = false;

    private SpriteRenderer SPRITER;

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

    }

    private void FixedUpdate()
    {
        if (!RAPTURE)
        {
            RB2D.AddForce(transform.right * -GODSPEED);
        }
        else
        {
            RB2D.AddForce(transform.up * GODSPEED);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Flub")
        {
            RB2D.linearVelocity = new Vector2(0, 0);
            Destroy(other.gameObject);
            RAPTURE = true;
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
