using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header(" ")][Range(0f,100f)]
    public float speed = 3.5f;
    [Header(" "),Range(100,2000)]
    public int junp = 300;
    []
    public bool isGround = false;
    public string name = "uYC";
}
