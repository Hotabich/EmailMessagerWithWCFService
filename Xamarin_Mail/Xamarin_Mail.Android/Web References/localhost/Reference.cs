﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Xamarin_Mail.Droid.localhost {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IMainService", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MarshalByRefObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Stream[]))]
    public partial class MainService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllRecipiantsListOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRecipientsListOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddRecipiantListOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddRecipiantOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateRecipiantOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteRecipiantsListOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteRecipiantOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MainService() {
            this.Url = "http://localhost:8080/MainService";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SendCompletedEventHandler SendCompleted;
        
        /// <remarks/>
        public event GetAllRecipiantsListCompletedEventHandler GetAllRecipiantsListCompleted;
        
        /// <remarks/>
        public event GetRecipientsListCompletedEventHandler GetRecipientsListCompleted;
        
        /// <remarks/>
        public event AddRecipiantListCompletedEventHandler AddRecipiantListCompleted;
        
        /// <remarks/>
        public event AddRecipiantCompletedEventHandler AddRecipiantCompleted;
        
        /// <remarks/>
        public event UpdateRecipiantCompletedEventHandler UpdateRecipiantCompleted;
        
        /// <remarks/>
        public event DeleteRecipiantsListCompletedEventHandler DeleteRecipiantsListCompleted;
        
        /// <remarks/>
        public event DeleteRecipiantCompletedEventHandler DeleteRecipiantCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Microsoft.ServiceModel.Samples/IMainService/Send", RequestNamespace="http://Microsoft.ServiceModel.Samples", ResponseNamespace="http://Microsoft.ServiceModel.Samples", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] Send([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] Message _message) {
            object[] results = this.Invoke("Send", new object[] {
                        _message});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void SendAsync(Message _message) {
            this.SendAsync(_message, null);
        }
        
        /// <remarks/>
        public void SendAsync(Message _message, object userState) {
            if ((this.SendOperationCompleted == null)) {
                this.SendOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendOperationCompleted);
            }
            this.InvokeAsync("Send", new object[] {
                        _message}, this.SendOperationCompleted, userState);
        }
        
        private void OnSendOperationCompleted(object arg) {
            if ((this.SendCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendCompleted(this, new SendCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Microsoft.ServiceModel.Samples/IMainService/GetAllRecipiantsList", RequestNamespace="http://Microsoft.ServiceModel.Samples", ResponseNamespace="http://Microsoft.ServiceModel.Samples", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/MainService.Model.DbModels")]
        public RecipiantList[] GetAllRecipiantsList() {
            object[] results = this.Invoke("GetAllRecipiantsList", new object[0]);
            return ((RecipiantList[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllRecipiantsListAsync() {
            this.GetAllRecipiantsListAsync(null);
        }
        
        /// <remarks/>
        public void GetAllRecipiantsListAsync(object userState) {
            if ((this.GetAllRecipiantsListOperationCompleted == null)) {
                this.GetAllRecipiantsListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllRecipiantsListOperationCompleted);
            }
            this.InvokeAsync("GetAllRecipiantsList", new object[0], this.GetAllRecipiantsListOperationCompleted, userState);
        }
        
        private void OnGetAllRecipiantsListOperationCompleted(object arg) {
            if ((this.GetAllRecipiantsListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllRecipiantsListCompleted(this, new GetAllRecipiantsListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Microsoft.ServiceModel.Samples/IMainService/GetRecipientsList", RequestNamespace="http://Microsoft.ServiceModel.Samples", ResponseNamespace="http://Microsoft.ServiceModel.Samples", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/MainService.Model.DbModels")]
        public Recipiant[] GetRecipientsList(int id, [System.Xml.Serialization.XmlIgnoreAttribute()] bool idSpecified) {
            object[] results = this.Invoke("GetRecipientsList", new object[] {
                        id,
                        idSpecified});
            return ((Recipiant[])(results[0]));
        }
        
        /// <remarks/>
        public void GetRecipientsListAsync(int id, bool idSpecified) {
            this.GetRecipientsListAsync(id, idSpecified, null);
        }
        
        /// <remarks/>
        public void GetRecipientsListAsync(int id, bool idSpecified, object userState) {
            if ((this.GetRecipientsListOperationCompleted == null)) {
                this.GetRecipientsListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecipientsListOperationCompleted);
            }
            this.InvokeAsync("GetRecipientsList", new object[] {
                        id,
                        idSpecified}, this.GetRecipientsListOperationCompleted, userState);
        }
        
        private void OnGetRecipientsListOperationCompleted(object arg) {
            if ((this.GetRecipientsListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecipientsListCompleted(this, new GetRecipientsListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Microsoft.ServiceModel.Samples/IMainService/AddRecipiantList", RequestNamespace="http://Microsoft.ServiceModel.Samples", ResponseNamespace="http://Microsoft.ServiceModel.Samples", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddRecipiantList([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string listName) {
            this.Invoke("AddRecipiantList", new object[] {
                        listName});
        }
        
        /// <remarks/>
        public void AddRecipiantListAsync(string listName) {
            this.AddRecipiantListAsync(listName, null);
        }
        
        /// <remarks/>
        public void AddRecipiantListAsync(string listName, object userState) {
            if ((this.AddRecipiantListOperationCompleted == null)) {
                this.AddRecipiantListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddRecipiantListOperationCompleted);
            }
            this.InvokeAsync("AddRecipiantList", new object[] {
                        listName}, this.AddRecipiantListOperationCompleted, userState);
        }
        
        private void OnAddRecipiantListOperationCompleted(object arg) {
            if ((this.AddRecipiantListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddRecipiantListCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Microsoft.ServiceModel.Samples/IMainService/AddRecipiant", RequestNamespace="http://Microsoft.ServiceModel.Samples", ResponseNamespace="http://Microsoft.ServiceModel.Samples", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddRecipiant(int idList, [System.Xml.Serialization.XmlIgnoreAttribute()] bool idListSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string email) {
            this.Invoke("AddRecipiant", new object[] {
                        idList,
                        idListSpecified,
                        email});
        }
        
        /// <remarks/>
        public void AddRecipiantAsync(int idList, bool idListSpecified, string email) {
            this.AddRecipiantAsync(idList, idListSpecified, email, null);
        }
        
        /// <remarks/>
        public void AddRecipiantAsync(int idList, bool idListSpecified, string email, object userState) {
            if ((this.AddRecipiantOperationCompleted == null)) {
                this.AddRecipiantOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddRecipiantOperationCompleted);
            }
            this.InvokeAsync("AddRecipiant", new object[] {
                        idList,
                        idListSpecified,
                        email}, this.AddRecipiantOperationCompleted, userState);
        }
        
        private void OnAddRecipiantOperationCompleted(object arg) {
            if ((this.AddRecipiantCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddRecipiantCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Microsoft.ServiceModel.Samples/IMainService/UpdateRecipiant", RequestNamespace="http://Microsoft.ServiceModel.Samples", ResponseNamespace="http://Microsoft.ServiceModel.Samples", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateRecipiant(int id, [System.Xml.Serialization.XmlIgnoreAttribute()] bool idSpecified, int idList, [System.Xml.Serialization.XmlIgnoreAttribute()] bool idListSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string email) {
            this.Invoke("UpdateRecipiant", new object[] {
                        id,
                        idSpecified,
                        idList,
                        idListSpecified,
                        email});
        }
        
        /// <remarks/>
        public void UpdateRecipiantAsync(int id, bool idSpecified, int idList, bool idListSpecified, string email) {
            this.UpdateRecipiantAsync(id, idSpecified, idList, idListSpecified, email, null);
        }
        
        /// <remarks/>
        public void UpdateRecipiantAsync(int id, bool idSpecified, int idList, bool idListSpecified, string email, object userState) {
            if ((this.UpdateRecipiantOperationCompleted == null)) {
                this.UpdateRecipiantOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateRecipiantOperationCompleted);
            }
            this.InvokeAsync("UpdateRecipiant", new object[] {
                        id,
                        idSpecified,
                        idList,
                        idListSpecified,
                        email}, this.UpdateRecipiantOperationCompleted, userState);
        }
        
        private void OnUpdateRecipiantOperationCompleted(object arg) {
            if ((this.UpdateRecipiantCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateRecipiantCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Microsoft.ServiceModel.Samples/IMainService/DeleteRecipiantsList", RequestNamespace="http://Microsoft.ServiceModel.Samples", ResponseNamespace="http://Microsoft.ServiceModel.Samples", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteRecipiantsList(int id, [System.Xml.Serialization.XmlIgnoreAttribute()] bool idSpecified) {
            this.Invoke("DeleteRecipiantsList", new object[] {
                        id,
                        idSpecified});
        }
        
        /// <remarks/>
        public void DeleteRecipiantsListAsync(int id, bool idSpecified) {
            this.DeleteRecipiantsListAsync(id, idSpecified, null);
        }
        
        /// <remarks/>
        public void DeleteRecipiantsListAsync(int id, bool idSpecified, object userState) {
            if ((this.DeleteRecipiantsListOperationCompleted == null)) {
                this.DeleteRecipiantsListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteRecipiantsListOperationCompleted);
            }
            this.InvokeAsync("DeleteRecipiantsList", new object[] {
                        id,
                        idSpecified}, this.DeleteRecipiantsListOperationCompleted, userState);
        }
        
        private void OnDeleteRecipiantsListOperationCompleted(object arg) {
            if ((this.DeleteRecipiantsListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteRecipiantsListCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Microsoft.ServiceModel.Samples/IMainService/DeleteRecipiant", RequestNamespace="http://Microsoft.ServiceModel.Samples", ResponseNamespace="http://Microsoft.ServiceModel.Samples", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteRecipiant(int id, [System.Xml.Serialization.XmlIgnoreAttribute()] bool idSpecified) {
            this.Invoke("DeleteRecipiant", new object[] {
                        id,
                        idSpecified});
        }
        
        /// <remarks/>
        public void DeleteRecipiantAsync(int id, bool idSpecified) {
            this.DeleteRecipiantAsync(id, idSpecified, null);
        }
        
        /// <remarks/>
        public void DeleteRecipiantAsync(int id, bool idSpecified, object userState) {
            if ((this.DeleteRecipiantOperationCompleted == null)) {
                this.DeleteRecipiantOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteRecipiantOperationCompleted);
            }
            this.InvokeAsync("DeleteRecipiant", new object[] {
                        id,
                        idSpecified}, this.DeleteRecipiantOperationCompleted, userState);
        }
        
        private void OnDeleteRecipiantOperationCompleted(object arg) {
            if ((this.DeleteRecipiantCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteRecipiantCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/MainService.Model")]
    public partial class Message {
        
        private Stream[] attachmentsField;
        
        private string ownerLoginField;
        
        private string ownerPasswordField;
        
        private string[] receiversField;
        
        private string subjectMessageField;
        
        private string textMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/System.IO")]
        public Stream[] Attachments {
            get {
                return this.attachmentsField;
            }
            set {
                this.attachmentsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OwnerLogin {
            get {
                return this.ownerLoginField;
            }
            set {
                this.ownerLoginField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OwnerPassword {
            get {
                return this.ownerPasswordField;
            }
            set {
                this.ownerPasswordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] Receivers {
            get {
                return this.receiversField;
            }
            set {
                this.receiversField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SubjectMessage {
            get {
                return this.subjectMessageField;
            }
            set {
                this.subjectMessageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string TextMessage {
            get {
                return this.textMessageField;
            }
            set {
                this.textMessageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/System.IO")]
    public partial class Stream : MarshalByRefObject {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Stream))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/System")]
    public partial class MarshalByRefObject {
        
        private object @__identityField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public object @__identity {
            get {
                return this.@__identityField;
            }
            set {
                this.@__identityField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/MainService.Model.DbModels")]
    public partial class Recipiant {
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private int idListField;
        
        private bool idListFieldSpecified;
        
        private string mailField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int IdList {
            get {
                return this.idListField;
            }
            set {
                this.idListField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdListSpecified {
            get {
                return this.idListFieldSpecified;
            }
            set {
                this.idListFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Mail {
            get {
                return this.mailField;
            }
            set {
                this.mailField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/MainService.Model.DbModels")]
    public partial class RecipiantList {
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private string nameField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void SendCompletedEventHandler(object sender, SendCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void GetAllRecipiantsListCompletedEventHandler(object sender, GetAllRecipiantsListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllRecipiantsListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllRecipiantsListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RecipiantList[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RecipiantList[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void GetRecipientsListCompletedEventHandler(object sender, GetRecipientsListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecipientsListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecipientsListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Recipiant[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Recipiant[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void AddRecipiantListCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void AddRecipiantCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void UpdateRecipiantCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void DeleteRecipiantsListCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void DeleteRecipiantCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591