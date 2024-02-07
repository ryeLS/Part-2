using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject arrowPrefab;
    public void spawnWeapon()
    {
            Instantiate(arrowPrefab);
    }
}
