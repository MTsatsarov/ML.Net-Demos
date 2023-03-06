
namespace MobileApp.Services.Interfaces
{
	public interface ICommentaryService
	{
		ModelBuilder.ModelOutput Predict(string text);
	}
}
