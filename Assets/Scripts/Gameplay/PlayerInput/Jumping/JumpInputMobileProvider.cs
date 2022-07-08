using Zenject;

namespace Gameplay.PlayerInput.Jumping
{
    public class JumpInputMobileProvider: global::Jump.IJumpInputProvider
    {
        [Inject] private InputHandler handler;
        
        public bool GetHasJumpInput()
        {
            return handler.GetInput("Jump") > 0.5f;
        }
    }
}