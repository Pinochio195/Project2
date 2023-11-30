using System;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterInterface
{
    void AddBrick(Transform _brick, List<GameObject> trails, ParticleSystem trail);
    void RemoveBrick();
    void ClearBrick();
}