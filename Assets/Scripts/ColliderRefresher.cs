using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRefresher : MonoBehaviour
{
    void Update()
    {
        Destroy(GetComponent<PolygonCollider2D>());
        transform.gameObject.AddComponent<PolygonCollider2D>();
    }
}
