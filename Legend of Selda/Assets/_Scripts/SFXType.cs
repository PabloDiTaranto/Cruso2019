using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXType : MonoBehaviour
{
    public enum SoundType
    {
        ATTACK, DIE, HIT, KNOCK, M_START, M_END
    }
    // Start is called before the first frame update
    public SoundType type;
}
