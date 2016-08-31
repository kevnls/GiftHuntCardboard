using UnityEngine;
using System.Collections;

public class MovingCharacterController : MonoBehaviour {
  // For a full explanation of the API, look at ExampleCharacterController.cs
  // This example will assume knowledge of the API to code a moving first-person character

  public float speed = 17f;

  private static CardboardControl cardboard;
  private bool moving = false;

  void Start() {
    cardboard = GameObject.Find("CardboardControlManager").GetComponent<CardboardControl>();
    cardboard.trigger.OnDown += ToggleMove;
    cardboard.trigger.OnUp += ToggleMove;
    //cardboard.trigger.OnClick += Interact;
  }

  void Interact(object sender) {

  }

  void ToggleMove(object sender) {
    moving = !moving;
  }
  
  void Update() {
    // If you don't need as much control over what happens when moving is toggled,
    // you can replace this with cardboard.trigger.IsHeld() and remove ToggleMove()
    if (moving) {
      Vector3 movement = Camera.main.transform.forward;
      transform.position += movement * speed * Time.deltaTime;
    }
  }
}
