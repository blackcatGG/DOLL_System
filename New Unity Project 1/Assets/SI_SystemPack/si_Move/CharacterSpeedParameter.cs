using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterSpeedParameter : ScriptableObject {

    public float normal = 10.0f;
    public float boost = 24.0f;
    public float quick = 30.0f;
    public float second_boost = 20.0f;

    public float quicktime = 20.0f;
    public float second_boost_time = 40.0f;

    public float boost_energy = 1200.0f;
    public float quick_energy = 1400.0f;
    public float second_boost_energy = 1000.0f;

    public string normal_anim = "NormalSpeed";
    public string quick_anim = "Boost";
    public string boost_anim = "Boost";
    public string second_anim = "Boost";

    public float normal_direction_per = 60.0f;
    public float quick_direction_per = 10.0f;
    public float boost_direction_per = 10.0f;
    public float second_direction_per = 10.0f;

    public float boostDelay = 5.0f;

}
