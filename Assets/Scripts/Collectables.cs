using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    [SerializeField] int collectableValue = 0;

    public int GetCollectableValue()
    {
        return collectableValue;
    }

}
