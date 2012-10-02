using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalendarSystem.Domain;

namespace CalendarSystem.TechnicalServices.Storing
{
	static class LocalStorage
	{
		public static void storeLocally(Calendar cal)
		{
			// Stores the calender in a pre-specified format.
		}

		public static void storeLocally(Calendar cal, StorageFormat formatter)
		{
			// Stores the calender in a format specified by the storageFormat.
		}

		public static void deleteCalendar(Calendar cal)
		{
			// Deletes the specified calendar from the local system.
		}
	}
}
