using UnityEngine;

namespace MinimolGames
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        protected CharacterSettings _characterSettings;
        public void Init(CharacterSettings p_characterSettigs) => _characterSettings = p_characterSettigs;
    }
}