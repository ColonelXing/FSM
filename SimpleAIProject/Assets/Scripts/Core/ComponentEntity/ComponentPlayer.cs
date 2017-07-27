using UnityEngine;
using System.Collections;
using System;

public static class Player
{
    public static ComponentPlayer Instance;
}

[RequireComponent(typeof(Agent))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(ComponentFSM))]
public class ComponentPlayer : MonoBehaviour, ICmdHandler {

    private Agent Owner;
    private Transform Transform;

    public Agent Agent { get { return Owner; } }

    //test
    Vector3 Direction;
    float Force;
    bool IsShow = false;

    void Awake()
    {
        Player.Instance = this;
        Transform = transform;
        Owner = GetComponent<Agent>();

    }
    // Use this for initialization
    void Start () {
        Owner.BlackBoard.AddCmdHandler(this);
	}
	
	// Update is called once per frame
	void Update () {

        /////////////////Test//////////////////
        // input_Begin
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(h, 0, v);
        moveDirection.Normalize();

        Direction = moveDirection;
        Force = 1.0f;

        //X 鼠标左键或J
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
        {
            CreateAttackCmd();
        }
        //O 鼠标右键或K
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.K))
        {
            CreateAttackCmd();
        }
        //躲避 鼠标中键或L 
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.L))
        {
            CreateDodgeCmd();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            IsShow = !IsShow;
            CreateWeaponShow();
        }

        if (Direction != Vector3.zero)
        {
            CreateMoveCmd();
        }
        else
        {
            CreateStopCmd();
        }
        // input_End
    }

    private void CreateWeaponShow()
    {
        CmdWeaponShow cmd = CmdFactory.Create(CmdFactory.E_CmdType.WeaponShow) as CmdWeaponShow;
        if (IsShow)
            Owner.BlackBoard.WeaponState = E_WeaponState.Attacking;
        else
            Owner.BlackBoard.WeaponState = E_WeaponState.NotInHands;

        cmd.IsShow = IsShow;
        Owner.BlackBoard.AddCmd(cmd);
    }

    /// <summary>
    /// 移动
    /// </summary>
    void CreateMoveCmd()
    {
        CmdMove cmd = CmdFactory.Create(CmdFactory.E_CmdType.Move) as CmdMove;
        Owner.BlackBoard.DesiredDirection = Direction;
        Owner.BlackBoard.DesiredPosition = Owner.Position;
        Owner.BlackBoard.MoveSpeedModifier = Force;
        Owner.BlackBoard.AddCmd(cmd);
    }
    /// <summary>
    /// 停止
    /// </summary>
    void CreateStopCmd()
    {
        CmdIdle cmd = CmdFactory.Create(CmdFactory.E_CmdType.Idle) as CmdIdle;
        Owner.BlackBoard.DesiredPosition = Owner.Position;
        Owner.BlackBoard.AddCmd(cmd);
    }
    /// <summary>
    /// 攻击
    /// </summary>
    void CreateAttackCmd()
    {

    }
    /// <summary>
    /// 躲闪
    /// </summary>
    void CreateDodgeCmd()
    {

    }

    public void ProcessCmd(ICmd cmd)
    {
    }
}
