#pragma strict
 
var anim:Animator;
 
var rigidBodyController:UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController;
 
function Start () {
 anim=transform.GetComponent(Animator);
 rigidBodyController=transform.GetComponent(UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController);
 
}
 
function Update () {
 if(rigidBodyController.isMine){
 anim.SetBool("forward",false);
 anim.SetBool("back",false);
 anim.SetBool("left",false);
 anim.SetBool("right",false);
 
 
if(Input.GetKey(KeyCode.UpArrow)){
 anim.SetBool("forward",true);
}
if(Input.GetKey(KeyCode.DownArrow)){
 anim.SetBool("back",true);
}
if(Input.GetKey(KeyCode.LeftArrow)){
 anim.SetBool("left",true);
}
if(Input.GetKey(KeyCode.RightArrow)){
 anim.SetBool("right",true);
}
}
}