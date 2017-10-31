using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using EveTransactions.Domain;
using EveTransactions.Domain.Esi;

namespace EveTransactions.Services
{
    public static class EsiAccessService
    {
        private const string TashakiRefreshToken = "Ae_iXMlGbj4AKH3-wry5xxZU7GmX-BLdmvHLyyjqW_SjxIEXUHxZlBX9WZXjn7KrQagFvELDdioHYKB9qvRFLMVsAATCNDka-Y3b7PRRSBQlt3f0PJ5py1lckX4Xrln9m_kqDlHWlcvVsQNBIVTZdQ2";
        private const string TornRefreshToken = "BFizr7gKD3MYQf-VLGjSSEYHDbxWb6-eMnpaLwJjtKCdGT1hLphxWT0enE7cnzpKWd-rq7LAhmZl0KfsMTZtdsPGwseXiDRArjgrxXXlFwsTNhDt73HtHpCM3fD_evKX0";
        private const string OrsindaRefreshToken = "63bS3Te5oyJqQNU7eaqnHXJeAWy7oIbvCh9A43K6T0RaQAC-bTvSfghr9LAdLfmvsdFMx5ZJ5QzzpZkgHZXEczplLg9XjR92vKOA0VXBlWk1";

        public static EsiRefreshToken GetRefreshToken(Character character)
        {
            var refreshToken = string.Empty;
            var authorization = string.Empty;

            switch (character.Name)
            {
                case "Tashaki Snowblink":
                    refreshToken = TashakiRefreshToken;
                    authorization = "Basic NzI0MGY5ZGQwMWM2NDdlNzg0YjU0OGJhY2IwMGM3ZWU6RjdXUDkyQkg5Q2xKWEREa0FOUUoxbFRqUmpVVVdpaEdzanprV1VUbQ==";
                    break;
                case "Orsinda Pallus":
                    refreshToken = OrsindaRefreshToken;
                    authorization = "Basic NzcxYzg2YzBkNmZjNGU2YzgwNzM0ZDg0NWZmMGM0MGY6Snh2TEZPQzFCZURhNlVxUEVNcUhSVURpNHMwVTNKb0lkRmZhd1FMVA==";
                    break;
                case "Torn Ombrye":
                    refreshToken = TornRefreshToken;
                    authorization = "Basic M2M5Y2RiYTMxOGM1NGNiNjlhMjYzYjczNzhiYTZhMmQ6UHd0anZFNFZiZ0VoT2R5UGI0eWYyRWFQRVJ1TGJjeXkyTUphelZJUA==";
                    break;
            }

            EsiRefreshToken result = new EsiRefreshToken();

            WebHeaderCollection headers = new WebHeaderCollection
            {
                {
                    "Authorization", authorization
                }
            };

            var response = HttpServices.MakeHttpRequest("https://login.eveonline.com/oauth/token",
                "POST",
                headers,
                String.Format("grant_type=refresh_token&refresh_token={0}", refreshToken),
                "application/x-www-form-urlencoded");

            if (response == null) return result;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                result = (EsiRefreshToken)js.Deserialize(objText, typeof(EsiRefreshToken));
            }

            result.SetTokenExpiryDate();

            return result;
        }
    }
}
