using UnityEngine;
using System.Collections;
using System;

public class ComponentFSM : MonoBehaviour, ICmdHandler
{
    private FSM FSM;
    private Animation Animation;
    private Agent Owner;

    public E_FSMType TypeOfFSM = E_FSMType.None;

    void Awake()
    {
        Owner = GetComponent<Agent>();
        Animation = GetComponent<Animation>();

        switch (TypeOfFSM)
        {
            case E_FSMType.Player:
                FSM = new FSMPlayer(Owner, Animation);
                AddAnimSet<SetPlayer>();
                break;
            case E_FSMType.Boss01:
                FSM = new FSMBoss01(Owner, Animation);
                AddAnimSet<SetBoss01>();
                break;
            default:
                Debug.LogError(name + " Unkown Type of FSM. Type:" + TypeOfFSM);
                break;
        }
    }


    // Use this for initialization
    void Start ()
    {
        FSM.Initialize();
        Owner.BlackBoard.AddCmdHandler(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
        FSM.Update();
	}

    public void ProcessCmd(ICmd cmd)
    {
        if (cmd != null && cmd.IsFailed)
            return;
        FSM.ProcessCmd(cmd);
    }

    public void Activate(Transform spawn)
    {
        Animation.Stop();
        Animation.Rewind();
        FSM.Initialize();
    }

    public void Deactivate()
    {
        FSM.Reset();
    }

    /// <summary>
    /// 添加知道对象的FSM Set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    void AddAnimSet<T>() where T : AnimSet
    {
        transform.GetOrAdd<T>();
    }

}
