using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inven : MonoBehaviour
{
    public int _color;
    Image _image;
    private void Start()
    {
        _image =this. GetComponent<Image>();
        _color = Random.Range(0, 4);
        switch (_color)
        {
            case 0: _image.color = Color.yellow; break;
            case 1: _image.color = Color.cyan; break;
            case 2: _image.color = Color.blue; break;
            case 3: _image.color = Color.green; break;

        }

    }
}
