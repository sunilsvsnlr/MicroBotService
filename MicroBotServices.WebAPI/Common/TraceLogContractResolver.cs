using Newtonsoft.Json.Serialization;

namespace MicroBotServices.WebAPI.Common
{
    public class TraceLogContractResolver : DefaultContractResolver, IContractResolver
    {
        /// <summary>
        /// Creates a Newtonsoft.Json.Serialization.JsonProperty for the given System.Reflection.MemberInfo.
        /// Modifies JsonProperty if the member is marked with SensitiveData attribute.  
        /// </summary>
        /// <param name="member">The member's parent Newtonsoft.Json.MemberSerialization.</param>
        /// <param name="memberSerialization">The member to create a Newtonsoft.Json.Serialization.JsonProperty for.</param>
        /// <returns>A created Newtonsoft.Json.Serialization.JsonProperty for the given System.Reflection.MemberInfo.</returns>
        protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            return base.CreateProperty(member, memberSerialization);
        }
    }
}