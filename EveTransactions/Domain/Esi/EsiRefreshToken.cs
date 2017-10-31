using System;

namespace EveTransactions.Domain.Esi
{ 
    public class EsiRefreshToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }

        public DateTime token_expirydate { get; set; }

        public void SetTokenExpiryDate()
        {
            int expiresInSeconds;
            if (int.TryParse(expires_in, out expiresInSeconds))
            {
                token_expirydate = DateTime.Now.AddSeconds(expiresInSeconds);
            }
        }
    }
}
