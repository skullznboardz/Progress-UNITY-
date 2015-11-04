using UnityEngine;
using System.Collections;

public class basicEnemyAI : MonoBehaviour {

    //Basic Enemy
    public Transform basicEnemy;

    //Total number of ships allowed on screen
    private float totalNumberofShips = 1;

    //Is the current spawn location clear of other ships?
    private bool isSpawnClear = true;

    //Number of basic ships allowed on screen at one time
    public static float numberOfBasicShips;

    //The current basic wave is still active
    private bool basicWaveFighting = false;

	// Update is called once per frame
    void Update()
    {
        if(numberOfBasicShips <= 0)
        {
            basicWaveFighting = false;
        }
        else
        {
            basicWaveFighting = true;
        }

        //A wave is currently fighting
        if(basicWaveFighting == true)
        {
            return;
        }
        //Detect how many ships have spawned against the random number that this wave will be tasked with
        else if (basicWaveFighting == false && numberOfBasicShips < totalNumberofShips)
        {
            totalNumberofShips = Random.Range(2, 5);
            StartCoroutine("SpawnEnemy");
        }
    }
    
    //Check to see if spawn location is clear for ship to spawn at
    void OnCollisionEnter(Collision other)
    {
        //Detects that if the collider called out aboce is in layer 8
        if(other.gameObject.layer != 11)
        {
            isSpawnClear = true;
        }
        else if (other.gameObject.layer == 11)
        {
            isSpawnClear = false;
        }
    }

    IEnumerator SpawnEnemy()
    {
        basicWaveFighting = true;
        //Spawn ships if the number of ships hasnt reached the maximum number of ships
        for (int i = 0; i < totalNumberofShips; i++)
        {
            if (isSpawnClear == true)
            {
                //Spawns the bullet that is attached to the first statement and at the position and rotation of the second statement (need to figure out how to correct the position)
                Instantiate(basicEnemy, new Vector3(Random.Range(-4, 4), 0f, 7.5f), Quaternion.Euler(0, 180, 0));
                numberOfBasicShips++;
            }
        }
        yield return null;
    }
}
