using UnityEngine;

public class CityDestroyer :MonoBehaviour
{
    private GameObject section;
    private bool isDisable;
    public Transform destructor;

    private void Start ( )
    {
        if( destructor == null )
        {
            destructor = GameObject.Find( "DESTRUCTOR" ).transform;
        }

        section = transform.parent.gameObject;
    }

    private void Update ( )
    {
        if( transform.position.z <= destructor.position.z && !isDisable )
        {
            isDisable = true;

            foreach( var item in section.GetComponentsInChildren<Spawneable>( true ) )
            {
                item.Dispose( );
            }
            PoolManager.DeSpawn( section );
        }
    }

    private void OnSpawned ( )
    {
        isDisable = false;
    }

    private void OnDespawned ( )
    {
        isDisable = true;
    }
}
