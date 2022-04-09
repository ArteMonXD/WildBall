using UnityEngine;

namespace WildBall.Inputs
{
    public class GlobalStringVars
    {
        #region Input vars
        public const string HORIZONTAL_AXIS = "Horizontal";
        public const string VERTICAL_AXIS = "Vertical";
        public const string JUMP_BUTTON = "Jump";
        public const string INTERACT_BUTTON = "Interact";
        #endregion

        #region Names
        public const string PLAYER_NAME = "Player";
        public const string GAME_OVER_PANEL_NAME = "GameOverPanel";
        #endregion

        #region AnimatorParameters
        public const string INTERACT_OBJECT_ANIMATOR_TRIGGER_NAME = "Open";
        public const string LIFT_HIGHT_UP_TRIGGER_NAME = "OpenHight";
        public const string LET_STATE_PARAMETER = "State";
        public const string DEATHCUBE_ATTACK = "Attack";
        #endregion

        #region Enums
        public enum PromtArrows {Left, Top, Right, Buttom, None };
        #endregion

        public static float ReductionOfRanges(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
        }
    }
}
