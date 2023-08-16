
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class C_Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> _inventory = new List<GameObject>();
    [SerializeField] List<GameObject> _listGun = new List<GameObject>();
    List<int> _collorList=new List<int>();
    void Start()
    {

        for (int i = 0; i < 30; i++)
        {
            int j =Random.Range(0, 4);
            GameObject g = Instantiate(_listGun[j], this.transform.position, this.transform.rotation, this.transform);
            _collorList.Add(g.gameObject.GetComponent<Inven>()._color);
            _inventory.Add(g);
        }

    }
    private void Update()
    {

    }


}
