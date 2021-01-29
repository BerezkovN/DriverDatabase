using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace DriverDatabase
{
	class Listable
    {
		public event EventHandler ListChanged;

		public void FireListChanged()
		{
			if (ListChanged != null)
				ListChanged(this, null);
		}
	}

	class DriverList : Listable
	{
		private static DriverList instance = new DriverList();
		public static DriverList Instance { get { return instance; } set { } }

		public List<Driver> Drivers = new List<Driver>();
		

		public Driver this[int index]
		{
			get
			{
				return Drivers[index];
			}
			set
			{
				Drivers[index] = value;
				FireListChanged();
			}
		}

		public int Count { get { return Drivers.Count; } }

		public void Add(Driver driver)
		{
			Drivers.Add(driver);
			FireListChanged();
		}

		public void Remove(Driver driver)
		{
            foreach (var car in CarList.Instance.Cars.ToList())
            {
				car.Drivers.Remove(driver);
				if (car.Drivers.Count == 0)
					CarList.Instance.Cars.Remove(car);
            }

			Drivers.Remove(driver);
			FireListChanged();
		}

		readonly public static string DefaultFileName = @"drivers.xml";

		public void SaveToFile(String fileName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Driver>));
			StreamWriter writer = new StreamWriter(fileName);
			serializer.Serialize(writer, this.Drivers);
			writer.Close();
		}

		public void LoadFromFile(String fileName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Driver>));
			StreamReader reader = new StreamReader(fileName);
			this.Drivers = (List<Driver>)serializer.Deserialize(reader);
			reader.Close();

			InisitializeDriver();

			FireListChanged();
		}

		public void CreateFile(String fileName)
		{
			using (FileStream fs = File.Create(fileName))
			{

			}
		}

		private void InisitializeDriver()
        {
            for (int i = 0; i < CarList.Instance.Cars.Count; i++)
            {
                for (int b = 0; b < DriverList.Instance.Drivers.Count; b++)
                {
                    for (int c = 0; c < CarList.Instance.Cars[i].Drivers.Count; c++)
                    {
						if (DriverList.Instance.Drivers[b] == CarList.Instance.Cars[i].Drivers[c])
                        {
							DriverList.Instance.Drivers[b].Cars.Add(CarList.Instance.Cars[i]);
						}
                    }
				}
			}
            
        }
	}

	class CarList : Listable
	{
		private static CarList instance = new CarList();
		public static CarList Instance { get { return instance; } set { } }

		public List<Car> Cars = new List<Car>();


		public Car this[int index]
		{
			get
			{
				return Cars[index];
			}
			set
			{
				Cars[index] = value;
				FireListChanged();
			}
		}

		public int Count { get { return Cars.Count; } }



		public void Add(Car car)
		{
			Cars.Add(car);
			FireListChanged();
		}

		public void Remove(Car car)
		{
            foreach (var driver in DriverList.Instance.Drivers)
            {
				driver.Cars.Remove(car);
            }
			Cars.Remove(car);
			FireListChanged();
		}

		readonly public static string DefaultFileName = @"cars.xml";

		public void SaveToFile(String fileName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
			StreamWriter writer = new StreamWriter(fileName);
			serializer.Serialize(writer, this.Cars);
			writer.Close();
		}

		public void LoadFromFile(String fileName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
			StreamReader reader = new StreamReader(fileName);
			this.Cars = (List<Car>)serializer.Deserialize(reader);
			reader.Close();

			FireListChanged();
		}

		public void CreateFile(String fileName)
        {
			using (FileStream fs = File.Create(fileName)) { 
			}
		}

		public void SetCorrectDrivers()
        {
			for (int i = 0; i < this.Cars.Count; i++)
			{
				for (int a = 0; a < this.Cars[i].Drivers.Count; a++)
				{
					foreach (var driver in DriverList.Instance.Drivers)
					{
						if (driver == this.Cars[i].Drivers[a])
							this.Cars[i].Drivers[a] = driver;

					}
				}
			}
		}
	}
}
