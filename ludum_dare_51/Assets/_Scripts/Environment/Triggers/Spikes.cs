﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    [SerializeField] private bool hideAfterTimer;
    
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player"))
        {
            GameManager.Instance.TriggerTakeDamage();
        }
    }
    
    
    
}
