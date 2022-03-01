using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces {
    public interface IDamageble {
        public void TakeDamage(float damage);
        public void KnockBack(Vector3 direction, float strengh);
    }
}