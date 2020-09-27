using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiencePreferenceHandler : MonoBehaviour
{
    public enum AudiencePreference { NONE = 0, FREE, KILL, }
    public ParticleSystem killParticles;
    public ParticleSystem freeParticles;

    public AudiencePreference audiencePref
    {
        set
        {
            switch (value)
            {
                case AudiencePreference.FREE:
                    killParticles.Stop();
                    freeParticles.Play();
                    break;
                case AudiencePreference.KILL:
                    freeParticles.Stop();
                    killParticles.Play();
                    break;
                case AudiencePreference.NONE:
                    freeParticles.Stop();
                    killParticles.Play();
                    break;
            }

            _audiencePref = value;
        }
        get { return _audiencePref; }
    }

    public AudiencePreference _audiencePref;

    public AudiencePreference GenerateAudiencePreference()
    {
        // 1 in 4 chances for the public to have a preference
        var rnd = Random.Range(0, 4);
        if (rnd < 1) return AudiencePreference.NONE;

        rnd = Random.Range(0, 1);
        return rnd < .5f ? AudiencePreference.FREE : AudiencePreference.KILL;
    }
}
