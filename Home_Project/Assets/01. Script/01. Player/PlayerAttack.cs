using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput _PlayerInput;

    public float coolTime_Q;
    private bool delay_Q;

    public float coolTime_W;
    private bool delay_W;
    
    public float coolTime_E;
    private bool delay_E;
    
    public float coolTime_R;
    private bool delay_R;
    
    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
    }


    private void FixedUpdate()
    {
        


    }

    IEnumerator SkillDelay(float Delay, bool Skill)
    {
        yield return null;
    }

    void Skill_Q()
    {

    }


}
