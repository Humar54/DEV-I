using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fireball_Cooldown : MonoBehaviour
{
    [SerializeField] private Image _cooldownImage;
    [SerializeField] Cours_18_Fireball_skill _fireball;

    private void Update()
    {
        _cooldownImage.fillAmount=1-_fireball.GetTimerRatio();
    }
}
