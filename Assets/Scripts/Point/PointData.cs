using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Point Data")]
public class PointData : ScriptableObject
{
    [SerializeField] float _score;

    public float Score { get => _score; }
}
