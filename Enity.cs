using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Enity : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }
}
