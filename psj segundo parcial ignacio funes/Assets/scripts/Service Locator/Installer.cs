using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] Factory factory;
    [SerializeField] PoolManager pool;
    private void Awake()
    {
        //el installer es el que pone los servicios dentro del service locator
        ServiceLocator.Instance.RegisterService<IPoolService>(pool);
        ServiceLocator.Instance.RegisterService<IFactoryService>(factory);
    }
}
