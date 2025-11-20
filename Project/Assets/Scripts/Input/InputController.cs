using UnityEngine;

namespace GameHardwareAndInputClasses
{
    public class InputController : MonoBehaviour
    {
        public static InputController Instance => instance;

        public bool PrimaryTouchPressed => primaryTouchPressed;
        public bool SecondaryTouchPressed => secondaryTouchPressed;
        public Vector2 PrimaryTouchPosition => primaryTouchPosition;
        public Vector2 SecondaryTouchPosition => secondaryTouchPosition;
        public Vector2 PrimaryTouchSwipeValue => primaryTouchSwipeValue;
        public Vector2 SecondaryTouchSwipeValue => secondaryTouchSwipeValue;

        private static InputController instance;

        private InputSystem_Actions inputSystem_Actions;

        private SwipeController primaryTouchSwipeController = new SwipeController();
        private SwipeController secondaryTouchSwipeController = new SwipeController();

        private bool primaryTouchPressed = false;
        private bool secondaryTouchPressed = false;
        private Vector2 primaryTouchPosition = new Vector2(0f, 0f);
        private Vector2 secondaryTouchPosition = new Vector2(0f, 0f);
        private Vector2 primaryTouchSwipeValue = new Vector2(0f, 0f);
        private Vector2 secondaryTouchSwipeValue = new Vector2(0f, 0f);

        private bool firstFrameOfInput = true;

        private void Awake()
        {
            if(ReferenceEquals(InputController.Instance, null))
            {
                instance = this;
                inputSystem_Actions = new InputSystem_Actions();
                inputSystem_Actions.MainActionMap.Enable();
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            
        }

        private void Update()
        {
            primaryTouchPressed = inputSystem_Actions.MainActionMap.FirstTouchIfPressed.IsPressed();
            secondaryTouchPressed = inputSystem_Actions.MainActionMap.SecondTouchIfPressed.IsPressed();

            primaryTouchPosition = inputSystem_Actions.MainActionMap.FirstTouchPosition.ReadValue<Vector2>();
            secondaryTouchPosition = inputSystem_Actions.MainActionMap.SecondTouchPosition.ReadValue<Vector2>();

            primaryTouchSwipeValue = primaryTouchSwipeController.RunUpdate(inputSystem_Actions.MainActionMap.FirstTouchIfPressed.IsPressed(),
                inputSystem_Actions.MainActionMap.FirstTouchPosition.ReadValue<Vector2>() );
            secondaryTouchSwipeValue = secondaryTouchSwipeController.RunUpdate(inputSystem_Actions.MainActionMap.SecondTouchIfPressed.IsPressed(),
                inputSystem_Actions.MainActionMap.SecondTouchPosition.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            if(!ReferenceEquals(inputSystem_Actions, null))inputSystem_Actions.Disable();
        }
    }
}

