using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class ScreenUIController : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, Sprite> skinData = new Dictionary<string, Sprite>();

    //public void OnAfterDeserialize()
    //{
    //    throw new NotImplementedException();
    //}

    //public void OnBeforeSerialize()
    //{
    //    throw new NotImplementedException();
    //}

    //private void Start()
    //{
    //}
}
