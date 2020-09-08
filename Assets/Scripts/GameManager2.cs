using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public enum EventEnum
    {
        ON_GAME_START = 0,
        ON_GAME_EXIT = 1
    }

    //De Dictionary waar je al je events in opslaat.
    //De delegate zorgt ervoor dat je functies kan opslaan in de dictionary.
    //De Dictionary zorgt ervoor dat je een Event kan opslaan (EventEnum) en dat je een functie kan opslaan (VoidDelegate).
    //De naam van de dictionary is 'allEvents.'
    public delegate void VoidDelegate();
    private Dictionary<EventEnum, VoidDelegate> allEvents = new Dictionary<EventEnum, VoidDelegate>();

    //Als je een event wil toevoegen aan de eventmanager dan roep je deze functie aan.
    //Als eerste parameter geef je het cijfer van het event mee en als tweede parameter de funtie die je wil toevoegen.
    public void SubscribeToEvent(EventEnum eventType, VoidDelegate func)
    {
        if (allEvents.ContainsKey(eventType))
        {
            allEvents[eventType] += func;
        }
    }

    //Als je een event wil weghalen dan roep je deze functie aan.
    //Als eerste parameter doe je het getal van het event 'RemoveListener(1,);'
    //Als tweede parameter doe je de functie die je wil toevoegen 'RemoveListener(1, RandomFunctie);'
    public void RemoveListener(EventEnum eventType, VoidDelegate func)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType] != null)
        {
            allEvents[eventType] -= func;
        }
    }

    //Hiermee speel je een event af.
    //Dit doe je dan door 'RaiseEvent();'
    //In de parameters roep je het event aan wat je wil afspelen 'RaiseEvent(1);'
    public void RaiseEvent(EventEnum eventType)
    {
        if (allEvents.ContainsKey(eventType) && allEvents[eventType] != null)
        {
            allEvents[eventType].Invoke();
        }
    }

    //Zo kun je een functie toevoegen aan een eventmanager.
    //Met 'RaiseEvent' speel je het event af.
    public void EndParticle()
    {
        Debug.Log("Show particle");
        SubscribeToEvent(0, EndParticle);
    }
}
