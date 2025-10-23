using UnityEngine;

public class FlubSpawner : MonoBehaviour
{

    public GameObject flubBaby;
    public GameObject GOD;
    int birthTimer = 10000;
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

        if(birthTimer <= 0 )
        {
            birthTimer = 10000;
            Instantiate(flubBaby, new Vector3(randX, randY, 0), Quaternion.identity);
            flubAmount = GameObject.FindGameObjectsWithTag("Flub").Length;
        }

        if(flubAmount > 8)
        {
            numberOfGOD = GameObject.FindGameObjectsWithTag("GOD").Length;
            if (numberOfGOD < 1)
            {
                Instantiate(GOD, new Vector3(22f, 5f, 0), Quaternion.identity);
            }
        }
    }
}
