using Godot;

namespace SeaQuest.Scripts.Helper;
/// <summary>
/// Contains reference to the user created input actions and built-in
/// </summary>
public static class InputMapActions
{
    /// <summary>
    /// Contains reference to the user created input actions
    /// </summary>
    public static class InputAction
    {
        /// <summary>
        /// Reference to the<c>"move_right"</c>input action
        /// </summary>
        public const string MOVE_RIGHT = "move_right";


        /// <summary>
        /// Reference to the<c>"move_left"</c>input action
        /// </summary>
        public const string MOVE_LEFT = "move_left";


        /// <summary>
        /// Reference to the<c>"move_up"</c>input action
        /// </summary>
        public const string MOVE_UP = "move_up";


        /// <summary>
        /// Reference to the<c>"move_down"</c>input action
        /// </summary>
        public const string MOVE_DOWN = "move_down";
        

        /// <summary>
        /// Reference to the<c>"shoot"</c>input action
        /// </summary>
        public const string SHOOT = "shoot";
    }
}
