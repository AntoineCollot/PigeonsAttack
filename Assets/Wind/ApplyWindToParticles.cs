using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyWindToParticles : MonoBehaviour {

    new ParticleSystem particleSystem;
    ParticleSystem.Particle[] particles;

	// Update is called once per frame
	void Update () {
        InitializeIfNeeded();

        //Get the particles
        int numParticlesAlive = particleSystem.GetParticles(particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            //Apply the wind
            particles[i].position += Wind.Instance.GetWind(particles[i].position);
        }

        //Set the particles back
        particleSystem.SetParticles(particles, numParticlesAlive);
    }

    void InitializeIfNeeded()
    {
        if (particleSystem == null)
            particleSystem = GetComponent<ParticleSystem>();

        if (particles == null || particles.Length < particleSystem.main.maxParticles)
            particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
    }
}
