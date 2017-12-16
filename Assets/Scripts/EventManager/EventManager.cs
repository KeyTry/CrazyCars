using System.Collections.Generic;
using UnityEngine.Events;

public class EventManager :Singleton<EventManager>
{
    private Dictionary<EventDefinition, UnityEvent> eventDictionary;

    private void Awake ( )
    {
        if( eventDictionary == null )
        {
            eventDictionary = new Dictionary<EventDefinition, UnityEvent>( );
        }
    }

    private void _AddListener ( EventDefinition eventName, UnityAction listener )
    {
        UnityEvent thisEvent = null;
        if( eventDictionary.TryGetValue( eventName, out thisEvent ) )
        {
            thisEvent.AddListener( listener );
        } else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener( listener );
            eventDictionary.Add( eventName, thisEvent );
        }
    }

    private void _RemoveListener ( EventDefinition eventName, UnityAction listener )
    {
        UnityEvent thisEvent = null;
        if( eventDictionary.TryGetValue( eventName, out thisEvent ) )
        {
            thisEvent.RemoveListener( listener );
        }
    }

    private void _TriggerEvent ( EventDefinition eventName )
    {
        UnityEvent thisEvent = null;
        if( eventDictionary.TryGetValue( eventName, out thisEvent ) )
        {
            thisEvent.Invoke( );
        }
    }

    public static void AddListener ( EventDefinition eventName, UnityAction listener )
    {
        Instance._AddListener( eventName, listener );
    }

    public static void RemoveListener ( EventDefinition eventName, UnityAction listener )
    {
        Instance._RemoveListener( eventName, listener );
    }

    public static void TriggerEvent ( EventDefinition eventName )
    {
        Instance._TriggerEvent( eventName );
    }
}