using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldIgnoreGreen : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "Gold")
        {
        }
    }
}
