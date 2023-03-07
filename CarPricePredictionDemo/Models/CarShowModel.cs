namespace CarPricePredictionDemo.Models
{
	public class CarShowModel
	{
		public Dictionary<string, HashSet<string>> BrandModels { get; set; }
		 
		public List<string> Brands { get; set; }

		public List<string> Models { get; set; }

        public List<string> GearTypes { get; set; }

		public List<string> FuelTypes { get; set; }

		public List<string> Colors { get; set; }
	}
}
