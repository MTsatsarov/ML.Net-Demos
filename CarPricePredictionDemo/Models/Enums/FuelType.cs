using System.ComponentModel.DataAnnotations;

namespace CarPricePredictionDemo.Models.Enums
{
	public enum FuelType
	{
		[Display(Name = "Дизел")]
		Дизел,

		[Display(Name = "Бензин")]
		Бензин,

		[Display(Name = "Газ")]
		Газ,

		[Display(Name = "Метан")]
		Метан
	}
}
