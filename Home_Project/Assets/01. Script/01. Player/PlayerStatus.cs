using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviourPun
{
    private NavMeshAgent _NavMeshAgent;
    public GameObject Canvas;
    
    private float HP = 2334f;
    private float MP  = 1565f;

    [Header("HP")]
    public float MaxHP = 2334f;
    public float HP_Regen = 15.05f;
    public Image HP_UI;

    [Header("MP")]
    public float MaxMP = 1565f;
    public float MP_Regen = 19.55f;
    public Image MP_UI;

    [Header("ATTACK")]
    public float AD = 102.5f;
    public float AP = 0f;

    [Header("CRITICAL")]
    public float cri = 0f;
    public float cri_Dmg = 170;

    [Header("DEFENSE")]
    public float Armor = 103.9f;
    public float Resistance = 52.1f;

    [Header("HASTE")]
    public float AbilityHaste = 0f;
    public float MoveSpeed = 5;

    public bool Dead;

    private void Awake()
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        _NavMeshAgent.speed = MoveSpeed;

        HP = MaxHP;
        MP = MaxMP;

        Dead = false;
    }

    [PunRPC]
    private void Update()
    {
        HP_UI.fillAmount = (HP / (MaxHP / 100f)) / 100f;
        MP_UI.fillAmount = (MP / (MaxMP / 100f)) / 100f;
    }

    //----------HP----------

    [PunRPC]
    public void AddHp(float NewHp)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            HP = NewHp;

            photonView.RPC("AddHp", RpcTarget.Others, NewHp);
        }
    }

    [PunRPC]
    public void SumHp(float NewHp)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            HP += NewHp; 

            photonView.RPC("SumHp", RpcTarget.Others, NewHp);
        }
    }

    [PunRPC]
    public void AddHpRegen(float NewHpRegen)
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            HP_Regen = NewHpRegen;

            photonView.RPC("AddHpRegen", RpcTarget.Others, NewHpRegen);
        }
    }

    //----------MP----------

    [PunRPC]
    public void AddMp(float NewMp)
    {
        if (PhotonNetwork.IsMasterClient)
        { 
             MP = NewMp;

            photonView.RPC("AddMp", RpcTarget.Others, NewMp);
        }
    }

    [PunRPC]
    public void SumMp(float NewMp)
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            MP += NewMp;

            photonView.RPC("SumMp", RpcTarget.Others, NewMp);
        }
    }

    [PunRPC]
    public void AddMpRegen(float NewMpRegen)
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            MP_Regen = NewMpRegen;

            photonView.RPC("AddMpRegen", RpcTarget.Others, NewMpRegen);
        }
    }

    //----------ATTACK----------

    [PunRPC]
    public void AddAd(float NewAd)
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            AD = NewAd;

            photonView.RPC("AddAd", RpcTarget.Others, NewAd);
        }
    }

    [PunRPC]
    public void AddAp(float NewAp)
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            AP = NewAp;

            photonView.RPC("AddAp", RpcTarget.Others, NewAp);
        }
    }

    //----------CRI----------

    [PunRPC]
    public void AddCri(float NewCri)
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            cri = NewCri;

            photonView.RPC("AddCri", RpcTarget.Others, NewCri);
        }
    }

    [PunRPC]
    public void AddCriDmg(float NewCriDmg)
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            cri_Dmg = NewCriDmg;

            photonView.RPC("AddCriDmg", RpcTarget.Others, NewCriDmg);
        }
    }

    //----------DEF----------
    
    [PunRPC]
    public void AddArmor(float NewArmor)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Armor = NewArmor;

            photonView.RPC("AddArmor", RpcTarget.Others, NewArmor);
        }
    }

    [PunRPC]
    public void AddResistance(float NewResistance)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Resistance = NewResistance;

            photonView.RPC("AddResistance", RpcTarget.Others, NewResistance);
        }
    }

    //----------HASTE----------

    [PunRPC]
    public void AddAbilityHaste(float NewAbilityHaste)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            AbilityHaste = NewAbilityHaste;

            photonView.RPC("AddAbilityHaste", RpcTarget.Others, NewAbilityHaste);
        }
    }

    [PunRPC]
    public void AddMoveSpeed(float NewMoveSpeed)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            MoveSpeed = NewMoveSpeed;
            _NavMeshAgent.speed = MoveSpeed;

            photonView.RPC("AddMoveSpeed", RpcTarget.Others, NewMoveSpeed);
        }
    }
}
