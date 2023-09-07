using System;
using UnityEngine;

public class Particle2D : MonoBehaviour
{
    public float mass, inverseMass;
    public Vector2 velocity, acceleration = Vector2.zero, accumulatedForces = Vector2.zero;
    [Range(0.00f, 1f)] public float dampingConstant = 1f;

    private void FixedUpdate()
    {
        Integrator.Integrate(this, Time.deltaTime);
    }
}
