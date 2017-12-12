using UnityEngine;

public class CityDestroyer :MonoBehaviour
{
    GameObject section;

    void Start ( )
    {
        section = transform.parent.gameObject;
    }

    void OnTriggerExit ( Collider col )
    {
        if( col.CompareTag( "Player" ) )
        {
            Destroy( section );
        }
    }
}
