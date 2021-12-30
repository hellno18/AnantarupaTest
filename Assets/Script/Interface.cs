using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    void Initialize();
    float health { get; set; } //A variable
    void ApplyDamage(float points); //Function with one argument
}
