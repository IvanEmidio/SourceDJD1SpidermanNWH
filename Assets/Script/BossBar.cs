using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthBossBar : MonoBehaviour
{
    [SerializeField] private HealthBossLevel playerHealth;
    [SerializeField] private UnityEngine.UI.Image totalhealthbar;
    [SerializeField] private UnityEngine.UI.Image currenthealthbar;

    private void Start()
    {
        totalhealthbar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealthbar.fillAmount = playerHealth.currentHealth / 10; 
    }

}