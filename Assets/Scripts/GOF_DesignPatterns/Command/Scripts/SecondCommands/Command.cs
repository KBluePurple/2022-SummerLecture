using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator anim);
    public abstract void Undo(Animator anim);
}

public class PerformJump : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetFloat("speed", 1);
        anim.SetTrigger("isJumping");
    }

    public override void Undo(Animator anim)
    {
        anim.SetFloat("speed", -1);
        anim.SetTrigger("isJumping");
    }
}

public class PerformKick : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetFloat("speed", 1);
        anim.SetTrigger("isKicking");
    }

    public override void Undo(Animator anim)
    {
        anim.SetFloat("speed", -1);
        anim.SetTrigger("isKicking");
    }
}

public class PerformPunch : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetFloat("speed", 1);
        anim.SetTrigger("isPunching");
    }

    public override void Undo(Animator anim)
    {
        anim.SetFloat("speed", -1);
        anim.SetTrigger("isPunching");
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim)
    {
        
    }

    public override void Undo(Animator anim)
    {
        
    }
}

public class MoveFoward : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetFloat("speed", 1);
        anim.SetTrigger("isWalking");
    }

    public override void Undo(Animator anim)
    {
        anim.SetFloat("speed", -1);
        anim.SetTrigger("isWalking");
    }
}