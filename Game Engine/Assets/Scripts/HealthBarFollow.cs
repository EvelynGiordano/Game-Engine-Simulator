using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform enemy;

    private void Update()
    {
        this.transform.position = enemy.transform.position;
   
    }
}
