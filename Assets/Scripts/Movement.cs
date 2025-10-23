using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using Random = UnityEngine.Random;

public class Movement : MonoBehaviour
{

    int decisionTimer;
    int deathTimer;
    int killTimer;
    private enum Actions {Walking, Standing, Waving, Dying};
    private Actions currentAction;

    private float decision;

    private Vector2 currentPosition;
    private Vector2 targetPosition;

    private RuntimeAnimatorController animController;
    private Animator Sprite;

    public RuntimeAnimatorController flubIdle;
    public RuntimeAnimatorController flubWalk;
    public RuntimeAnimatorController flubWave;
    public RuntimeAnimatorController flubDie;

    //public GameObject flubBaby;
    //GameObject flub;

    private int walkSpeed = 1;

    //[SerializeField]
    private float randomMove; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAction = Actions.Standing;
        Sprite = gameObject.GetComponent<Animator>();

        //deathTimer = Random.Range(40000, 70000);
        //deathTimer = 20;

        decisionTimer = Random.Range(100, 700);
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

            decision = Random.Range(0, Enum.GetNames(typeof(Actions)).Length - 2);
            //Debug.Log(decision);

            if (decision == 0)
            {
                currentAction = Actions.Standing;
            }
            else if (decision == 1)
            {
                currentAction = Actions.Walking;
            }

            if(deathTimer < 0)
            {
                currentAction = Actions.Dying;
            }

            //reset decision timer
            decisionTimer = Random.Range(100, 700);
        }


        switch (currentAction)
        {
            //Flub stands still and plays an idle animation
            case Actions.Standing:
                {

                    targetPosition.x = transform.position.x;

                    targetPosition.y = transform.position.y;

                    this.GetComponent<Animator>().runtimeAnimatorController = flubIdle as RuntimeAnimatorController;

                    walkSpeed = Random.Range(1, 3);

                }
                break;

            //Flub will walk to a random point
            case Actions.Walking:
                {

                    //randomised x pos
                    randomMove = Random.Range(-200, 200);
                    targetPosition.x += randomMove;

                    //randomised y pos
                    randomMove = Random.Range(-200, 200);
                    targetPosition.y += randomMove;

                    //move towards point
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, walkSpeed * Time.deltaTime);

                    this.GetComponent<Animator>().runtimeAnimatorController = flubWalk as RuntimeAnimatorController;

                }
                break;

            //Flub will wave to another Flub
            case Actions.Waving:
                {

                    targetPosition.x = transform.position.x;

                    targetPosition.y = transform.position.y;

                    this.GetComponent<Animator>().runtimeAnimatorController = flubWave as RuntimeAnimatorController;

                }
                break;

            case Actions.Dying:
                {
                    this.GetComponent<Animator>().runtimeAnimatorController = flubDie as RuntimeAnimatorController;
                    killTimer--;
                    if (killTimer < 0)
                    {
                        Destroy(gameObject);
                    }
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Flub")
        {
            currentAction = Actions.Waving;
            decisionTimer = 240;
        }

        walkSpeed *= -1;
    }

}