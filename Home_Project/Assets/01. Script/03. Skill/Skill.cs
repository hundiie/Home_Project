using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    private RawImage Skill_Image;
    private Image Skill_Delay;
    private Text Skill_CoolTime;

    [HideInInspector] public float CoolTime;
    public bool isSkill;
    private void Awake()
    {
        Skill_Image = transform.GetChild(0).GetComponent<RawImage>();
        Skill_Delay = transform.GetChild(1).GetComponent<Image>();
        Skill_CoolTime = transform.GetChild(2).GetComponent<Text>();

        isSkill = true;
        Skill_Image.color = Color.white;
        Skill_Delay.fillAmount = 0;
        Skill_CoolTime.gameObject.SetActive(false);
    }

    public void IsSkill()
    {
        if (isSkill == true)
        {
            isSkill = false;
            Skill_Image.color = Color.gray;
            StartCoroutine(SkillDelay());
            StartCoroutine(SkillCoolTime());
        }
    }

    private IEnumerator SkillDelay()
    {
        for (float i = 1; i > 0; i-= Time.deltaTime / CoolTime)
        {
            Skill_Delay.fillAmount = i;
            yield return null;
        }
        Skill_Delay.fillAmount = 0;
    }
    private IEnumerator SkillCoolTime()
    {
        for (float i = CoolTime; i > 0; i -= Time.deltaTime)
        {
            Skill_CoolTime.text = $"{i}";
            yield return null;
        }
        Skill_Image.color = Color.white;
        isSkill = true;
    }
}
