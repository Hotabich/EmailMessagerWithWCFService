using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MainService.Model.DbModels
{
    [DataContract]
    public  class RecipiantList
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
