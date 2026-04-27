using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizationBody : MonoBehaviour {
    
    [System.Serializable]
    public class Body {
        public BodyType type;
        public List<GameObject> parts;
    }
    
    public List<Body> bodyParts;
}
