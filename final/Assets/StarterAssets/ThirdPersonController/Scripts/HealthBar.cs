using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public Color fullHealthColor = Color.green;
    public Color highHealthColor = Color.yellow;
    public Color mediumHealthColor = new Color(1f, 0.5f, 0f); // Orange
    public Color lowHealthColor = Color.red;
    // Start is called before the first frame update
    public void UpdateHealthBar(int health, int maxHealth)
    {
        float healthPercentage = ((float)health / (float)maxHealth);
        slider.value = healthPercentage;

        if (healthPercentage > 0.75f) // Above 75% health
        {
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(highHealthColor, fullHealthColor, (healthPercentage - 0.75f) * 4);
        }
        else if (healthPercentage > 0.5f) // 50% - 75% health
        {
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(mediumHealthColor, highHealthColor, (healthPercentage - 0.5f) * 4);
        }
        else if (healthPercentage > 0.25f) // 25% - 50% health
        {
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowHealthColor, mediumHealthColor, (healthPercentage - 0.25f) * 4);
        }
        else // Below or equal to 25% health
        {
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Color.black, lowHealthColor, healthPercentage * 4);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
