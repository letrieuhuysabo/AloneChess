using System;
using System.Collections.Generic;
using UnityEngine;

public class MyEventTrigger : MonoBehaviour
{
    public static MyEventTrigger instance;
    List <Action> playerMoveEventTriggers;
    List <Action> playerFallEventTriggers;
    List <Action> playerDeadEventTriggers;
    public List<Action> PlayerMoveEventTriggers { get => playerMoveEventTriggers; set => playerMoveEventTriggers = value; }
    public List<Action> PlayerFallEventTriggers { get => playerFallEventTriggers; set => playerFallEventTriggers = value; }
    public List<Action> PlayerDeadEventTriggers { get => playerDeadEventTriggers; set => playerDeadEventTriggers = value; }


    void Awake()
    {
        instance = this;
        playerMoveEventTriggers = new();
        playerFallEventTriggers = new();
        playerDeadEventTriggers = new();
    }
    void OnEvent(List<Action> actions)
    {
        foreach (Action action in actions)
        {
            action.Invoke();
        }
    }
    public void OnPlayerMove()
    {
        OnEvent(playerMoveEventTriggers);
    }
    public void OnPlayerFall()
    {
        OnEvent(playerFallEventTriggers);
    }
    public void OnPlayerDead()
    {
        OnEvent(playerDeadEventTriggers);
    }
}
