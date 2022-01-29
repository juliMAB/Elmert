using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public Func<GameObject> onSpawnEnemy = null;
    public Action<GameObject> onDespawnEnemy = null;
}
