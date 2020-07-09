using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstanciation : MonoBehaviour
{
    public void BulletFly()
    {
        GameObject bullet = BulletsPool.Instance.BulletRequest();
        Debug.Log("Shooted");
    }

}
