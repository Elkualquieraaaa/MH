using NUnit.Framework;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpool : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] List<GameObject> bulletpoolList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Starbullets(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Starbullets(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject newbullet = Instantiate(bullet);
            //newbullet.SetActive(false);
            bulletpoolList.Add(newbullet);
        }
    }

    public GameObject Bullettouse()
    {
        for (int i = 0; i < bulletpoolList.Count; i++)
        {
            if (!bulletpoolList[i].activeInHierarchy)
            {
                return bulletpoolList[i];
            }
            if (bulletpoolList[i].activeSelf == true)
            {
                bulletpoolList[i].SetActive(false);
            }
        }
        GameObject bullettoadd = Instantiate(bullet);
        bullettoadd.SetActive(false);
        bulletpoolList.Add(bullettoadd);
        return bullettoadd;
    }
}
