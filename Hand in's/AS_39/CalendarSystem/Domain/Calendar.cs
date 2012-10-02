using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalendarSystem.TechnicalServices.Storing;

namespace CalendarSystem.Domain
{
	class Calendar
	{
		public int ID { get; private set; }
		public String Name { get; set; }
		private int nextID = 1;

		public void create(DateTime StartDateAndTime, DateTime EndDateAndTime, string Location, string Description, string Title)
		{
			int id = findId();
			saveEvent(id, StartDateAndTime, EndDateAndTime, Location, Description, Title);
		}

		private void saveEvent(int id, DateTime StartDateAndTime, DateTime EndDateAndTime, string Location, string Description, string Title)
		{
			Event ev = new Event(id, StartDateAndTime, EndDateAndTime, Location, Description, Title);

			// Saves the event to a collection - maybe a hashset?

			LocalStorage.storeLocally(this);
		}

		private int findId()
		{
			return nextID++;
		}

		public void edit(int id, DateTime StartDateAndTime, DateTime EndDateAndTime, string Location, string Description, string Title)
		{
			saveEvent(id, StartDateAndTime, EndDateAndTime, Location, Description, Title);
		}

		public void delete(int id)
		{
			//TODO
		}
	}
}
