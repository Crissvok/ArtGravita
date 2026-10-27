//Стат блок тоже сделан на коленке. P.S Антон если будешь переделывать то обьясни что ты накукал потом
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MoveData", menuName = "Stats/PlayerData")]
public class MoveStats : ScriptableObject
{
    [Header("Настройки скорости")]
    [Tooltip("Максимальная скорость")]
    public float MoveSpeed = 8f;
    [Tooltip("Плавность разгона")]
    public float Acceleration = 50f;
    [Tooltip("Плавность торможения")]
    public float Deceleration = 60f;

    [Header("Настройки прыжка")]
    [Tooltip("Сила импульса прыжка")]
    public float JumpForce = 12f;
    [Tooltip("Радиус круга для проверки земли под ногами")]
    public float GroundCheckRadius = 0.2f;
    [Tooltip("Слой, который считается землей")]
    public LayerMask GroundLayer;
}
