using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelState : IEnemyState
{
    private Enemy enemy;

    private float idleTimer;

    private float idleDuration;

    public void Enter(Enemy enemy)
    {
        idleDuration = UnityEngine.Random.Range(1,10);
        this.enemy = enemy;
    }

    public void Execute()
    {
        Idle();

        if(enemy.target != null)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {
      
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "Knife")
        {
            enemy.target = Player.Instance.gameObject;
        }
    }

    private void Idle()
    {
        enemy.myAnimator.SetFloat("speed", 0);

        idleTimer += Time.deltaTime;

        if(idleTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolState());
        }
    }
}
