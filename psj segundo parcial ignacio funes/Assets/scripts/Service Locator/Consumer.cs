using System;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            var dataSaver = ServiceLocator.Instance.GetService<IDataSaver>();
            dataSaver.SetString("KEY", "SUSCRÍBETE");
        }
        else if (Input.GetKeyUp(KeyCode.O))
        {
            var dataSaver = ServiceLocator.Instance.GetService<IDataSaver>();
            var text = dataSaver.GetString("KEY");
            Debug.Log(text);
        }
    }
}
