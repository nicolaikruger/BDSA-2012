using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarSystem.Domain
{
	class Event
	{
		public int Id;
		public DateTime CreatedAt, StartDateAndTime, EndDateAndTime;
		public string Location, Description, Title;


		public Event(int Id, DateTime StartDateAndTime, DateTime EndDateAndTime, string Location, string Description, string Title)
		{
			this.Id = Id;
			this.StartDateAndTime = StartDateAndTime;
			CreatedAt = DateTime.Now;
			this.EndDateAndTime = EndDateAndTime;
			this.Location = Location;
			this.Description = Description;
			this.Title = Title;
		}
	}
}
