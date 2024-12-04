using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] Factory factory;
    [SerializeField] PoolManager pool;
    private void Awake()
    {
        
        ServiceLocator.Instance.RegisterService<IPoolService>(pool);
        ServiceLocator.Instance.RegisterService<IFactoryService>(factory);
    }
}
