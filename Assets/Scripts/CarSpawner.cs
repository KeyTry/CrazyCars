using System.Collections;
using UnityEngine;

public class CarSpawner :MonoBehaviour
{
    public GameObject[] carros;
    CarroScript script;
    // Use this for initialization
    void Start ( )
    {
        StartCoroutine( spawnCars( ) );
    }

    // Update is called once per frame
    void Update ( )
    {

    }

    IEnumerator spawnCars ( )
    {
        int randomNum = Random.Range( 0, 3 );
        int randomDistanceZ = Random.Range( -5, 5 );
        int randomDistanceX = Random.Range( -1, 1 );
        int randomChance = Random.Range( 1, 8 );
        if( randomChance == 3 )
        {
            GameObject newCar = Instantiate( carros[ randomNum ], this.transform.position + new Vector3( randomDistanceX, 0f, randomDistanceZ ), this.transform.rotation );
            script = newCar.GetComponent<CarroScript>( );
            script.speed = Random.Range( 0.5f, 3f );
            script.InitVelocity( );
            //			Destroy (newCar, 5f);
        }
        float newTime = Random.Range( 0.5f, 2f );
        yield return new WaitForSeconds( newTime );
        StartCoroutine( spawnCars( ) );
    }
}
