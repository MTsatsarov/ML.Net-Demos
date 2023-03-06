using System.ComponentModel.DataAnnotations;

namespace CarPricePredictionDemo.Models.Enums
{
	public enum GearType
	{
		[Display(Name = "Ръчни Скорости")]
		РъчниСкорости = 1,

		[Display(Name = "Автоматични Скорости")]
		АвтоматичниСкорости = 2,
	}
}
