using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status {
    satiated,
    fullAffection,
    sad,
}

public class Pet {
    public int _satiety =100;
    public int _affection=100;
    public int _fun=100;

    public virtual void Interact() { }
    
    private int DecreaseNeed(int needValue) {
        if (needValue>0) {
            return needValue -= 1;
        }
        return 0;
    }

    private void UpdateStatus() {
        
    }
}
    

