using System;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterInterface
{
    void AddBrick(AddBrick addBrick, MeshRenderer mesh, List<GameObject> trails, ParticleSystem trail);
    void RemoveBrick();
    void ClearBrick();
}