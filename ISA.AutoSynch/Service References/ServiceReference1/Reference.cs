﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8009
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISA.AutoSynch.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.Service1Soap")]
    public interface Service1Soap {
        
        // CODEGEN: Generating message contract since element name cabang from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertMonitoring", ReplyAction="*")]
        ISA.AutoSynch.ServiceReference1.InsertMonitoringResponse InsertMonitoring(ISA.AutoSynch.ServiceReference1.InsertMonitoringRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertMonitoringRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertMonitoring", Namespace="http://tempuri.org/", Order=0)]
        public ISA.AutoSynch.ServiceReference1.InsertMonitoringRequestBody Body;
        
        public InsertMonitoringRequest() {
        }
        
        public InsertMonitoringRequest(ISA.AutoSynch.ServiceReference1.InsertMonitoringRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertMonitoringRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cabang;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Computername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string username;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Password;
        
        public InsertMonitoringRequestBody() {
        }
        
        public InsertMonitoringRequestBody(string cabang, string Computername, string username, string Password) {
            this.cabang = cabang;
            this.Computername = Computername;
            this.username = username;
            this.Password = Password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertMonitoringResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertMonitoringResponse", Namespace="http://tempuri.org/", Order=0)]
        public ISA.AutoSynch.ServiceReference1.InsertMonitoringResponseBody Body;
        
        public InsertMonitoringResponse() {
        }
        
        public InsertMonitoringResponse(ISA.AutoSynch.ServiceReference1.InsertMonitoringResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class InsertMonitoringResponseBody {
        
        public InsertMonitoringResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface Service1SoapChannel : ISA.AutoSynch.ServiceReference1.Service1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class Service1SoapClient : System.ServiceModel.ClientBase<ISA.AutoSynch.ServiceReference1.Service1Soap>, ISA.AutoSynch.ServiceReference1.Service1Soap {
        
        public Service1SoapClient() {
        }
        
        public Service1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ISA.AutoSynch.ServiceReference1.InsertMonitoringResponse ISA.AutoSynch.ServiceReference1.Service1Soap.InsertMonitoring(ISA.AutoSynch.ServiceReference1.InsertMonitoringRequest request) {
            return base.Channel.InsertMonitoring(request);
        }
        
        public void InsertMonitoring(string cabang, string Computername, string username, string Password) {
            ISA.AutoSynch.ServiceReference1.InsertMonitoringRequest inValue = new ISA.AutoSynch.ServiceReference1.InsertMonitoringRequest();
            inValue.Body = new ISA.AutoSynch.ServiceReference1.InsertMonitoringRequestBody();
            inValue.Body.cabang = cabang;
            inValue.Body.Computername = Computername;
            inValue.Body.username = username;
            inValue.Body.Password = Password;
            ISA.AutoSynch.ServiceReference1.InsertMonitoringResponse retVal = ((ISA.AutoSynch.ServiceReference1.Service1Soap)(this)).InsertMonitoring(inValue);
        }
    }
}
