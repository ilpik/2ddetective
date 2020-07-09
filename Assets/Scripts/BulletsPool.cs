using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    public GameObject bulletStartPos;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<GameObject> _bulletPool;
    [SerializeField] private int _amountOfBullets = 10;


    private static BulletsPool _instance;
    public static BulletsPool Instance
    {
        get
        {
            if (_instance == null) Debug.Log("Bullet Controller = null");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        if (_instance)
            _bulletPool = GenerateBullets(_amountOfBullets);
    }

    private List<GameObject> GenerateBullets(int ammoCount)
    {
        for (int i = 0; i < ammoCount; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, bulletStartPos.transform, false);
            bullet.transform.parent = bulletStartPos.transform;
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }

        return _bulletPool;
    }

    public GameObject BulletRequest()
    {
        foreach (var bullet in _bulletPool)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(_bulletPrefab, bulletStartPos.transform, false);
        newBullet.transform.parent = bulletStartPos.transform;
        _bulletPool.Add(newBullet);
        return newBullet;

    }
}
