using System;
using System.Collections.Generic;

namespace EveTransactions.Domain.Esi
{
    public class CharacterRefreshTokens
    {
        #region Member Variables

        private readonly IDictionary<string, EsiRefreshToken> _characterRefreshTokens = new Dictionary<string, EsiRefreshToken>();

        #endregion

        #region Properties

        public IDictionary<string, EsiRefreshToken> RefreshTokens => _characterRefreshTokens;

        #endregion

        #region Methods

        public void AddToken(string characterName, EsiRefreshToken refreshToken)
        {
            if (_characterRefreshTokens.ContainsKey(characterName))
            {
                _characterRefreshTokens[characterName] = refreshToken;
            }
            else
            {
                _characterRefreshTokens.Add(characterName, refreshToken);
            }
        }

        public EsiRefreshToken GetToken(string characterName)
        {
            if (_characterRefreshTokens.ContainsKey(characterName))
            {
                return _characterRefreshTokens[characterName];
            }

            return null;
        }

        public bool HasTokenExpired(string characterName)
        {
            if (_characterRefreshTokens.ContainsKey(characterName))
            {
                return _characterRefreshTokens[characterName].token_expirydate < DateTime.Now;
            }

            // Don't have a token for this character, so it's expired
            return true;
        }

        #endregion
    }
}
