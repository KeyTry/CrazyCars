using UnityEngine;

public class PowerSpawn :MonoBehaviour
{
    public GameObject power;

    // Use this for initialization
    void Start ( )
    {
        spawnPower( );
    }

    void spawnPower ( )
    {
        int randomChance = Random.Range( 0, 9 );
        if( randomChance == 5 )
        {
            float randomDistanceZ = Random.Range( -15f, 15f );
            float randomDistanceX = Random.Range( -1.5f, 1.5f );
            GameObject newCar = Instantiate( power, this.transform.position + new Vector3( randomDistanceX, 0f, randomDistanceZ ), this.transform.rotation );
        }
    }
}
