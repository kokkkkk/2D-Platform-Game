using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IEnemyState
{
    private Enemy enemy;

    private float throwTimer;
    private float throwCoolDown = 3;
    private bool canFlow = true;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        ThrowKnife();
    
        if(enemy.InMeleeRange)
        {
            enemy.ChangeState(new MeleeState());
        }

        else if(enemy.target != null)
        {
            enemy.Move();
        }
        else
        {
            enemy.ChangeState(new IdelState());
        }
    }

    public void Exit()
    {
       
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void ThrowKnife()
    {
        throwTimer += Time.deltaTime;

        if(throwTimer >= throwCoolDown)
        {
            canFlow = true;
            throwTimer = 0;
        }

        if(canFlow)
        {
            canFlow = false;
            enemy.myAnimator.SetTrigger("throw");
        }
    }
}
