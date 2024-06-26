using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start() 
    {
        totalhealthBar.fillAmount = 1000;
    }

    private void Update() 
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 1000;    
    }

}