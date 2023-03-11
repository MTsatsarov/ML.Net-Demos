using Microsoft.ML.Data;
namespace ObjectDectection.Models
{
	public class ImageNetPrediction
	{
		[ColumnName("grid")]
		public float[] PredictedLabels;
	}
}
