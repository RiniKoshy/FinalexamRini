using System;

namespace Finalnet22
{
	public class Program
	{
		public static void Main()
		{
			
			var person = new Person();
			person.name = "Rini Koshy";
			var alarm = new AlarmClock();
			alarm.AlarmClockEvent += person.HandleAlarm;
			alarm.Alarm();
		}
	}

	public class Person
	{
		public string name { get; set; }

		public void HandleAlarm(object sender, AlarmClockEventArgs e)
		{
			Console.WriteLine("Get up Rini it's {0}", e.time);
		}

	}

	
	public class AlarmClock
	{
		public event AlarmClockEventHandeler AlarmClockEvent;

		public void Alarm()
		{
			AlarmClockEventHandeler alarm = AlarmClockEvent;
			if (AlarmClockEvent != null)
			{
				alarm(this, new AlarmClockEventArgs(DateTime.Now));
			}

		}
	}

	public delegate void AlarmClockEventHandeler(object source, AlarmClockEventArgs e);

	public class AlarmClockEventArgs : EventArgs
	{
		public DateTime time { get; set; }
		public AlarmClockEventArgs(DateTime time)
		{
			this.time = time;

		}
	}
}
