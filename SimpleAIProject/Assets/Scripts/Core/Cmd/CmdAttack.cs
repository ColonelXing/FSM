using UnityEngine;
using System.Collections;

public class CmdAttack : ICmd
{
    public CmdAttack() : base(CmdFactory.E_CmdType.Attack)
    {

    }
}
