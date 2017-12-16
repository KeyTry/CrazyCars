using UnityEngine;

public class SpawnCity :MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;

    void OnTriggerExit ( Collider col )
    {
        if( col.CompareTag( "Player" ) )
        {
            PoolManager.Spawn( prefab, spawnPoint.position, spawnPoint.rotation );
        }
    }
}
