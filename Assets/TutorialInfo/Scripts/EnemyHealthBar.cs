using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start() 
    {
        totalhealthBar.fillAmount = 1000;
    }

    private void Update() 
    {
        currenthealthBar.fillAmount = enemyHealth.currentHealth / 1000;    
    }

}