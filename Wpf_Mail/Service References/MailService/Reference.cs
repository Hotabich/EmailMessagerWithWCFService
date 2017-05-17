﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wpf_Mail.MailService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/MainService.Model")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.IO.Stream[] AttachmentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OwnerLoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OwnerPasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ReceiversField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubjectMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.IO.Stream[] Attachments {
            get {
                return this.AttachmentsField;
            }
            set {
                if ((object.ReferenceEquals(this.AttachmentsField, value) != true)) {
                    this.AttachmentsField = value;
                    this.RaisePropertyChanged("Attachments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OwnerLogin {
            get {
                return this.OwnerLoginField;
            }
            set {
                if ((object.ReferenceEquals(this.OwnerLoginField, value) != true)) {
                    this.OwnerLoginField = value;
                    this.RaisePropertyChanged("OwnerLogin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OwnerPassword {
            get {
                return this.OwnerPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.OwnerPasswordField, value) != true)) {
                    this.OwnerPasswordField = value;
                    this.RaisePropertyChanged("OwnerPassword");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Receivers {
            get {
                return this.ReceiversField;
            }
            set {
                if ((object.ReferenceEquals(this.ReceiversField, value) != true)) {
                    this.ReceiversField = value;
                    this.RaisePropertyChanged("Receivers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SubjectMessage {
            get {
                return this.SubjectMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectMessageField, value) != true)) {
                    this.SubjectMessageField = value;
                    this.RaisePropertyChanged("SubjectMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TextMessage {
            get {
                return this.TextMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.TextMessageField, value) != true)) {
                    this.TextMessageField = value;
                    this.RaisePropertyChanged("TextMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="MailService.IMainService")]
    public interface IMainService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IMainService/Send", ReplyAction="http://Microsoft.ServiceModel.Samples/IMainService/SendResponse")]
        string[] Send(Wpf_Mail.MailService.Message _message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IMainService/Send", ReplyAction="http://Microsoft.ServiceModel.Samples/IMainService/SendResponse")]
        System.Threading.Tasks.Task<string[]> SendAsync(Wpf_Mail.MailService.Message _message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMainServiceChannel : Wpf_Mail.MailService.IMainService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MainServiceClient : System.ServiceModel.ClientBase<Wpf_Mail.MailService.IMainService>, Wpf_Mail.MailService.IMainService {
        
        public MainServiceClient() {
        }
        
        public MainServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MainServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] Send(Wpf_Mail.MailService.Message _message) {
            return base.Channel.Send(_message);
        }
        
        public System.Threading.Tasks.Task<string[]> SendAsync(Wpf_Mail.MailService.Message _message) {
            return base.Channel.SendAsync(_message);
        }
    }
}
