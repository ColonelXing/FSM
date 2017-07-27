using System;
using System.Collections.Generic;
using UnityEngine;

public class StateBaseMove : FSMState
{
    protected string AnimName;
    protected float MaxSpeed;
    protected Quaternion FinalRotation = new Quaternion();
    protected Quaternion StartRotation = new Quaternion();
    protected float RotationProgress;

    public StateBaseMove(Agent owner, Animation anim) : base(owner, anim) { }

    protected E_MotionType GetMotionType()
    {
        if (Owner.BlackBoard.Speed > Owner.BlackBoard.MaxRunSpeed * 1.5f)
            return E_MotionType.Sprint;
        else if (Owner.BlackBoard.Speed > Owner.BlackBoard.MaxWalkSpeed * 1.5f)
            return E_MotionType.Run;
        return E_MotionType.Walk;
    }

    protected void PlayAnim(E_MotionType motion)
    {
        Owner.BlackBoard.MotionType = motion;

        AnimName = Owner.AnimSet.GetMoveAnim(Owner.BlackBoard.MotionType, E_MoveType.Forward, Owner.BlackBoard.WeaponSelected, Owner.BlackBoard.WeaponState);

        CrossFade(AnimName, 0.2f);
    }

}