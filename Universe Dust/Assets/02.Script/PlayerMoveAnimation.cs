using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnimation : StateMachineBehaviour {
    
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetInteger("aniNumber", 0);
	}
    
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
    
}
