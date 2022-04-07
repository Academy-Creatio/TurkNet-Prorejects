namespace TurkNet.Api.Dto
{
	public interface IBootParamsDto
	{
		string Message { get; set; }
		string RedirectUri { get; set; }
		IBootParamsResultDto Result { get; set; }
		string ResultCode { get; set; }
		bool Status { get; set; }
	}
}