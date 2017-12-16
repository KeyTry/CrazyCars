using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn :MonoBehaviour
{

    private bool isDisable;
    public Transform destructor;

    private void Start ( )
    {
        if( destructor == null )
        {
            destructor = GameObject.Find( "DESTRUCTOR" ).transform;
        }
    }

    private void Update ( )
    {
        if( transform.position.z <= destructor.position.z && !isDisable )
        {
            isDisable = true;
            PoolManager.DeSpawn( this.gameObject );
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
