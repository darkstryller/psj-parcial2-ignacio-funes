using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/godmode")]
public class SetGodMode : Command
{
    [SerializeField] HealthContainer subject;
    public override void Execute()
    {
        subject.IsInvicible = true;
        Debug.Log("i am god is:" + subject.IsInvicible);
    }

    public override void Execute(string[] args)
    {
        subject.IsInvicible = !subject.IsInvicible;
        Debug.Log("i am god is:" + subject.IsInvicible);
    }

}
