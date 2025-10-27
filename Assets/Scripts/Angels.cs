using System;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using Random = UnityEngine.Random;

public class Angels : MonoBehaviour
{

    int decisionTimer;
    int deathTimer;
    int killTimer;
    private enum Actions { Flying, Sitting, Migrating};
    private Actions currentAction;

    private float decision;

    private Vector2 currentPosition;
    private Vector2 targetPosition;

    public GameObject HEAVEN;

    private RuntimeAnimatorController animController;
    private Animator Sprite;

    public RuntimeAnimatorController angelIdle;
    public RuntimeAnimatorController angelFly;

    //public GameObject flubBaby;
    //GameObject flub;

    private int flySpeed = 3;

    //[SerializeField]
    private float randomMove;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAction = Actions.Flying;
        Sprite = gameObject.GetComponent<Animator>();

        //deathTimer = Random.Range(40000, 70000);
        //deathTimer = 20;

        decisionTimer = Random.Range(100, 300);
        //deathTimer = 60;
        //killTimer = 300;


        //Debug.Log(Sprite);
    }

    // Update is called once per frame
    void Update()
    {
        //constantly counts down to a new position and to death
        //deathTimer--;
        decisionTimer--;

        if (decisionTimer < 0)
        {

            decision = Random.Range(0, Enum.GetNames(typeof(Actions)).Length - 1);
            //Debug.Log(decision);

            if (decision == 0)
            {
                currentAction = Actions.Sitting;
            }
            else if (decision == 1)
            {
                currentAction = Actions.Flying;
            }

            if (GameObject.FindGameObjectsWithTag("GOD").Length == 1)
            {
                currentAction = Actions.Migrating;
            }

            //reset decision timer
            decisionTimer = Random.Range(100, 300);
        }


        switch (currentAction)
        {
            //Angel sits
            case Actions.Sitting:
                {

                    targetPosition.x = transform.position.x;

                    targetPosition.y = transform.position.y;

                    this.GetComponent<Animator>().runtimeAnimatorController = angelIdle as RuntimeAnimatorController;

                    flySpeed = Random.Range(3, 6);

                }
                break;

            //Angel flys around
            case Actions.Flying:
                {

                    //randomised x pos
                    randomMove = Random.Range(-500, 500);
                    targetPosition.x += randomMove;

                    //randomised y pos
                    randomMove = Random.Range(-500, 500);
                    targetPosition.y += randomMove;

                    //move towards point
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, flySpeed * Time.deltaTime);

                    this.GetComponent<Animator>().runtimeAnimatorController = angelFly as RuntimeAnimatorController;

                }
                break;

            case Actions.Migrating:
                {
                    this.GetComponent<Animator>().runtimeAnimatorController = angelFly as RuntimeAnimatorController;
                    transform.position = Vector3.MoveTowards(transform.position, HEAVEN.transform.position, flySpeed * Time.deltaTime * 5);
                    decisionTimer = 99999;
                }
                break;
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("ho");
        if (other.tag == "GODkiller")
        {
            Debug.Log("AHUFHAOEUFHA");
            Destroy(gameObject); 
        }
    }

}