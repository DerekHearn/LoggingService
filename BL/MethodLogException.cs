using ResultWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StringExtensions;

namespace LoggingService.BL
{
	public class MethodLogException : ILog
	{
		#region members

		public readonly Guid guid;

		/// <summary>
		/// varchar(50)
		/// the enum of the exception
		/// </summary>
		public readonly string code;

		/// <summary>
		/// varchar(100)
		/// </summary>
		public readonly string source;

		/// <summary>
		/// varchar(max)
		/// </summary>
		public readonly string message;

		/// <summary>
		/// varchar(max)
		/// </summary>
		public readonly string stackTrace;

		/// <summary>
		/// varchar(500)
		/// </summary>
		public readonly string targetSite;

		public readonly DateTime date;

		#endregion

		#region ctors

		public MethodLogException(Guid guid, string code,
			string source, string message, string stackTrace,
			string targetSite, DateTime date)
		{
			this.guid = guid;
			this.source = trimSource(source);
			this.message = trimMessage(message);
			this.stackTrace = trimStackTrace(stackTrace);
			this.targetSite = trimTargetSite(targetSite);
			this.date = date;
		}

		public MethodLogException(Exception exception, DateTime date)
			:this(Guid.NewGuid(), "2", exception.Source, exception.Message, 
			exception.StackTrace, exception.TargetSite.Name, date)
		{
		}

		#endregion

		#region private methods

		private string trimCode(string code)
		{
			return code.maxLengthTrim(50);
		}

		private string trimSource(string source)
		{
			return source.maxLengthTrim(100);
		}

		private string trimMessage(string message)
		{
			//at max length no need to trim
			return message;
		}

		private string trimStackTrace(string stackTrace)
		{
			//at max length no need to trim
			return stackTrace;
		}

		private string trimTargetSite(string targetSite)
		{
			return targetSite.maxLengthTrim(500);
		}

		#endregion

		#region public methods

		public BLError save()
		{
			var mle = new DAL.MethodLogException();
			mle.ExceptionGuid = guid;
			mle.ExceptionSource = source;
			mle.ExceptionMessage = message;
			mle.ExceptionStackTrace = stackTrace;
			mle.ExceptionTargetSite = targetSite;
			if(!date.Equals(DateTime.MinValue))
				mle.ExceptionDate = date;
			try
			{
				mle.Save();
				return BLError.NoError();
			}
			catch (Exception e)
			{
				return new BLError(e);
			}
		}

		#endregion
	}
}