using UnityEngine;
using System.Collections;

public class CmdDeath : ICmd
{
    public CmdDeath() : base(CmdFactory.E_CmdType.Death)
    {

    }
}
