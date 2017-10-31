using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using EveTransactions.Domain;
using EveTransactions.Domain.Esi;
using EveTransactions.Repository;

namespace EveTransactions.Services
{
    public static class EveItemService
    {
        public static void AddEveItem(long typeId, string name)
        {
            EveRepository repository = new EveRepository();

            EveItem eveItem = new EveItem();
            eveItem.ItemID = typeId;
            eveItem.ItemName = name;
            repository.EveItems.Add(eveItem);
            repository.SaveChanges();

        }

        public static string GetTypeNameFromId(EsiRefreshToken esiToken, long typeId)
        {
            string result;

            EveRepository repository = new EveRepository();
            var item = repository.EveItems.FirstOrDefault(x => x.ItemID == typeId);
            if (item != null)
            {
                result = item.ItemName;
            }
            else
            {
                result = LookupTypeName(esiToken, typeId);
                if (!string.IsNullOrEmpty(result))
                {
                    AddEveItem(typeId, result);
                }
            }

            return result;
        }

        public static string LookupTypeName(EsiRefreshToken esiToken, long typeId)
        {
            string result = string.Empty;

            //var esiToken = EsiAccessService.GetRefreshToken(character);

            if (string.IsNullOrEmpty(esiToken.access_token)) return result;

            WebHeaderCollection headers = new WebHeaderCollection
            {
                {"Authorization", string.Format("{0} {1}", esiToken.token_type, esiToken.access_token)},
                {"X-ConsumerKey", "IKzP5olthtinjAgyvhZAxk"}
            };

            var response = HttpServices.MakeHttpRequest(string.Format("https://esi.tech.ccp.is/latest/universe/types/{0}", typeId),
                "GET",
                headers
                );

            if (response == null) return result;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                EsiType type = js.Deserialize<EsiType>(objText);

                if (type != null)
                {
                    result = type.name;
                }
            }

            return result;
        }


    }
}
