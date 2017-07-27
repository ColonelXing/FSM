using UnityEngine;
using System.Collections;
using System;

public class FSMBoss01 : FSM
{
    public FSMBoss01(Agent owner, Animation anim) : base(owner, anim) { }

    public override void ProcessCmd(ICmd cmd)
    {
    }
}
