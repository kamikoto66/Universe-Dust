using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimation : StateMachineBehaviour {
    
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        PlayerAttack playerAttack = animator.GetComponent<PlayerAttack>();
        playerAttack.isAttack = true;
        Debug.Log("실행");
	}
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        PlayerAttack playerAttack = animator.GetComponent<PlayerAttack>();
        playerAttack.isAttack = false;
        Debug.Log("나감");
    }
}
