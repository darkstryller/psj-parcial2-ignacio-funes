using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] PlayerSettings player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] KeyCode attack;
    [SerializeField] GameObject hitbox;
    public bool IamGod = false;

    MoveContainer move;
    HealthContainer health;
    private void Awake()
    {
        IamGod = false;
        move = GetComponent<MoveContainer>();
        health = GetComponent<HealthContainer>();
        health.SetLife(player.MaxLife);
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

    public PlayerSettings Player => player;
    public MoveContainer Move => move;
    public Rigidbody2D Rb => rb;
    public bool IsAlive => health.MyHealth <= 0;
}
