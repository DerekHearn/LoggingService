using ResultWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StringExtensions;

namespace LoggingService.BL
{
	public class MethodLog : ILog
	{
		#region members

		/// <summary>
		/// varchar(100)
		/// </summary>
		public readonly string name;

		/// <summary>
		/// varchar(max)
		/// </summary>
		public readonly string parameters;

		public readonly DateTime callDate;

		public readonly bool success;

		public readonly Guid sessionGuid;

		public readonly Guid exceptionGuid;

		public readonly Guid errorGuid;

		public readonly double duration;

		public readonly bool testCall;


		/// <summary>
		/// varchar(10)
		/// </summary>
		public readonly string api;

		/// <summary>
		/// varchar(1000)
		/// </summary>
		public readonly string returnValue;

		#endregion

		#region ctors

		public MethodLog(string name, string parameters,
			DateTime callDate, bool success, Guid sessionGuid,
			Guid exceptionGuid, Guid mbExceptionGuid,
			double duration, bool testCall, string api, string returnValue)
		{
			this.name = trimName(name);
			this.parameters = trimParameters(parameters);
			this.api = trimAPI(api);
			this.returnValue = trimReturnValue(returnValue);
			this.callDate = callDate;
			this.success = success;
			this.sessionGuid = sessionGuid;
			this.exceptionGuid = exceptionGuid;
			this.errorGuid = mbExceptionGuid;
			this.duration = duration;
			this.testCall = testCall;
		}

		#endregion

		#region init functions

		private string trimName(string name)
		{
			return name.maxLengthTrim(100);
		}

		private string trimParameters(string parameters)
		{
			//at max length, no action is needed.
			return parameters;
		}

		private string trimAPI(string api)
		{
			return api.maxLengthTrim(10);
		}

		private string trimReturnValue(string returnValue)
		{
			return returnValue.maxLengthTrim(1000);
		}

		#endregion

		#region public functions

		public BLError save()
		{
 			var ml = new DAL.MethodLog();
			ml.Name = name;
			ml.Parameters = parameters;
			ml.API = api;
			ml.RetVal = returnValue;
			if (!callDate.Equals(DateTime.MinValue))
				ml.CallDate = callDate;
			ml.Successful = success;
			
			//leave em null if they're empty
			if (!sessionGuid.Equals(Guid.Empty))
				ml.SessionGuid = sessionGuid;
			if(!exceptionGuid.Equals(Guid.Empty))
				ml.ExceptionGuid = exceptionGuid;
			if (!errorGuid.Equals(Guid.Empty))
				ml.MBExceptionGuid = errorGuid;
			
			ml.Duration = duration;
			ml.TestBool = testCall;
			try
			{
				ml.Save();
				return BLError.NoError;
			}
			catch(Exception e)
			{
				return new BLError(e);
			}
		}

		#endregion
	}
}