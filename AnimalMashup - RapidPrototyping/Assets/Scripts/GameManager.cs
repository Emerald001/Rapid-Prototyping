using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    public GameManager() {
        instance = this;
    }

    public GameObject player;
}