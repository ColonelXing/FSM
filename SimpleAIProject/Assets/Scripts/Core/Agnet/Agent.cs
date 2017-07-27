using UnityEngine;
using System.Collections;

/// <summary>
/// 角色对象代理，逻辑上的角色对象
/// ComponentPlayer是给策划使用的角色对象入口
/// </summary>
public class Agent : MonoBehaviour
{
    [System.NonSerialized]
    public Transform Transform;
    [System.NonSerialized]
    public GameObject GameObject;
    [System.NonSerialized]
    public CharacterController Controller;
    [System.NonSerialized]
    public AnimSet AnimSet;
    [System.NonSerialized]
    public ComponentSound Sound;
    [System.NonSerialized]

    public BlackBoard BlackBoard = new BlackBoard();

    public E_EntityType EntityType = E_EntityType.None;

    private Vector3 CollisionCenter;

    public Vector3 Position { get { return Transform.position; } }

    void Awake()
    {
        Transform = transform;
        GameObject = gameObject;
        Controller = GetComponent<CharacterController>();
        AnimSet = GetComponent<AnimSet>();
        Sound = Transform.GetOrAdd<ComponentSound>();

        BlackBoard.Owner = this;
        BlackBoard.GameObject = GameObject;

        CollisionCenter = Controller.center;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
