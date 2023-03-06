using CarPricePredictionDemo.Models;
using CarPricePredictionDemo.Models.Enums;
using CarPricePredictionDemo.Services.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Globalization;
using System.Reflection;

namespace CarPricePredictionDemo.Services
{
	public class CarService : ICarService
	{
		public CarShowModel GetCarsDropdownLists()
		{
			var carsDropdownLists = new CarShowModel();

			var gearTypes = Enum.GetValues(typeof(GearType)).Cast<GearType>();
			var stringGearTypes = new List<string>();
			foreach (var gearType in gearTypes)
			{
				var name = gearType
					.GetType()
					.GetMember(gearType.ToString())
					.First()
					.GetCustomAttribute<DisplayAttribute>()
				?.GetName();
				stringGearTypes.Add(name.ToString());
			}

			var fuelTypes = Enum.GetValues(typeof(FuelType)).Cast<FuelType>();
			var stringFuelTypes = new List<string>();
			foreach (var fuelType in fuelTypes)
			{
				stringFuelTypes.Add(fuelType.ToString());
			}

			var colors = Enum.GetValues(typeof(Models.Enums.Colors)).Cast<Models.Enums.Colors>();
			var colorsTostring = new List<string>();
			foreach (var color in colors)
			{
				colorsTostring.Add(color.ToString());
			}

			var brandModels = this.GetModelAndBrandsFromCsv();

			carsDropdownLists.BrandModels = brandModels;
			carsDropdownLists.Brands = brandModels.Keys.ToList();
			carsDropdownLists.GearTypes = stringGearTypes;
			carsDropdownLists.FuelTypes = stringFuelTypes;
			carsDropdownLists.Colors = colorsTostring;

			return carsDropdownLists;
		}

		public Dictionary<string, HashSet<string>> GetModelAndBrandsFromCsv()
		{
			var path = Assembly.GetExecutingAssembly().Location;
			var realPath = path + @" ../../../../../../../BrandModels.txt";
			var brandModel = new Dictionary<string, HashSet<string>>();
			var csvData = GetRecordsFromCsv<BrandModelCsv>(realPath).ToHashSet();

			foreach (var record in csvData)
			{
				if (!brandModel.Keys.Contains(record.Brand))
				{
					brandModel.Add(record.Brand, new HashSet<string>());
				}

				brandModel[record.Brand].Add(record.Model);
			}
			return brandModel;
		}
		public static IEnumerable<T> GetRecordsFromCsv<T>(string path)
		{

			var config = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				PrepareHeaderForMatch = args => args.Header.ToLower()
			};

			using (var reader = new StreamReader(path))
			using (var csv = new CsvReader(reader, config))
			{

				return csv.GetRecords<T>().ToHashSet();
			}
		}

	}
}
