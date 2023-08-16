using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Boss _boss;
    [SerializeField] GameObject _winPanel, _lousePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinCondition();
        LouseCondition();
    }
    void WinCondition()
    {
        if (_boss._isOutOfAmmo)
        {
            _winPanel.SetActive(false);
            _lousePanel.SetActive(true);
        }
    }
    void LouseCondition()
    {
        if (_boss._isDeath)
        {
            _winPanel.SetActive(true);
            _lousePanel.SetActive(false);
        }
    }
}
