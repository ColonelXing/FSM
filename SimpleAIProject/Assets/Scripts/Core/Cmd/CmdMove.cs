using UnityEngine;
using System.Collections;

public class CmdMove : ICmd
{
    public CmdMove() : base(CmdFactory.E_CmdType.Move)
    {

    }
}
