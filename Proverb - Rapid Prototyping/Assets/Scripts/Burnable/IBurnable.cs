using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBurnable
{
    bool IsBurning { get; }
    float heatValue { get; }
    public GameObject flames { get; set; }
    public void Light();
    public void BurnUp();
}
