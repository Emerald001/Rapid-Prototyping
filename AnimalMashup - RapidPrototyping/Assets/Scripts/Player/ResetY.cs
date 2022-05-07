using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetY : MonoBehaviour
{
    [SerializeField] private GameObject wolf;

    void Update()
    {
        wolf.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}