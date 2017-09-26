using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace Xamarin_Mail.Model.Util
{
    [DataContract]
        public class Message
        {
            #region Propertys
            [DataMember]
            public string OwnerLogin { get; set; }

            [DataMember]
            public string OwnerPassword { get; set; }

            [DataMember]
            public string TextMessage { get; set; }

            [DataMember]
            public string SubjectMessage { get; set; }

            [DataMember]
            public ObservableCollection<string> Receivers { get; set; }
            #endregion
    }
}




