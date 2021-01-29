using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DriverDatabase
{
	public class Driver
	{
		public String Name { get; set; }
		public DateTime BirthDate;
		[XmlIgnore]
		public List<Car> Cars;

		public Driver() {
			Cars = new List<Car>();
		}

		public static bool operator== (Driver a1, Driver a2)
        {
			if (a1.Name == a2.Name && a1.BirthDate == a2.BirthDate)
            {
				return true;
            }
			return false;
        }

		public static bool operator!=(Driver a1, Driver a2)
		{
			if (a1.Name != a2.Name || a1.BirthDate != a2.BirthDate)
			{
				return true;
			}
			return false;
		}

		public override String ToString()
		{
			return Name;
		}
	}

	public class Car
    {
		public String Name { get; set; }
		public List<Driver> Drivers = new List<Driver>();

		public string StringAuthors
        {
			get
            {
				string result = "";
				foreach (Driver author in Drivers)
				{
					result += author.Name + ", ";
				}

				return result.Substring(0, result.Length - 2);
			}
        }

        public override string ToString()
        {
			return Name + " by " + StringAuthors;
        }
    }
}
