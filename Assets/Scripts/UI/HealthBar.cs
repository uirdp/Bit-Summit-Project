using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.Heat;
using UnityEngine.UI;


//TODO damagecontrol -> health
//plz fix this later goosebumps fr
//have a third component between player and this

public class HealthBar : MonoBehaviour
{
    public ProgressBar healthBar;
    public GameObject frame;

    private Image frameImage;

    private Color frameOpaque;
    private Color framTransparent;
    
    public Player player;
    private DamageControl playerHealth;

    public void HealthCheck()
    {
        
        healthBar.currentValue = playerHealth.health;
        healthBar.UpdateUI();
    }

    public void GaurdedCheck()
    {
        
        if (playerHealth.isGuarded) frameImage.color = frameOpaque;
        if (!playerHealth.isGuarded)
        {
            frameImage.color = framTransparent;
        }
    }

    public void GetPlayer()
    {
        playerHealth = player.player?.GetComponent<DamageControl>();
    }

    private void Start()
    {
        frameImage = frame.GetComponent<Image>();
        var frameColor = frameImage.color;

        frameOpaque = frameColor;
        framTransparent = new Color(frameColor.r, frameColor.g, frameColor.b, 0.0f);
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            HealthCheck();
            GaurdedCheck();
        }
    }
}

