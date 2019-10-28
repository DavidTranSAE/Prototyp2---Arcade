using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVector : MonoBehaviour
{
    public float x1, x2;
    public float y1, y2;
    
    public Vector2 GetVector()
    {
        Vector2 tempVector = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
        return tempVector;
    }
}
