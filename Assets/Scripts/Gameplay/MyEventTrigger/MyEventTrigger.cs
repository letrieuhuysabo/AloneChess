using System;
using System.Collections.Generic;
using UnityEngine;

public class MyEventTrigger : MonoBehaviour
{
    public static MyEventTrigger instance;
    List <Action> playerMoveEventTriggers;
    List <Action> playerFallEventTriggers;
    public List<Action> PlayerMoveEventTriggers { get => playerMoveEventTriggers; set => playerMoveEventTriggers = value; }
    public List<Action> PlayerFallEventTriggers { get => playerFallEventTriggers; set => playerFallEventTriggers = value; }

    


    void Awake()
    {
        instance = this;
        playerMoveEventTriggers = new();
        playerFallEventTriggers = new();
    }
    
    public void OnPlayerMove()
    {
        foreach (Action action in playerMoveEventTriggers)
        {
            action.Invoke();
        }
    }
    public void OnPlayerFall()
    {
        foreach (Action action in playerFallEventTriggers)
        {
            action.Invoke();
        }
    }
    
}
