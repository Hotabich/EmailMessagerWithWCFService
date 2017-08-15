using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_Mail.Model
{
    public class RecipiantList
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public RecipiantList(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
