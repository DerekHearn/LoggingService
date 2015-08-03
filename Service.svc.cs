using ResultWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using StringExtensions;

namespace LoggingService
{
	
	public class Service : IService.IServiceJson
	{
		/// <summary>
		/// There are three parts to logging a method
		/// 1. the method info. method name, params, user session guid etc
		/// 2. any critical exceptions that may have arrisen durring execution
		/// 3. the error message sent back if any
		/// 2 and 3 are determined by exception, friendlyMessage and developerMessage
		/// they they did not occur just leave those fields as null
		/// </summary>
		[LoggedMethod]
		public BasicServiceResult logMethod(
			string name, string parameters, DateTime callDate, 
			bool success, Guid sessionGuid, double duration, bool testCall, 
			string api, string returnValue,
			string exceptionSource, string exceptionMessage, 
			string exceptionStackTrace, string exceptionTargetSite, 
			string friendlyMessage, string developerMessage)
		{
			//under the case that there was no error or exception
			//this will still be empty guids
			Guid errorGuid = Guid.Empty;
			Guid exceptionGuid = Guid.Empty;

			//get that service error message if it exists
			if (friendlyMessage.isNotNullOrEmpty() || developerMessage.isNotNullOrEmpty())
			{
				errorGuid = Guid.NewGuid();
				var mem = new BL.MethodErrorMessage(errorGuid, "2", 
					friendlyMessage, developerMessage, callDate);
				var sr = mem.save();
				if (!sr.wasSuccess())
					return new BasicServiceResult(sr);
			}

			//get that exception deets if they exist
			if (exceptionMessage.isNotNullOrEmpty())
			{
				var mle = new BL.MethodLogException(Guid.NewGuid(), "2", exceptionSource, exceptionMessage,
					exceptionStackTrace, exceptionTargetSite, callDate);
				exceptionGuid = mle.guid;
				var sr = mle.save();

				if (!sr.wasSuccess())
				{
					return new BasicServiceResult(sr);
				}
			}
				
			var ml = new BL.MethodLog(name, parameters, callDate, success,
					sessionGuid, errorGuid, exceptionGuid, duration, testCall, api, returnValue);
			var saveResult = ml.save();

			if (!saveResult.wasSuccess())
			{
				return new BasicServiceResult(saveResult);
			}

			return BasicServiceResult.NoError;
		}

		[LoggedMethod]
		public BasicServiceResult logException(
			string source, string message, string stackTrace,
			string targetSite, DateTime date)
		{
			var mle = new BL.MethodLogException(Guid.NewGuid(), "2", 
				source, message, stackTrace, targetSite, date);
			var sr = mle.save();

			if (!sr.wasSuccess())
			{
				return new BasicServiceResult(sr);
			}

			return BasicServiceResult.NoError;
		}

		[LoggedMethod]
		public bool test()
		{
			return true;
		}
	}
}
