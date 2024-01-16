using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Item
{
    public class UserItem : ItemBase
    {
        [JsonProperty("ACTIVE")]
        public bool? Active { get; set; }

        [JsonProperty("EMAIL")]
        public string? Email { get; set; }

        [JsonProperty("NAME")]
        public string? Name { get; set; }

        [JsonProperty("LAST_NAME")]
        public string? LastName { get; set; }

        [JsonProperty("SECOND_NAME")]
        public string? SecondName { get; set; }

        [JsonProperty("PERSONAL_GENDER")]
        public string? Gender { get; set; }

        [JsonProperty("PERSONAL_PROFESSION")]
        public string? Profession { get; set; }

        [JsonProperty("PERSONAL_WWW")]
        public string? WWW { get; set; }

        [JsonProperty("BIRTHDAY")]
        public DateTime? Birthday { get; set; }

        [JsonProperty("PERSONAL_PHOTO")]
        public string? Photo { get; set; }

        [JsonProperty("PERSONAL_ICQ")]
        public string? ICQ { get; set; }

        [JsonProperty("PERSONAL_PHONE")]
        public string? Phone { get; set; }

        [JsonProperty("PERSONAL_FAX")]
        public string? Fax { get; set; }

        [JsonProperty("PERSONAL_MOBILE")]
        public string? Mobile { get; set; }

        [JsonProperty("PERSONAL_PAGER")]
        public string? Pager { get; set; }

        [JsonProperty("PERSONAL_STREET")]
        public string? Street { get; set; }

        [JsonProperty("PERSONAL_CITY")]
        public string? City { get; set; }

        [JsonProperty("PERSONAL_STATE")]
        public string? State { get; set; }

        [JsonProperty("PERSONAL_ZIP")]
        public string? Zip { get; set; }

        [JsonProperty("PERSONAL_COUNTRY")]
        public string? Country { get; set; }

        [JsonProperty("WORK_COMPANY")]
        public string? WorkCompany { get; set; }

        [JsonProperty("WORK_POSITION")]
        public string? WorkPosition { get; set; }

        //TODO: put it in a separate Department class
        [JsonProperty("UF_DEPARTMENT")]
        public List<int>? Department { get; set; }

        [JsonProperty("UF_INTERESTS")]
        public string? Interests { get; set; }

        [JsonProperty("UF_SKILLS")]
        public string? Skills { get; set; }

        [JsonProperty("UF_WEB_SITES")]
        public string? WebSites { get; set; }

        [JsonProperty("UF_XING")]
        public string? Xing { get; set; }

        [JsonProperty("UF_LINKEDIN")]
        public string? Linkedin { get; set; }

        [JsonProperty("UF_FACEBOOK")]
        public string? Facebook { get; set; }

        [JsonProperty("UF_TWITTER")]
        public string? Twitter { get; set; }

        [JsonProperty("UF_SKYPE")]
        public string? Skype { get; set; }

        [JsonProperty("UF_DISTRICT")]
        public string? District { get; set; }

        [JsonProperty("UF_PHONE_INNER")]
        public string? PhoneInner { get; set; }
    }
}
