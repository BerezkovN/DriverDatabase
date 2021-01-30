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
		public static DriverList Instance 
		{ 
			get { return instance; } 
			set { } 
		}

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

			FireListChanged();
		}

		public void CreateFile(String fileName)
		{
			using (FileStream fs = File.Create(fileName))
			{

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

		public void LoadFromDrivers()
		{
            foreach (var driver in DriverList.Instance.Drivers)
            {
                foreach (var car in driver.Cars.ToList())
                {
					if (!CarList.Instance.Cars.Any(el => Car.Compare(el, car)))
					{
						CarList.Instance.Cars.Add(car);
						car.Drivers.Add(driver);
					}
					else
                    {
						Car createdCar = CarList.Instance.Cars.Find(el => Car.Compare(el, car));
						createdCar.Drivers.Add(driver);
						driver.Cars.Remove(car);
						driver.Cars.Add(createdCar);
					}
					
				}
            }

			FireListChanged();
		}

		public void CreateFile(String fileName)
        {
			using (FileStream fs = File.Create(fileName)) { 
			}
		}
	}
}
