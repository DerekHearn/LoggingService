using ResultWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.IService
{
	[ServiceContract]
	public interface ILoggingService
	{
		/// <summary>
		/// There are three parts to logging a method
		/// 1. the method info. method name, params, user session guid etc
		/// 2. any critical exceptions that may have arrisen durring execution
		/// 3. the error message sent back if any
		/// 2 and 3 are determined by exception, friendlyMessage and developerMessage
		/// they they did not occur just leave those fields as null
		/// </summary>
		[OperationContract]
		[WebInvoke(ResponseFormat = WebMessageFormat.Json, UriTemplate =
			"log/method", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		BasicServiceResult logMethod(
			string name, string parameters, DateTime callDate,
			bool success, Guid sessionGuid, double duration, bool testCall,
			string api, string returnValue,
			string exceptionSource, string exceptionMessage,
			string exceptionStackTrace, string exceptionTargetSite,
			string friendlyMessage, string developerMessage);

		/// <summary>
		/// intended purpose is for logging an error that is not necessarily connected to a service
		/// </summary>
		[OperationContract]
		[WebInvoke(ResponseFormat = WebMessageFormat.Json, UriTemplate =
			"log/exception", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		BasicServiceResult logException(string source, string message, string stackTrace,
			string targetSite, DateTime date);

		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "log/test")]
		bool test();
	}
}
