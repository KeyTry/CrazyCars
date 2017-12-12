using UnityEngine;

public class SpawnCity :MonoBehaviour
{

    public Transform spawnPoint;

    void OnTriggerExit ( Collider col )
    {
        if( col.CompareTag( "Player" ) )
        {
            GameObject section = Instantiate( ( Resources.Load( "Section" ) ) as GameObject, spawnPoint.position, spawnPoint.rotation );
        }
    }
}
