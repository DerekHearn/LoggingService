using ResultWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StringExtensions;

namespace LoggingService.BL
{
	public class MethodErrorMessage : ILog
	{
		public readonly Guid guid;

		/// <summary>
		/// varchar(50)
		/// error enum
		/// </summary>
		public readonly string code;

		/// <summary>
		/// varchar(1000)
		/// </summary>
		public readonly string friendlyMessage;

		/// <summary>
		/// varchar(1000)
		/// </summary>
		public readonly string developerMessage;

		public readonly DateTime date;

		public MethodErrorMessage(Guid guid, string code, 
			string friendlyMessage, string developerMessage, DateTime date)
		{
			this.guid = guid;
			this.code = trimCode(code);
			this.friendlyMessage = trimFriendlyMessage(friendlyMessage);
			this.developerMessage = trimDeveloperMessage(developerMessage);
			this.date = date;
		}

		private string trimCode(string code)
		{
			return code.maxLengthTrim(50);
		}

		private string trimFriendlyMessage(string friendlyMessage)
		{
			return friendlyMessage.maxLengthTrim(1000);
		}

		private string trimDeveloperMessage(string developerMessage)
		{
			return developerMessage.maxLengthTrim(1000);
		}

		public BLError save()
		{
			var mle = new DAL.MethodLogError();
			mle.MBExceptionGuid = guid;
			mle.MBExceptionCode = code;
			mle.FriendlyMessage = friendlyMessage;
			mle.DeveloperMessage = developerMessage;

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
	}
}