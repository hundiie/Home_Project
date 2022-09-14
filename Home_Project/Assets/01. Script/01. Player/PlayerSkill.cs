using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSkill : MonoBehaviourPun
{
    private PlayerInput _PlayerInput;
    private PlayerStatus _PlayerStatus;

    private GameObject GameObject_Q;
    private GameObject GameObject_W;
    private GameObject GameObject_E;
    private GameObject GameObject_R;

    private Skill Q;
    private Skill W;
    private Skill E;
    private Skill R;

    [Header("Prepab")]
    public GameObject Prepab_Q;
    public GameObject Prepab_W;
    public GameObject Prepab_E;
    public GameObject Prepab_R;
    
    [Header("Bullet")]
    public GameObject Bullet_Q;
    public GameObject Bullet_W;
    public GameObject Bullet_E;
    public GameObject Bullet_R;

    [Header("CoolTime")]
    public float CoolTime_Q;
    public float CoolTime_W;
    public float CoolTime_E;
    public float CoolTime_R;

    private void Start()
    {
        if (!photonView.IsMine) { return; }
        _PlayerInput = GetComponent<PlayerInput>();
        _PlayerStatus = GetComponent<PlayerStatus>();

        GameObject_Q = GameObject.FindWithTag("Q");
        Q = GameObject_Q.GetComponent<Skill>();
        Q.CoolTime = CoolTime_Q;

        GameObject_W = GameObject.FindWithTag("W");
        W = GameObject_W.GetComponent<Skill>();
        W.CoolTime = CoolTime_W;

        GameObject_E = GameObject.FindWithTag("E");
        E = GameObject_E.GetComponent<Skill>();
        E.CoolTime = CoolTime_E;

        GameObject_R = GameObject.FindWithTag("R");
        R = GameObject_R.GetComponent<Skill>();
        R.CoolTime = CoolTime_R;
    }

    private void Update()
    {
        if (!photonView.IsMine) { return; }

        if (_PlayerInput.Key_Q)
        {
            Skill_Q();
            Q.IsSkill();
        }

        if (_PlayerInput.Key_W)
        {
            W.IsSkill();
        }

        if (_PlayerInput.Key_E)
        {
            E.IsSkill();
        }

        if (_PlayerInput.Key_R)
        {
            R.IsSkill();
        }
    }

    void Skill_Q() 
    {
        if (Q.isSkill)
        {
            StartCoroutine(Shot_Q());
        }
    }

    IEnumerator Shot_Q()
    {
        Vector3 Mouse = GetMousePosition();
        
        Vector3 This = this.transform.position;
            
        GameObject bullet = PhotonNetwork.Instantiate(Bullet_Q.name, This, Quaternion.identity);
        bullet.transform.LookAt(Mouse);

        Vector3 Target = bullet.transform.forward * 7;
        while (bullet.transform.position != Target)
        {
            Debug.Log(Target);
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, Target, 1 * Time.deltaTime);
            yield return null;
        }
        Destroy(bullet);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

        return point;
    }
}
