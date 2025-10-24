using UnityEngine;

public class FlubSpawner : MonoBehaviour
{

    public GameObject flubBaby;
    public GameObject birdAngel;
    public GameObject GOD;
    int birthTimer = 10000;
    int birdTimer = 2000;
    int flubAmount;
    int numberOfGOD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //generates new position
        int randX = Random.Range(-5, 5);
        int randY = Random.Range(-2, 2);
        //constantly counts down to new Flub
        birthTimer--;
        birdTimer--;

        if (birdTimer <= 0)
        {
            birdTimer = 2000;
            Instantiate(birdAngel, new Vector3(randX, randY, 0), Quaternion.identity);
        }

        if(birthTimer <= 0 )
        {
            birthTimer = 10000;
            Instantiate(flubBaby, new Vector3(randX, randY, 0), Quaternion.identity);
            flubAmount = GameObject.FindGameObjectsWithTag("Flub").Length;
        }

        if(flubAmount > 6)
        {
            numberOfGOD = GameObject.FindGameObjectsWithTag("GOD").Length;
            if (numberOfGOD < 1)
            {
                Instantiate(GOD, new Vector3(22f, 5f, 0), Quaternion.identity);
            }
        }
    }
}
