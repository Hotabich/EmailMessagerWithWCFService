using System.Runtime.Serialization;

namespace Xamarin_Mail.Model
{
    [DataContract]
    public class RecipiantList
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Name { get; set; }

        public RecipiantList(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
