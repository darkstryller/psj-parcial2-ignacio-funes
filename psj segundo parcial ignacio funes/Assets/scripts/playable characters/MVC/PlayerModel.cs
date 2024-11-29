using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerSettings player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int currentlife;
    [SerializeField] KeyCode attack;
    [SerializeField] GameObject hitbox;
    public bool IamGod = false;

    MoveContainer move;
    private void Awake()
    {
        IamGod = false;
        move = GetComponent<MoveContainer>();
        SetLife();
    }
    private void Update()
    {
        if (Input.GetKey(attack) || IamGod)
        {
            hitbox.SetActive(true);
        }
        else
        {
            hitbox.SetActive(false);
        }
    }
    public void die()
    {
        Debug.Log("game over");
    }

    public void GetDamage(int damage)
    {
        if(!IamGod)
        currentlife -= damage;
    }

    public void SetLife()
    {
        currentlife = player.MaxLife;
    }

    public PlayerSettings Player => player;
    public MoveContainer Move => move;
    public Rigidbody2D Rb => rb;
    public bool IsAlive => currentlife <= 0;
}
